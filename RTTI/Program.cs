using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace is_dynamic
{
    class A { }
    class В : A { }

    class Usels
    {
        static void Main()
        {
            A a = new A();
            В b = new В();
            if (a is A)
                Console.WriteLine("а имеет тип A");
            if (b is A)
                Console.WriteLine("b совместим с А, поскольку он производный от А");
            if (a is В)
                Console.WriteLine("He выводится, поскольку а не производный от В");
            if (b is В)
                Console.WriteLine("В имеет тип В");
            if (a is object)
                Console.WriteLine("а имеет тип object");
        }
    } 
}
