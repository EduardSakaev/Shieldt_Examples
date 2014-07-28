// Продемонстрировать контравариантность в обобщенном интерфейсе, 
using System; 
// Это обобщенный интерфейс, поддерживающий контравариантность. 
public interface IMyContraVarGenIF<in T> 
{ 
    void Show(T obj); 
} 
// Реализовать интерфейс IMyContraVarGenlF. 
class MyClass<T> : IMyContraVarGenIF<T> 
{ 
    public void Show(T x) { Console.WriteLine(x); } 
} 
// Создать простую иерархию классов, 
class Alpha 
{ 
    public override string ToString() 
    { 
        return "Это объект класса Alpha."; 
    } 
// ... 
} 

class Beta : Alpha 
{ 
    public override string ToString() 
    { 
    return "Это объект класса Beta."; 
    } 
// ... 
} 
class VarianceDemo
{ 
    static void Main() 
    { 
        //• Создать ссылку из интерфейса IMyContraVarGenIF<Alpha> 
        // на объект типа MyClass<Alpha>. 
        // Это вполне допустимо как при наличии контравариантности, так и без нее. 
        IMyContraVarGenIF<Alpha> AlphaRef = new MyClass<Alpha>(); 
        // Создать ссылку из интерфейса IMyContraVarGenIF<beta> 
        // на объект типа MyClass<Beta>. 
        //И это вполне допустимо как при наличии контравариантности, 
        // так и без нее. 
        IMyContraVarGenIF<Beta> BetaRef = new MyClass<Beta> (); 
        // Создать ссылку из интерфейса IMyContraVarGenIF<beta> 
        // на объект типа MyClass<Alpha>. 
        // *** Это вполне допустимо благодаря контравариантности. *** 
        IMyContraVarGenIF<Beta> BetaRef2 = new MyClass<Alpha>(); 
        // Этот вызов допустим как при наличии контравариантности, так и без нее. 
        BetaRef.Show(new Beta()); 
        // Присвоить переменную AlphaRef переменной BetaRef. 
        // *** Это вполне допустимо благодаря контравариантности. *** 
        BetaRef = AlphaRef; 
        BetaRef.Show(new Beta ()); 
    } 
} 

