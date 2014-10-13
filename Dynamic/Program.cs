using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization; 


namespace Dynamic
{
    class Program
    {
        static void Main(string[] args)
        {
            // Объявить две динамические переменные, 
            dynamic str; 
            dynamic val; 
            // Поддерживается неявное преобразование в динамические типы. 
            // Поэтому следующие присваивания вполне допустимы, 
            str = "Это строка"; 
            val = 10; 
            
            Console.WriteLine("Переменная str содержит: " + str); 
            Console.WriteLine("Переменная val содержит: " + val + '\n'); 
            str = str.ToUpper(CultureInfo.CurrentCulture); 
            Console.WriteLine("Переменная str теперь содержит: " + str); 
            val = val + 2;
            Console.WriteLine("Переменная val теперь содержит: " + val + '\n'); 
            string str2 = str.ToLower(CultureInfo.CurrentCulture); 
            Console.WriteLine("Переменная str2 содержит: " + str2); 
            // Поддерживаются неявные преобразования из динамических типов. 
            int х = val * 2;
            Console.WriteLine("Переменная x содержит: " + х); 

        }
    }
}
