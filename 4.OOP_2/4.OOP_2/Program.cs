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

        }
    }
}
