// Использовать блокировку для синхронизации доступа к объекту. 
using System; 
using System.Threading; 
class SumArray 
{ 
    int sum; 
    object lockOn = new object(); // закрытый объект, доступный 
    // для последующей блокировки 
    public int Sumlt(int[] nums) 
    { 
        lock(lockOn) { // заблокировать весь метод 
        sum =0; // установить исходное значение суммы 
        for(int i=0; i < nums.Length; i++) 
        { 
            sum += nums[i]; 
            Console.WriteLine("Текущая сумма для потока " + 
            Thread.CurrentThread.Name + " равна " + sum); 
            Thread.Sleep(10); // разрешить переключение задач 
        } 
        return sum; 
        } 
    } 
} 

class MyThread 
{ 
    public Thread Thrd;
    int[] a; 
    int answer; 
    // Создать один объект типа SumArray для всех 
    // экземпляров класса MyThread. 
    static SumArray sa = new SumArray (); 
    // Сконструировать новый поток. 
    public MyThread(string name, int[] nums)
    { 
        a = nums; 
        Thrd = new Thread(this.Run); 
        Thrd.Name = name; 
        Thrd.Start(); // начать поток 
    } 
    // Начать выполнение нового потока, 
    void Run() 
    { 
        Console.WriteLine (Thrd.Name + " начат."); 
        answer = sa.Sumlt(a); 
        Console.WriteLine("Сумма для потока " + Thrd.Name + " равна " + answer); 
        Console.WriteLine(Thrd.Name + " завершен."); 
    } 
}

class Sync
{
    static void Main() 
    { 
        int[] a = {1, 2, 3, 4, 5}; 
        MyThread mtl = new MyThread ("Потомок #1", a);
        MyThread mt2 = new MyThread("Потомок #2", a); 
        mtl.Thrd.Join(); 
        mt2.Thrd.Join() ; 
    }
} 

