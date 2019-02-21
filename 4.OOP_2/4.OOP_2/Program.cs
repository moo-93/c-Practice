using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.OOP_2
{
    class Book
    {
        string title;
        string sibn13;
        string author;

        public Book(string title) : this(title, string.Empty,string.Empty)
        {
            Console.WriteLine(this.title + this.sibn13);
        }
        public Book(string title, string sibn13, string author)
        {
            this.title = title;
            this.sibn13 = sibn13;
            this.author = author;
        }
    }

    class Mammal
    {
        public void Move()
        {
            Console.WriteLine("이동한다.");
        }
    }
    
    class Lion : Mammal
    {
        public void Move()
        {
            Console.WriteLine("네발로 이동한다.");
        }
    }

    class Whale : Mammal
    {
        new public void Move()
        {
            Console.WriteLine("수영한다");
        }
    }

    class Human : Mammal
    {
        public void Move()
        {
            Console.WriteLine("두발로 이동한다.");
        }
    }

    public class Currency
    {
        decimal money;
        public decimal Money { get { return money; } }

        public Currency(decimal money)
        {
            this.money = money;
        }
    }

    public class Won : Currency
    {
        public Won(decimal money) : base(money){ }

        public override string ToString()
        {
            return Money + "원";
        }
    }

    public class Yen : Currency
    {
        public Yen(decimal money) : base(money) { }

        public override string ToString()
        {
            return Money + "엔";
        }

        static public implicit operator Won(Yen yen)
        {
            return new Won(yen.Money * 10m);
        }
    }

    public class Dollar : Currency
    {
        public Dollar(decimal money) : base(money) { }

        public override string ToString()
        {
            return Money + "달러";
        }
    }

    class Program
    {
        private static void OutputArrayInfo(Array arr)
        {
            Console.WriteLine("배열의 차원 수: " + arr.Rank);
            Console.WriteLine("배열의 요소 수: " + arr.Length);
            Console.WriteLine();
        }

        private static void OutputArrayElements(string title, Array arr)
        {
            Console.WriteLine("[" + title + "]");

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr.GetValue(i) + ",");
            }
            Console.WriteLine();
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            bool[,] boolArray = new bool[,] { { true, false }, { false, false } };
            OutputArrayInfo(boolArray);

            int[] intArray = new int[] { 5, 4, 3, 2, 1, 0 };
            OutputArrayInfo(intArray);

            OutputArrayElements("원본 intArray", intArray);
            Array.Sort(intArray);
            OutputArrayElements("Array.Sort 후 intArray", intArray);

            int[] copyArray = new int[intArray.Length];
            Array.Copy(intArray, copyArray, intArray.Length);

            OutputArrayElements("intArrays로부터 복사된 copyArray", copyArray);

            Book book = new Book("test");

            Lion lion = new Lion();
            lion.Move();
            Mammal one = lion;
            one.Move();

            Whale whale = new Whale();
            whale.Move();

            Human human = new Human();
            human.Move();

            Console.WriteLine();

            Won won = new Won(1000);
            Dollar dollar = new Dollar(1);
            Yen yen = new Yen(13);

            Console.WriteLine(won.ToString());
            Console.WriteLine(dollar.ToString());
            Console.WriteLine(yen.ToString());

            Won won2 = yen;
            Console.WriteLine(won2);
        }
    }
}
