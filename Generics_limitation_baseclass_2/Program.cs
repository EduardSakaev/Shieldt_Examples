// Более практический пример, демонстрирующий применение 
// ограничения на базовый класс. 
using System; 
// Специальное исключение, генерируемое в том случае, 
// если имя или номер телефона не найдены, 
class NotFoundException : Exception 
{ 
    /* Реализовать все конструкторы класса Exception. 
    Эти конструкторы выполняют вызов конструктора базового класса. 
    Класс NotFoundException ничем не дополняет класс Exception и 
    поэтому не требует никаких дополнительных действий. */ 
    public NotFoundException () : base() 
    { 

    } 
    public NotFoundException(string str) : base(str) { } 
    public NotFoundException( 
    string str,Exception inner) : base(str, inner) { } 
    protected NotFoundException ( 
    System.Runtime.Serialization.SerializationInfo si, 
    System.Runtime.Serialization.StreamingContext sc) : 
    base (si, sc) { } 
} 

// Базовый класс, в котором хранятся имя абонента и номер его телефона, 
class PhoneNumber
{ 
    public PhoneNumber(string n, string num) 
    { 
        Name = n; 
        Number = num; 
    } 

    public string Number { get; set; } 
    public string Name { get; set; } 
} 
// Класс для телефонных номеров друзей, 
class Friend : PhoneNumber 
{ 
    public Friend(string n, string num, bool wk) : base(n, num) 
    { 
        IsWorkNumber = wk; 
    }

    public bool IsWorkNumber { get; private set; }
    // ... 
  } 
// Класс для телефонных номеров поставщиков, 
class Supplier : PhoneNumber
{ 
    public Supplier(string n, string num) : base(n, num) { } 
// ... 
} 
// Этот класс не наследует от класса PhoneNumber. 
class EmailFriend { 
// ... 
} 
// Класс PhoneList способен управлять любым видом списка телефонных номеров, 
// при условии, что он является производным от класса PhoneNumber. 
class PhoneList<T> where T : PhoneNumber 
{ 
    T[] phList; 
    int end; 
    public PhoneList() 
    { 
        phList = new T[10]; 
        end = 0; 
    }
    // Добавить элемент в список. 
    public bool Add(T newEntry) 
    { 
        if(end == 10) return false; 
        phList[end] = newEntry; 
        end++; 
    return true; 
    } 
    // Найти и возвратить сведения о телефоне по заданному имени, 
    public T FindByName(string name) 
    { 
        for(int i=0; i<end; i++) 
        { 
            // Имя может использоваться, потому что его свойство Name 
            // относится к членам класса PhoneNumber, который является 
            // базовым по накладываемому ограничению, 
            if(phList[i].Name == name)  return phList[i]; 
        }

        // Имя отсутствует в списке, 
        throw new NotFoundException(); 
    } 

    // Найти и возвратить сведения о телефоне по заданному номеру. 
    public T FindByNumber(string number) 
    { 
        for(int i=0; i<end; i++)
        { 
                // Номер"* телефона также может использоваться, поскольку 
                // его•свойство Number относится к членам класса PhoneNumber, 
                // который является базовым по накладываемому ограничению, 
            if (phList[i].Number == number) return phList[i];
        }

        // Номер телефона отсутствует в списке. • 
        throw new NotFoundException (); 
    } 
}

// ... 
// Продемонстрировать наложение ограничений на базовый класс, 
class UseBaseClassConstraint
{ 
    static void Main() 
    { 
        // Следующий код вполне допустим, поскольку 
        // класс Friend наследует от класса PhoneNumber. 
        PhoneList<Friend> plist = new PhoneList<Friend>(); 
        plist.Add(new Friend("Том", "55-1234", true)); 
        plist.Add(new Friend("Гари", "55-6756", true)); 
        plist.Add(new Friend("Матт", "55-945", false)); 

        try 
        { 
            // Найти номер телефона по заданному имени друга. 
            Friend frnd = plist.FindByName("Гари") ; 
            Console.Write(frnd.Name + ": " + frnd.Number); 
            if(frnd.IsWorkNumber) 
                Console.WriteLine(" (рабочий)") ; 
            else 
                Console.WriteLine (); 
        } 
        catch(NotFoundException) 
        { 
            Console.WriteLine("He найдено"); 
        } 
        Console.WriteLine(); 
           // Следующий код также допустим, поскольку 
            // класс Supplier наследует от класса PhoneNumber.. 
            PhoneList<Supplier> plist2 = new PhoneList<Supplier>(); 
            plist2.Add(new Supplier("Фирма Global Hardware", "55-8834")); 
            plist2.Add(new Supplier("Агентство Computer Warehouse", "55-9256")); 
            plist2.Add(new Supplier("Компания NetworkCity", "55-2564")); 
            try 
            { 
                // Найти наименование поставщика по заданному номеру телефона. 
                Supplier sp = plist2.FindByNumber("55-2564"); 
                Console.WriteLine(sp.Name + ": " + sp.Number); 
            } 
            catch(NotFoundException) 
            { 
                Console.WriteLine("He найдено"); 
            } 
        // Следующее объявление недопустимо, поскольку 
        // класс EmailFriend HE наследует от класса PhoneNumber. 
        // PhoneList<EmailFriend> plist3 = 
        // new PhoneList<EmailFriend>(); // Ошибка! 
    } 
} 
