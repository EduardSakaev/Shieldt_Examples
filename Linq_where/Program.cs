// Использовать несколько операторов where. 
using System;
using System.Linq;
class TwoWheres
{
    static void Main()
    {
        int[] nums = { 1, -2, 3, -3, 0, -8, 12, 19, 6, 9, 10 };
        // Сформировать запрос на получение положительных значений меньше 10. 
        var posNums = from n in nums
                      where n > 0
                      where n < 10
                      select n;
        Console.Write("Положительные значения меньше 10: ");
        // Выполнить запрос и вывести его результаты. 
        foreach (int i in posNums) Console.Write(i + " ");
        Console.WriteLine();
    }
}
