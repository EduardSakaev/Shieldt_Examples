// Использовать запрос для получения последовательности объектов 
// типа EmailAddresses из списка объектов типа Contactlnfo. 
using System; 
using System.Linq; 

class Contactlnfo 
{ 
    public string Name { get; set; } 
    public string Email { get; set; } 
    public string Phone { get; set; } 
    public Contactlnfo(string n, string a, string p) 
    { 
        Name = n; 
        Email = a; 
        Phone = p; 
    } 
} 

class EmailAddress 
{ 
    public string Name { get; set; } 
    public string Address { get; set; } 
    public EmailAddress(string n, string a)
    { 
        Name = n; 
        Address = a; 
    }
} 

class SelectDemo3
{ 
    static void Main() 
    { 
        Contactlnfo[] contacts = { 
            new Contactlnfo("Герберт", "Herb@HerbSchildt.com", "555-1010"), 
            new Contactlnfo("Tom", "Tom@HerbSchildt.com", "555-1101"), 
            new Contactlnfo("Capa", "Sara@HerbSchildt.com", "555-0110") 
        };
        // Сформировать запрос на получение списка объектов типа EmailAddress. 
        var emailList = from entry in contacts 
        select new EmailAddress(entry.Name, entry.Email); 
        Console.WriteLine("Список адресов электронной почты:"); 
        // Выполнить запрос и вывести его результаты, 
        foreach(EmailAddress e in emailList) 
        Console.WriteLine(" {0}: {1}", e.Name, e.Address ); 
        } 
} 

