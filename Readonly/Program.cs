// Продемонстрировать применение поля с ключевым словом readonly. 
using System;
class MyClass
{
    public readonly int SIZE;
    public MyClass(int x) { SIZE = x; }
}

class DemoReadOnly 
{ 
    static void Main() 
    {
        MyClass myclassobj = new MyClass(10);
        int[] source = new int[myclassobj.SIZE];
        int[] target = new int[myclassobj.SIZE]; 
        // Присвоить ряд значений элементам массива source, 
        for (int i = 0; i < myclassobj.SIZE; i++) 
        source[i] = i; 
        foreach(int i in source) 
        Console.Write(i + " "); 
        Console.WriteLine(); 
        // Перенести обращенную копию массива source в массив target, 
        for (int i = myclassobj.SIZE - 1, j = 0; i > 0; i--, j++) 
        target[j] = source[i]; 
        foreach(int i in target) 
        Console.Write(i + " "); 
        Console.WriteLine();
        //myclassobj.SIZE = 100; // Ошибка!!! Не подлежит изменению! 
    } 
} 
