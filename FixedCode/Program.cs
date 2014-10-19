

using System;
class Test
{
    public int num;
    public Test(int i) { num = i; }
}

class FixedCode
{
    // Пометить метод Main() как небезопасный, 
    unsafe static void Main() 
    { 
        Test o = new Test(19); 

        fixed (int* p = &o.num) 
        { // использовать модификатор fixed для размещения 
            // адреса переменной экземпляр о.num в переменной р 
            Console.WriteLine("Исходное значение п  еременной о.num: " + *p); 
            *p = 10; // присвоить значение 10 переменной count, 
            //на которую указывает переменная р 
            Console.WriteLine("Новое значение переменной о.num: " + *p); 
         } 
     }
}
