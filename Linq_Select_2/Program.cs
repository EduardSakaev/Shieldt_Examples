// Возвратить часть значения переменной диапазона. 
using System;
using System.Linq;

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
class SelectDemo2
{
    static void Main()
    {
        EmailAddress[] addrs = { 
                                    new EmailAddress("Герберт", "Herb@HerbSchildt.com"), 
                                    new EmailAddress("Tom", "Tom@HerbSchildt.com"), 
                                    new EmailAddress("Capa", "Sara@HerbSchildt.com") 
                            };
        // Сформировать запрос на получение адресов 
        // электронной почты. 
        var eAddrs = from entry in addrs
                     select entry.Address;
        Console.WriteLine("Адреса электронной почты:");
        // Выполнить запрос и вывести его результаты, 
        foreach (string s in eAddrs)
            Console.WriteLine(" " + s);
    }
}
