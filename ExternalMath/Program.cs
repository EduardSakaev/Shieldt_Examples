using System;
using System.Runtime.InteropServices;
class ExternMeth
{
    // Здесь объявляется внешний метод. 
    [DllImport("ExtMeth.dll")]
    public extern static int AbsMax(int a, int b);
    static void Main()
    {
        // Использовать внешний метод, 
        int max = AbsMax(-10, -20);
        Console.WriteLine(max);
    }
}
