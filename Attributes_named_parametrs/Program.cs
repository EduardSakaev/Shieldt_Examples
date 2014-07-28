// Использовать именованный параметр атрибута. 
using System; 
using System.Reflection; 

[AttributeUsage(AttributeTargets.All)] 
public class RemarkAttribute : Attribute 
{ 
    string pri_remark; // базовое поле свойства Remark 
    public string Supplement; // это именованный параметр 
    public RemarkAttribute(string comment) 
    { 
        pri_remark = comment; 
        Supplement = "Отсутствует"; 
    } 

    public string Remark
    { 
        get 
        { 
             return pri_remark; 
        } 
    } 
}

[RemarkAttribute("В этом классе используется атрибут.",
Supplement = "Это дополнительная информация.")]
class UseAttrib
{
    // ... 
}

class NamedParamDemo { 
    static void Main() 
    { 
        Type t = typeof(UseAttrib); 
        Console.Write("Атрибуты в классе " + t.Name + ": "); 
        object[] attribs = t.GetCustomAttributes(false); 
        foreach(object o in attribs)
        { 
            Console.WriteLine (o); 
        } 
        // Извлечь атрибут RemarkAttribute. 
        Type tRemAtt = typeof(RemarkAttribute); 
        RemarkAttribute ra = (RemarkAttribute) 
        Attribute.GetCustomAttribute(t, tRemAtt); 
        Console.Write("Примечание: "); 
        Console.WriteLine(ra.Remark); 
        Console.Write("Дополнение: ") ; 
        Console.WriteLine(ra.Supplement); 
    } 
} 
