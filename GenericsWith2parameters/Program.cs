// Простой обобщенный класс с двумя параметрами типа Т и V. 
using System; 

class TwoGen<T, V> 
{ 
    T obi; 
    V ob2; 
    // Обратите внимание на то, что в этом конструкторе 
    // указываются параметры типа Т и V. 
    public TwoGen(T ol, V о2) 
    { 
        obi = ol; 
        ob2 = о2; 
    } 
    // Показать типы Т и V. 
    public void showTypes() 
    { 
        Console.WriteLine("К типу Т относится " + typeof(T)); 
        Console.WriteLine("К типу V относится " + typeof(V)); 
    } 

    public T getobj1() 
    { 
        return obi; 
    } 

    public V Getobj2() 
    { 
        return ob2; 
    } 
} 

// Продемонстрировать применение обобщенного класса с двумя параметрами типа, 
class SimpGen 
{ 
    static void Main() 
    { 
        TwoGen<int, string> tgObj = 
        new TwoGen<int, string>(119, "Альфа Бета Гамма"); 
        // Показать типы. 
        tgObj.showTypes(); 
        // Получить и вывести значения, 
        int v = tgObj.getobj1(); 
        Console.WriteLine("Значение: " + v); 
        string str = tgObj.Getobj2(); 
        Console.WriteLine("Значение: " + str); 
    } 
} 
