// Продемонстрировать применение оператора group. 
using System; 
using System.Linq; 
class GroupDemo
{ 
    static void Main()
    { 
        string[] websites     = {   
                                    "hsNameA.com", 
                                    "hsNameD.com", 
                                    "hsNameG.tv", 
                                    "hsNameB.net", 
                                    "hsNameE.org", 
                                    "hsNameH.net", 
                                    "hsNameC.net", 
                                    "hsNameF.org", 
                                    "hsNamel.tv"  
                                }; 

    // Сформировать запрос на получение списка веб-сайтов, 
    // группируемых по имени домена самого верхнего уровня. 
        var webAddrs = from addr in websites 
        where addr.LastIndexOf('.') != -1 
        group addr by addr.Substring(addr.LastIndexOf('.')); 
        // Выполнить запрос и вывести его результаты, 
        foreach(var sites in webAddrs) 
        { 
            Console.WriteLine("Веб-сайты, сгруппированные " + 
            "по имени домена" + sites.Key); 
            foreach(var site in sites) 
            Console.WriteLine(" " + site); 
            Console.WriteLine(); 
        } 
    } 
} 

