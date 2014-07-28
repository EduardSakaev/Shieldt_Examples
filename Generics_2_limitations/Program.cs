// Использовать несколько операторов where. 
using System; 
//У класса Gen имеются два параметра типа, и на оба накладываются 
// ограничения с помощью отдельных операторов where, 
class Gen<T, V> where T : class 
                where V : struct { 
    T obi; 
    V ob2; 
    public Gen(T t, V v)
    { 
        obi = t; 
        ob2 = v; 
    } 
} 
class MultipleConstraintDemo
{ 
    static void Main() 
    { 
        // Эта строка кода вполне допустима, поскольку 
        // string — это ссылочный тип, a int — тип значения. 
        Gen<string, int> obj = new Gen<string, int> ("тест", 11); 
        //А следующая строка кода недопустима, поскольку 
        // bool не относится к ссылочному типу. 
        // Gen<bool, int> obj = new Gen<bool, int>(true, 11); 
    } 
} 
