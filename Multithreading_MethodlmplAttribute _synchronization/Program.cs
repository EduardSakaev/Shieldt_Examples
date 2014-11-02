// Использовать атрибут MethodlmplAttribute для синхронизации метода. 
using System; 
using System.Threading; 
using System.Runtime.CompilerServices; 
// Вариант класса TickTock, переделанный с целью 
// использовать атрибут MethodlmplOptions.Synchronized. 
class TickTock
{ 
    /* Следующий атрибут полностью синхронизирует метод Tick(). */ 
    [MethodImplAttribute(MethodImplOptions.Synchronized) ] 
    public void Tick(bool running) 
    { 
        if (!running) 
        { // остановить часы 
            Monitor.Pulse(this); // уведомить любые ожидающие потоки 
            return; 
        } 
        Console.Write("тик "); 
        Monitor.Pulse(this); // разрешить выполнение метода Tock() 
        Monitor.Wait(this); // ожидать завершения метода Tock() 
    } 

    /* Следующий атрибут полностью синхронизирует метод Тоск(). */ 
    [MethodImplAttribute(MethodImplOptions.Synchronized)] 
    public void Tock(bool running) 
    { 
        if (!running) 
        { // остановить часы 
            Monitor.Pulse(this); // уведомить любые ожидающие потоки 
            return; 
        }
        Console.WriteLine("так"); 
        Monitor.Pulse(this); // разрешить выполнение метода Tick() 
        Monitor.Wait(this); // ожидать завершения метода Tick() 
    } 
} 

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
    void Run ()
    { 
        if(Thrd.Name == "Tick") 
        { 
            for(int i=0; i<5; i++) ttOb.Tick(true); 
            ttOb.Tick(false); 
        } 
        else 
        { 
            for(int i=0; i<5; i++) ttOb.Tock(true); 
            ttOb.Tock(false); 
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
