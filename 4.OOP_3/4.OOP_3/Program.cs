using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.OOP_3
{
    class Program
    {
        delegate void CalcDelegate(int x, int y);
        static void Add(int x, int y) { Console.WriteLine(x + y); }
        static void Subtract(int x, int y) { Console.WriteLine(x - y); }
        static void Mul(int x, int y) { Console.WriteLine(x * y); }
        static void Div(int x, int y) { Console.WriteLine(x / y); }

        static void Main(string[] args)
        {
            CalcDelegate calc = Add;
            calc += Subtract;
            calc += Mul;
            calc += Div;

            calc(10, 5);
                
            calc -= Div;

            calc(10, 5);

        }
    }
}
