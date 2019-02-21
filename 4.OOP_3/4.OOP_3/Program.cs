using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.OOP_3
{

    class Hardware { }
    class USB
    {
        string name;
        public USB(string name) { this.name = name; }

        public override string ToString()
        {
            return name;
        }
    }

    class Notebook : Hardware, IEnumerable
    {
        USB[] usbList = new USB[] { new USB("USB1"), new USB("USB2") };

        public IEnumerator GetEnumerator()
        {
            return new USBEnumerator(usbList);
        }

        public class USBEnumerator : IEnumerator
        {
            int pos = -1;
            int length = 0;
            object[] list;

            public USBEnumerator(USB[] usb)
            {
                list = usb;
                length = usb.Length;
            }

            public object Current // 현재 요소를 반환
            {
                get { return list[pos]; }
            }

            public bool MoveNext() // 다음 순서의 요소를 지정
            {
                if (pos >= length - 1)
                {
                    return false;
                }

                pos++;
                return true;
            }

            public void Reset() // 처음부터 열거하고 싶을 때 호출
            {
                pos = -1;
            }
        }
    }

    struct Vector
    {
        public int x;
        public int y;

        public Vector(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return "x: " + x + " Y: " + y ;
        }
    }

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

            Notebook notebook = new Notebook();
            //foreach (USB usb in notebook)
            //{
            //    Console.WriteLine(usb);
            //}

            IEnumerator enu = notebook.GetEnumerator();

            while (enu.MoveNext())
            {
                Console.WriteLine(enu.Current);
            }

            Vector v1 = new Vector();
            Vector v2;
            v2.x = 0;
            v2.y = 0;

            Vector v3 = new Vector(5, 10);

            Console.WriteLine(v1);
            Console.WriteLine(v2);
            Console.WriteLine(v3);
        }
    }
}
