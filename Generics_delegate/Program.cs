// Простой пример обобщенного делегата. 
using System; 
// Объявить обобщенный делегат, 
delegate T SomeOp<T>(T v); 
class GenDelegateDemo
{ 
    // Возвратить результат суммирования аргумента, 
    static int Sum(int v) 
    { 
        int result = 0; 
        for(int i=v; i>0; i--) 
            result += i; 
        return result; 
    } 
    // Возвратить строку, содержащую обратное значение аргумента, 
    static string Reflect(string str)
    { 
        string result = ""; 
        foreach(char ch in str) 
        result = ch + result; 
        return result; 
    } 

    static void Main() 
    { 
        // Сконструировать делегат типа int. 
        SomeOp<int> intDel = Sum; 
        Console.WriteLine(intDel(3)); 
        // Сконструировать делегат типа string. 
        SomeOp<string> strDel = Reflect; 
        Console.WriteLine(strDel("Привет") ) ; 
    } 
} 
