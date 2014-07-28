// Сформировать простой запрос. 
using System; 
using System.Linq; 
using System.Collections.Generic;

class SimpQuery
{ 
static void Main()
    { 
        int[] nums = { 1, -2, 3, 0, -4, 5 };
        // Сформировать простой запрос на получение только положительных значений, 
        var posNums = from n in nums
                      where n > 0
                      select n;
        Console.Write("Положительные значения из массива nums: ");
        // Выполнить запрос и отобразить его результаты. 
        foreach (int i in posNums) Console.Write(i + " ");
        Console.WriteLine();
        // Внести изменения в массив nums. 
        Console.WriteLine("ХпЗадать значение 99 для элемента массива nums[l].");
        nums[1] = 99;
        Console.Write("Положительные значения из массива nums\n" +
        "после изменений в нем: ");
        // Выполнить запрос второй раз. 
        foreach (int i in posNums) Console.Write(i + " ");
        Console.WriteLine();
    }
} 


