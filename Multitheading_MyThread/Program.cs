// Создать поток исполнения. 
using System; 
using System.Threading; 

class MyThread
{ 
    public int Count; 
    string thrdName; 
    public MyThread(string name)
    { 
        Count = 0; 
        thrdName = name; 
    } 
    // Точка входа в поток, 
    public void Run() 
    { 
        Console.WriteLine(thrdName + " начат."); 
        do 
        { 
            Thread.Sleep(100); 
            Console.WriteLine("В потоке " + thrdName + ", Count = " + Count); 
            Count++; 
        } while(Count < 10) ; 
        Console.WriteLine(thrdName + " завершен."); 
    } 
}
class MultiThread
{
    static void Main()
    { 
        Console.WriteLine("Основной поток начат."); 
        // Сначала сконструировать объект типа MyThread. 
        MyThread mt = new MyThread("Потомок #1"); 
        // Далее сконструировать поток из этого объекта. 
        Thread newThrd = new Thread(mt.Run); 
        // И наконец, начать выполнение потока. 
        newThrd.Start();
        int Count = 0;
        do 
        { 
            Thread.Sleep(100);
            Console.WriteLine("В основном потоке " + "Count = " + Count);
            Count++;
        } while (mt.Count != 10); 
        Console.WriteLine("Основной поток завершен."); 
    }
} 

