// Создать несколько потоков исполнения. 
using System;
using System.Threading;
class MyThread
{
    public int Count;
    public Thread Thrd;
    public MyThread(string name)
    {
        Count = 0;
        Thrd = new Thread(this.Run);
        Thrd.Name = name;
        Thrd.Start();
    }
    // Точка входа в поток, 
    void Run()
    {
        Console.WriteLine(Thrd.Name + " начат.");
        do
        {
            Thread.Sleep(100);
            Console.WriteLine("В потоке " + Thrd.Name + ", Count = " + Count);
            Count++;
        } while (Count < 10);
        Console.WriteLine(Thrd.Name + " завершен.");
    }
}
// Использовать свойство IsAlive для отслеживания момента окончания потоков, 
class MoreThreads
{
    static void Main() 
    { 
        Console.WriteLine("Основной поток начат."); 
        // Сконструировать три потока. 
        MyThread mtl = new MyThread("Поток #1"); 
        MyThread mt2 = new MyThread("Поток #2"); 
        MyThread mt3 = new MyThread("Поток #3"); 
        do 
        { 
            Console.Write(".") ; 
            Thread.Sleep (100); 
        } while (mtl.Thrd.IsAlive && 
                mt2.Thrd.IsAlive && 
                mt3.Thrd.IsAlive); 
        Console.WriteLine("Основной поток завершен."); 
    }
}
