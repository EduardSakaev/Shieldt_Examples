// Использовать оператор into вместе с оператором group. 
using System; 
using System.Linq; 
class IntoDemo 
{ 
    static void Main()
    { 
        string[] websites = { "hsNameA.com", "hsNameB.net", "hsNameC.net", 
        "hsNameD.com", "hsNameE.org", "hsNameF.org", 
        "hsNameG.tv", "hsNameH.net", "hsNamel.tv" 
        }; 
        // Сформировать запрос на получение списка веб-сайтов, группируемых 
        //по имени домена самого верхнего уровня, но выбрать только те 
        // группы, которые состоят более чем из двух членов. 
        // Здесь ws — это переменная диапазона для ряда групп, 
        // возвращаемых при выполнении первой половины запроса, 
        var webAddrs = from addr in websites 
        where addr.LastIndexOf('.') != -1 
        group addr by addr.Substring(addr.LastIndexOf('.')) 
        into ws 
        where ws.Count() > 2 
        select ws; 
        // Выполнить запрос и вывести его результаты. 
        Console.WriteLine("Домены самого верхнего уровня " + 
        "с более чем двумя членами.\n"); 
        foreach(var sites in webAddrs) { 
        Console.WriteLine("Содержимое домена: " + sites.Key); 
        foreach(var site in sites) 
        Console.WriteLine(" " + site); 
        Console.WriteLine(); 
        } 
    } 
} 
