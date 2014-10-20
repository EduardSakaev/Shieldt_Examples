// Использовать метод Join(). 
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
        // Использовать метод Join() для ожидания до тех пор, 
        // пока потоки не завершатся, 
    }
}
class JoinThreads 
{ 
    static void Main()
    { 
        Console.WriteLine("Основной поток начат."); 
        // Сконструировать три потока. 
        MyThread mtl = new MyThread("Потомок #1");
        MyThread mt2 = new MyThread("Потомок #2"); 
        MyThread mt3 = new MyThread("Потомок #3"); 
        mtl.Thrd.Join(); 
        Console.WriteLine("Потомок #1 присоединен."); 
        mt2.Thrd.Join(); 
        Console.WriteLine("Потомок #2 присоединен."); 
        mt3.Thrd.Join(); 
        Console.WriteLine("Потомок #3 присоединен."); 
        Console.WriteLine("Основной поток завершен."); 
    }
}
