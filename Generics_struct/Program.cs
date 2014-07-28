// Продемонстрировать применение обобщенной структуры. 
using System;
// Эта структура является обобщенной, 
struct XY<T>
{
    T x;
    T y;

    public XY(T a, T Ь)
    {
        x = a;
        y = Ь;
    }

    public T X
    {
        get { return x; }
        set { x = value; }
    }

    public T Y
    {
        get { return y; }
        set { y = value; }
    }
}
class StructTest
{
    static void Main()
    { 
        XY<int> xy = new XY<int>(10, 20); 
        XY<double> xy2 = new XY<double>(88.0, 99.0); 

        Console.WriteLine(xy.X + ", " + xy.Y); 
        Console.WriteLine(xy2.X + ", " + xy2.Y); 
    }
}
