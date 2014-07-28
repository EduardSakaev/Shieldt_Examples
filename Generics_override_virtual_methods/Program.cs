// Пример переопределения виртуального метода в обобщенном классе. 
using System; 
// Обобщенный базовый класс, 
class Gen<T> { 
    protected T ob; 
    public Gen(T о) 
    { 
        ob = о; 
    } 
// Возвратить значение переменной ob. Этот метод является виртуальным. 

    public virtual T GetOb()
    { 
        Console.Write("Метод GetObO из класса Gen" + " возвращает результат: "); 
    return ob; 
    } 
} 
// Класс, производный от класса Gen. В этом классе 
// переопределяется метод GetObO . 
class Gen2<T> : Gen<T> 
{ 
    public Gen2 (T o) : base(o) { } 
    // Переопределить метод GetObO. 
    public override T GetOb() 
    { 
    Console.Write("Метод GetObO из класса Gen2" + " возвращает результат: ") ; 
    return ob; 
    } 
} 
// Продемонстрировать переопределение метода в обобщенном классе, 
class OverrideDemo
{ 
    static void Main()
    { 
        // Создать объект класса Gen с параметром типа int. 
        Gen<int> iOb = new Gen<int> (88); 
        // Здесь вызывается вариант метода GetObO из класса Gen. 
        Console.WriteLine(iOb.GetOb()); 
        //А теперь создать объект класса Gen2 и присвоить 
        // ссылку на него переменной iOb типа Gen<int>. 
        iOb = new Gen2<int>(99); 
        // Здесь вызывается вариант-метода GetObO из класса Gen2. 
        Console.WriteLine (iOb.GetOb() ) ; 
    } 
} 
