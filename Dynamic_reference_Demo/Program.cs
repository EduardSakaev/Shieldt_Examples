// Использовать тип dynamic вместе с рефлексией. 
using System; 
using System.Reflection; 
class DynRefDemo
{ 
    static void Main() 
    { 
        Assembly asm = Assembly.LoadFrom("MyClass.dll") ; 
        Type[] all = asm.GetTypes() ; 
        // Найти класс DivBy. 
        int i; 
        for(i =0; i < all.Length; i++) 
        if(all[i].Name == "DivBy") break; 
        if(i == all.Length) { 
        Console.WriteLine("Класс DivBy не найден в сборке."); 
        return; 
        } 
        Type t = all[i]; 
        //А теперь найти используемый по умолчанию конструктор. 
        ConstructorInfo[] ci = t.GetConstructors(); 
        int j ; 
        for(j =0; j < ci.Length; j++) 
        if(ci[j].GetParameters().Length == 0) break; 
        if(j == ci.Length) 
        { 
        Console.WriteLine("Используемый по умолчанию конструктор не найден."); 
        return; 
        }  
        // Создать объект класса DivBy динамически, 
        dynamic obj = ci[j].Invoke(null); 
        // Далее вызвать по имени методы для переменной obj. Это вполне допустимо, 
        // поскольку переменная obj относится к типу dynamic, а вызовы методов 
        // проверяются на соответствие типов во время выполнения, а не компиляции, 
        if(obj.IsDivBy(5, 3)) 
            Console.WriteLine("5 делится нацело на 3."); 
        else 
            Console.WriteLine("5 HE делится нацело на 3.");

        if(obj.IsEven(9)) 
            Console.WriteLine("9 четное число."); 
        else 
            Console.WriteLine("9 HE четное число."); 
    }
}