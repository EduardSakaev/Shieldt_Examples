// Сортировать результаты запроса по нескольким 
// критериям, используя оператор orderby. 
using System; 
using System.Linq; 

class Account 
{ 
    public string FirstName { get; private set; } 
    public string LastName { get; private set; } 
    public double Balance { get; private set; } 
    public string AccountNumber { get; private set; } 
    public Account(string fn, string In, string accnum, double b) { 
        FirstName = fn; 
        LastName = In; 
        AccountNumber = accnum; 
        Balance = b; 
    }
}

class OrderbyDemo 
{ 
    static void Main() 
    { 
        // Сформировать исходные данные. 
        Account[] accounts = 
        {  
            new Account("Tom", "Смит", "132CK", 100.23),
            new Account("Том", "Смит", "134CD", 10000.00),
            new Account("Ральф", "Джонс", "36CD", 1923.85), 
            new Account("Ральф", "Джонс", "54ММ", 987.132), 
            new Account("Тед", "Краммер", "897CD", 3223.19), 
            new Account("Ральф", "Джонс", "34СК", -123.32), 
            new Account("Сара", "Смит", "43ММ", 5017.40), 
            new Account("Сара", "Смит", "47CD", 34955.79), 
            new Account("Сара", "Смит", "843СК", 345.00), 
            new Account("Альберт", "Смит", "45СК", -213.67), 
            new Account("Бетти", "Краммер","968ММ",5146.67), 
            new Account("Карл", "Смит", "78CD", 15345.99), 
            new Account("Дженни", "Джонс", "8СК", 10.98) 
        }; 
        // Сформировать запрос на получение сведений о 
        // банковских счетах в отсортированном порядке. 
        // Отсортировать эти сведения сначала по имени, затем 
        //по фамилии и, наконец, по остатку на счете. 
        var acclnfo = from асc in accounts 
                      orderby  асc.Balance 
                      select асc; 

        Console.WriteLine("Счета в отсортированном порядке: "); 
        string str = ""; 
        // Выполнить запрос и вывести его результаты, 
        foreach(Account асc in acclnfo)
        { 
                if(str != асc.FirstName) 
                { 
                    Console.WriteLine(); 
                    str = асc.FirstName; 
                    Console.WriteLine("{0}, {1}\t HoMep счета: {2}, {3,10:C}",  
                    асc.LastName, асc.FirstName, 
                    асc.AccountNumber, асc.Balance); 
                } 
            Console.WriteLine(); 
        }
    }
} 

