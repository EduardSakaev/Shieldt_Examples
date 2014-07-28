// Продемонстрировать применение обобщенного метода. 
using System; 
// Класс обработки массивов. Этот класс не является обобщенным, 
class ArrayUtils { 
    // Копировать массив, вводя по ходу дела новый элемент. 
    // Этот метод является обобщенным. 
    public static bool CopyInsert<T> (T e, uint idx, T[] src, T[] target)
    { 
        // Проверить, насколько велик массив, 
        if(target.Length < src.Length+1) 
            return false; 
        // Скопировать содержимое массива src в целевой массив, 
        // попутно введя значение е по- индексу idx. 
        for(int i=0, j=0; i < src.Length; i++, j++) 
        { 
            if(i == idx) 
            { 
                target[j] = e; 
                j++; 
            } 
            target[j] = src[i]; 
        } 
        return true; 
    } 
} 

class GenMethDemo 
{ 
    static void Main() 
    { 
        int[] nums = { 1, 2, 3 }; 
        int[] nums2 = new int[4]; 
        // Вывести содержимое массива nums. 
        Console.Write("Содержимое массива nums: "); 
        foreach(int x in nums) 
            Console.Write(x + " "); 
        Console.WriteLine() ; 
        // Обработать массив типа int. 
        ArrayUtils.CopyInsert(99, 2, nums, nums2); 
        // Вывести содержимое массива nums2. 
        Console.Write("Содержимое массива nums2: "); 
        foreach(int x in nums2) 
             Console.Write(x + " "); 
        Console.WriteLine(); 
        //А теперь обработать массив строк, используя метод copylnsert. 
        string[] strs = {"Обобщения", "весьма", "эффективны."}; 
        string[] strs2 = new string[4]; 
        // Вывести содержимое массива strs. 
        Console.Write("Содержимое массива strs: "); 
        foreach(string s in strs) 
        Console.Write(s + " "); 
        Console.WriteLine(); 
        // Ввести элемент в массив строк. 
        ArrayUtils.CopyInsert("в С#", 1, strs, strs2); 
        // Вывести содержимое массива strs2. 
        Console.Write("Содержимое массива strs2: "); 
        foreach(string s in strs2) 
        Console.Write(s + " "); 
        Console.WriteLine() ; 
        //. Этот вызов недопустим, поскольку первый аргумент 
        // относится к типу double, а третий и четвертый 
        // аргументы обозначают элементы массивов типа int. 
        // ArrayUtils.Copylnsert@.01, 2, nums, nums2); 
    } 
} 
