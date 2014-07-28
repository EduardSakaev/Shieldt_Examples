// Продемонстрировать наложение ограничения new() на конструктор. 
using System; 

class MyClass 
{ 
    public MyClass() { 
    // ... 
    } 
    //... 
} 

class Test<T> where T : new()
{ 
    T obj; 
    public Test() 
    { 
        // Этот код работоспособен благодаря наложению ограничения new(). 
        obj = new T(); // создать объект типа Т 
    } 
// ... 
} 


class ConsConstraintDemo { 
    static void Main() { 
        Test<MyClass> x = new Test<MyClass>(); 
    } 
} 
