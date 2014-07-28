// Класс NonGen является полным функциональным аналогом 
// класса Gen, но без обобщений. 
using System;

class NonGen
{
    object ob; // переменная ob теперь относится к типу object 
    // Передать конструктору ссылку на объект типа object, 
    public NonGen(object о)
    {
        ob = о;
    }
    // Возвратить объект типа object, 
    public object GetOb()
    {
        return ob;
    }
    // Показать тип переменной ob. 
    public void ShowType()
    {
        Console.WriteLine("Тип переменной ob: " + ob.GetType());
    }
    // Продемонстрировать применение необобщенного класса, 
}

class NonGenDemo
{ 
    static void Main() 
    { 
        NonGen iOb; 
        // Создать-объект класса NonGen. 
        iOb = new NonGen(102); 
        // Показать тип данных, хранящихся в переменной iOb. 
        iOb.ShowType(); 
        // Получить значение переменной iOb. 
        //На этот раз потребуется приведение типов. 
        int v = (int) iOb.GetOb(); 
        Console.WriteLine("Значение: " + v); 
        Console.WriteLine(); 
        // Создать еще один объект класса NonGen и 
        // сохранить строку в переменной it. 
        NonGen strOb = new NonGen("Тест на необобщенность"); 
        // Показать тип данных, хранящихся в переменной strOb. 
        strOb.ShowType(); 
        // Получить значение переменной strOb. 
        //Ив этом случае требуется приведение типов. 
        String str = (string) strOb.GetOb() ; 
        Console.WriteLine("Значение: " + str); 
        // Этот код компилируется, но он принципиально неверный! 
        iOb = strOb; 
         //Следующая строка кода приводит к исключительной 
        // ситуации во время выполнения. 
        // v = (int) iOb.GetOb(); // Ошибка при выполнении! 
    }
}
