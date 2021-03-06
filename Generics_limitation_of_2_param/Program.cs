﻿// Установить связь между двумя параметрами типа. 
using System;
class A
{
    //... 
}
class B : A
{
    // ... 
}
// Здесь параметр типа V должен наследовать от параметра типа Т. 
class Gen<T, V> where V : T
{
    // ... 
}
class NakedConstraintDemo
{
    static void Main() 
    { 
        // Это объявление вполне допустимо, поскольку 
        // класс В наследует от класса А. 
        Gen<A, B> х = new Gen<A, B> () ; 
        //А это объявление недопустимо, поскольку 
        // класс А не наследует от класса В... 
        //Gen<B, A> у = new Gen<B, A>(); 
    }
}
