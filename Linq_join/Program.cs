// Продемонстрировать применение оператора join. 
using System; 
using System.Linq; 
// Класс, связывающий наименование товара с его порядковым номером, 
class Item 
{ 
    public string Name { get; set; } 
    public int ItemNumber { get; set; } 
    public Item(string n, int inum) 
    { 
        Name = n; 
        ItemNumber = inum; 
    } 
} 

// Класс, связывающий наименование товара с состоянием его запасов на складе, 
class InStockStatus 
{ 
    public int ItemNumber { get; set; } 
    public bool InStock { get; set; } 
    public InStockStatus(int n, bool b) 
    { 
        ItemNumber = n; 
        InStock = b; 
    } 
} 

// Класс, инкапсулирующий наименование товара и 
// состояние его запасов на складе, 
class Temp
{ 
    public string Name { get; set; } 
    public bool InStock { get; set; } 
    public Temp(string n, bool b)
    { 
        Name = n; 
        InStock = b; 
    } 
} 

class JoinDemo 
{ 
    static void Main() 
    { 
        Item[] items = { 
                            new Item("Кусачки", 1424), 
                            new Item("Тиски", 7892), 
                            new Item("Молоток", 8534), 
                            new Item("Пила", 6411) 
                        }; 

        InStockStatus[] statusList = { 
                            new InStockStatus(1423, true), 
                            new InStockStatus(6544, false), 
                            new InStockStatus(8534, true), 
                            new InStockStatus(8765, true)
                        }; 
        // Сформировать запрос, объединяющий объекты классов Item 
        //и InStockStatus для составления списка наименований товаров 
        // и их наличия на складе. Обратите внимание на формирование 
        // последовательности объектов класса Temp, 
        var inStockList = from item in items 
        join entry in statusList 
        on item.ItemNumber equals entry.ItemNumber 
        select new Temp(item.Name, entry.InStock); 
        Console. WriteLine ("Товар\n наличие\n") ; 
        // Выполнить запрос и вывести его результаты. 
        foreach(Temp t in inStockList) 
        Console.WriteLine("{0}\t{1}", t.Name, t.InStock); 
    } 
}
