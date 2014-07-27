// Использовать оператор select для возврата квадратных корней всех 
// положительных значений, содержащихся в массиве типа double. 
using System; 
using System.Linq; 

class SelectDemo 
{ 
    static void Main() 
    { 
        double[] nums = 
        { -10.0, 16.4, 12.125, 100.85, -2.2, 25.25, -3.5 }; 
        // Сформировать запрос на получение квадратных корней всех 
        // положительных значений, содержащихся в массиве nums. 
        var sqrRoots = from n in nums 
        where n > 0 
        select Math.Sqrt(n); 
        Console.WriteLine("Квадратные корни положительных значений,\n" + 
        "округленные до двух десятичных цифр:"); 
        // Выполнить запрос и вывести его результаты, 
        foreach(double r in sqrRoots) 
        Console.WriteLine("{0:#.##}", r); 
    } 
} 
