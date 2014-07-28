// Продемонстрировать применение оператора orderby. 
using System;
using System.Linq;
class OrderbyDemo
{
    static void Main()
    {
        int[] nums = { 10, -19, 4, 7, 2, -5, 0 };
        // Сформировать запрос на получение значений в отсортированном порядке, 
        var posNums = from n in nums
                      orderby n descending
                      select n;
        Console.Write("Значения по нарастающей: ");
        // Выполнить запрос и вывести его результаты. 
        foreach (int i in posNums) Console.Write(i + " ");
        Console.WriteLine();
    }
}
