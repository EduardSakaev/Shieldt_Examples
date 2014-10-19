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
        } while(Count < 10); 
        Console.WriteLine(Thrd.Name + " завершен."); 
    }
}
class MoreThreads
{
    static void Main() { 
    Console.WriteLine("Основной поток начат."); 
    // Сконструировать три потока. 
    MyThread mtl = new MyThread("Потомок #1"); 
    MyThread mt2 = new MyThread("Потомок #2"); 
    MyThread mt3 = new MyThread("Потомок #3"); 
    do 
    { 
        Console.Write ("."); 
        Thread.Sleep (100); 
    } while (mtl.Count < 10 || 
            mt2.Count < 10 || 
            mt3.Count < 10); 
    Console.WriteLine("Основной поток завершен."); 
    }
}
