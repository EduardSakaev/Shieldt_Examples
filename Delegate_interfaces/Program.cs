// Продемонстрировать применение обобщенного интерфейса. 
using System; 
public interface ISeries<T> 
{ 
    T GetNext();// возвратить следующее по порядку число 
    void Reset(); // генерировать ряд последовательных чисел с самого начала 
    void SetStart (T v); // задать начальное значение 
} 
//Реализовать интерфейс ISeries, 
class ByTwos<T> : ISeries<T>
{
    T start;
    T val;
    // Этот делегат определяет форму метода, вызываемого для генерирования 
    // очередного элемента в ряду последовательных значений. 
    public delegate T IncByTwo(T v);
    // Этой ссылке на делегат будет присвоен метод, 
    // передаваемый конструктору класса ByTwos. 
    IncByTwo incr;

    public ByTwos(IncByTwo incrMeth)
    {
        start = default(T);
        val = default(T);
        incr = incrMeth;
    }

    public T GetNext()
    {
        val = incr(val);
        return val;
    }

    public void Reset()
    {
        val = start;
    }
    public void SetStart(T v)
    {
        start = v;
        val = start;
    }
}

class ThreeD
{ 
    public int x, у, z; 
    public ThreeD(int a, int b, int c)
    { 
        x = a; 
        у = b; 
        z = c; 
    } 
} 
class GenlntfDemo 
{ 
    // Определить метод увеличения на два каждого 
    // последующего значения типа int. 
    static int IntPlusTwo(int v) 
    { 
        return v + 2; 
    } 
    // Определить метод увеличения на два каждого 
    // последующего значения типа double, 
    static double DoublePlusTwo(double v) 
    { 
        return v + 2.0; 
    } 
    // Определить метод увеличения на два каждого 
    // последующего значения координат объекта типа ThreeD. 
    static ThreeD ThreeDPlusTwo(ThreeD v)
    { 
        if(v==null) return new ThreeD(0, 0, 0) ; 
        else return new ThreeD(v.x + 2, v.у + 2, v.z + 2); 
    } 
    static void Main() 
    { 
        // Продемонстрировать генерирование 
        // последовательного ряда значений типа int. 
        ByTwos<int> intBT = new ByTwos<int>(IntPlusTwo); 
        for(int i=0; i < 5; i++) 
        Console.Write (intBT.GetNext() + " ") ; 
        Console.WriteLine (); 
        // Продемонстрировать генерирование 
        // последовательного ряда значений типа double. 
        ByTwos<double> dblBT = new ByTwos<double>(DoublePlusTwo); 

        dblBT.SetStart(1.4); 
        for(int i=0; i < 5; i++) 
        Console. Write (dblBT. GetNext() + " ") ; 
        Console.WriteLine (); 
        // Продемонстрировать генерирование последовательного ряда 
        // значений координат объекта типа ThreeD. 
        ByTwos<ThreeD> ThrDBT = new ByTwos<ThreeD>(ThreeDPlusTwo); 
        ThreeD coord; 
        for(int i=0; i < 5; i++) 
        {  
            coord = ThrDBT.GetNext(); 
            Console.Write(coord.x + "," + 
            coord.у + "," + 
            coord.z + " "); 
        } 
        Console.WriteLine(); 
    } 
} 
