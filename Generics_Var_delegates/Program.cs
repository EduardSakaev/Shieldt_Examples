// Продемонстрировать конвариантность и контравариантность 
//в обобщенных делегатах. 
using System; 
// Объявить делегат, контравариантный по отношению к обобщенному типу Т. 
delegate bool SomeOp<in T>(T obj); 
// Объявить делегат, ковариантный по отношению к обобщенному типу Т. 
delegate T AnotherOp<out T, V>(V obj); 

class Alpha 
{ 
    public int Val { get; set; } 
    public Alpha(int v) { Val = v; } 
} 

class Beta : Alpha 
{ 
    public Beta (int v) : base (v) { } 
} 

class GenDelegateVarianceDemo 
{ 
    // Возвратить логическое значение true, если значение 
    // переменной obj.Val окажется четным, 
    static bool IsEven(Alpha obj)
    { 
        if((obj.Val % 2) == 0) return true; 
        return false; 
    } 
    static Beta Changelt(Alpha obj) 
    { 
        return new Beta(obj.Val +2); 
    } 

    static void Main() 
    { 
        Alpha objA = new Alpha(4); 
        Beta objВ = new Beta (9); 
        // Продемонстрировать сначала контравариантность. 
        // Объявить делегат SomeOp<Alpha> и задать для него метод IsEven. 
        SomeOp<Alpha> checklt = IsEven;

        // Объявить делегат SomeOp<Beta>. 
        SomeOp<Beta> checklt2;
        //А теперь- присвоить делегат SomeOp<Alpha> делегату SomeOp<Beta>. 
        // *** Это допустимо только благодаря контравариантности. *** 
        checklt2 = checklt;
        // Вызвать метод через делегат. 
        Console.WriteLine(checklt2(objВ));
        // Далее, продемонстрировать контравариантность. 
        // Объявить сначала два делегата типа AnotherOp. 
        // Здесь возвращаемым типом является класс Beta, 
        //а параметром типа — класс Alpha. 
        // Обратите внимание на то, что для делегата modifylt 
        // задается метод Changelt. 
        AnotherOp<Beta, Alpha> modifylt = Changelt;
        // Здесь возвращаемым типом является класс Alpha, 
        //а параметром типа — тот же класс Alpha. 
        AnotherOp<Alpha, Alpha> modifyIt2;
        // А теперь присвоить делегат modifylt делегату modifyIt2. 
        // *** Это допустимо только благодаря ковариантности. *** 
        modifyIt2 = modifylt;
        // Вызвать метод и вывести результаты на экран. 
        objA = modifyIt2(objA);
        Console.WriteLine(objA.Val);
    }
} 

