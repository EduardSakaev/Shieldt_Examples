// Сформировать простой запрос LINQ. 
using System;
using System.Linq;
class SimpQuery
{
    static void Main()
    {
        int[] nums = { -1, -2, 3, 0, -4, 5 };
        // Сформировать простой запрос на получение только положительных значений, 
        var posNums = from n in nums
                      where n > 0
                      select n;
        Console.Write("Положительные значения из массива nums: ");
        // Выполнить запрос и отобразить его результаты. 
        foreach (int i in posNums) Console.Write(i + " ");
        Console.WriteLine();
    }
}
