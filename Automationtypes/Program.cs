// Использовать класс MyClass, ничего не зная о нем заранее. 
using System; 
using System.Reflection; 

class ReflectAssemblyDemo 
{ 
    static void Main() 
    { 
        int val; 
        Assembly asm = Assembly.LoadFrom("Assembly_1.exe"); 
        Type[] alltypes = asm.GetTypes(); 
        Type t = alltypes[0]; // использовать первый обнаруженный класс 
        Console.WriteLine("Использовано: " + t.Name); 
        ConstructorInfo [] ci = t.GetConstructors () ; 
        // Использовать первый обнаруженный конструктор. 
        ParameterInfo[] cpi = ci[0] .GetParameters (); 
        object reflectOb; 
        if (cpi.Length > 0) 
        { 
            object[] consargs = new object[cpi.Length]; 
            // Инициализировать аргументы. 
            for(int n=0; n < cpi.Length; n++) 
            consargs[n] = 10 + n * 20; 
            // Сконструировать объект. 
            reflectOb = ci[0].Invoke(consargs); 
        } 
        else reflectOb = ci[0].Invoke(null); 
        Console.WriteLine("ХпВызов методов для объекта reflectOb."); 
        Console.WriteLine() ; 
        // Игнорировать наследуемые методы. 
        MethodInfo[] mi = t.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public); 
        // Вызвать каждый метод, 
        foreach(MethodInfo m in mi) 
        { 
            Console.WriteLine("Вызов метода {0} ", m.Name); 
            // Получить параметры. 
            ParameterInfo[] pi = m.GetParameters() ; 
            // Выполнить методы, 
            switch(pi.Length) { 
            case 0: // аргументы отсутствуют 
                    if(m.ReturnType == typeof(int)) 
                    { 
                        val = (int) m.Invoke(reflectOb, null); 
                        Console.WriteLine("Результат: " + val); 
                    } 
                    else if (m.ReturnType == typeof (void) ) 
                    { 
                        m.Invoke(reflectOb, null); 
                    } 
                    break; 
        case 1: // один аргумент 
            if (pi[0] .ParameterType == typeof(int)) { 
            object[] args = new object[1]; 
            args[0] = 14; 
            if((bool) m.Invoke(reflectOb, args)) 
            Console.WriteLine ("Значение 14 находится между х и у"); 
            else 
            Console.WriteLine ("Значение 14 не находится между х и у"); 
            } 
            break; 
        case 2: // два аргумента 
            if ( (pi[0] .ParameterType == typeof(int)) && (pi[1].ParameterType == typeof(int)))
            { 
                object[] args = new object[2]; 
                args[0] = 9; 
                args[1] = 18; 
                m.Invoke(reflectOb, args); 
            } 
            else if((pi[0].ParameterType == typeof(double)) && (pi[1].ParameterType == typeof(double))) 
            { 
                object[] args = new object[2]; 
                args[0] = 1.12; 
                args[1] = 23.4; 
                m.Invoke(reflectOb, args); 
            } 
            break; 
        } 
        Console.WriteLine(); 
        } 
    } 
} 
