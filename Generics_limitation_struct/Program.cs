// Продемонстрировать наложение ограничения типа значения. 
using System; 

struct MyStruct{  //... 
} 

class MyClass { 
// ... 
} 

class Test<T> where T : struct 
{ 
    T obj; 
    public Test(T x) 
    { 
        obj = x; 
    } 
// ... 
} 

class ValueConstraintDemo
{ 
    static void Main()
    { 
        // Оба следующих объявления вполне допустимы. 
        Test<MyStruct> x = new Test<MyStruct>(new MyStruct()); 
        Test<int> у = new Test<int>(10); 
        //А следующее объявление недопустимо! 
        // Test<MyClass> z = new Test<MyClass>(new MyClassO); 
    } 
} 
