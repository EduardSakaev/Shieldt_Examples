// Использовать методы Wait() и Pulse () для имитации тиканья часовТ 
using System;
using System.Threading;
class TickTock
{
    object lockOn = new object();
    public void Tick(bool running)
    {
        lock (lockOn)
        {
            if (!running)
            { // остановить часы 
                Monitor.Pulse(lockOn); // уведомить любые ожидающие потоки 
                return;
            }
            Console.Write("тик ");
            Monitor.Pulse(lockOn); // разрешить выполнение метода Tock() 
            Monitor.Wait(lockOn); // ожидать завершения метода Tock() 
        }
    }

    public void Tock(bool running)
    {
        lock (lockOn)
        {
            if (!running)
            { // остановить часы 
                Monitor.Pulse(lockOn); // уведомить любые ожидающие потоки 
                return;
            }
            Console.WriteLine("так");
            Monitor.Pulse(lockOn); // разрешить выполнение метода Tick() 
            Monitor.Wait(lockOn); // ожидать завершения метода Tick() 
        }
    }
}


//class TickTock
//{
//    object lockOn = new object();
//    public void Tick(bool running)
//    {
//        lock (lockOn)
//        {
//            if (!running)
//            { // остановить часы 
//                return;
//            }
//            Console.Write("тик ");
//        }
//    }
//    public void Tock(bool running)
//    {
//        lock (lockOn)
//        {
//            if (!running)
//            { // остановить часы 
//                return;
//            }
//            Console.WriteLine("так");
//        }
//    }
//} 

class MyThread
{ 
    public Thread Thrd; 
    TickTock ttOb; 
    // Сконструировать новый поток. 
    public MyThread(string name, TickTock tt) 
    { 
        Thrd = new Thread(this.Run); 
        ttOb = tt; 
        Thrd.Name = name; 
        Thrd.Start();
    } 
    // Начать выполнение нового потока, 
    void Run() { 
        if(Thrd.Name == "Tick")
        { 
            for(int i=0; i<5; i++) ttOb.Tick(true); 
            ttOb.Tick(false); 
        } 
        else { 
            for(int i=0; i<5; i++) ttOb.Tock(true); 
            ttOb.Tock(false) ; 
        } 
    } 
}

class TickingClock
{
    static void Main()
    {
        TickTock tt = new TickTock();
        MyThread mtl = new MyThread("Tick", tt);
        MyThread mt2 = new MyThread("Tock", tt);
        mtl.Thrd.Join();
        mt2.Thrd.Join();
        Console.WriteLine("Часы остановлены");
    }
} 

