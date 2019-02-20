using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.OOP
{
    class Book
    {
        public string Title;
        public decimal ISBN13;
        public string Contents;
        public string Author;
        public int PageCount;
    }

    class Mathematics
    {
        public int GetAreaOfSquare(int x)
        {
            return x * x;
        }

        public int GetValue()
        {
            return 10;
        }

        public void Output(string prefix, int value)
        {
            Console.WriteLine(prefix + value);
        }
    }

    class Person
    {
        public string name;
        static public int cnt;

        public Person(string name)
        {
            cnt++;
            name = this.name;
        }
    }

    class Person2
    {
        static public Person2 President;
        public string name;

        public Person2(string _name)
        {
            name = _name;
        }

        static Person2()
        {
            President = new Person2("대통령");
        }
    }

    class Circle
    {
        double pi = 3.14;

        public double Pi
        {
            get { return pi; }
            set { pi = value; }
        }
    }

    //sealed class Pen
    //{

    //}
    //class Elec : Pen
    //{
    //    // sealed 예약어를 사용한 클래스는 상속을 의도적으로 막는다.
    //}


    class Program
    {
        static void Main(string[] args)
        {

            // Book
            Book book1 = new Book
            {
                Title = "걸리버 여행기",
                ISBN13 = 9788983920775m,
                Author = "moo",
                Contents = "...",
                PageCount = 384
            };

            Console.WriteLine(book1.ISBN13);

            // Math
            Mathematics mat = new Mathematics();

            int su2 = mat.GetAreaOfSquare(mat.GetValue());
            mat.Output("result: ", su2);

            // person2 정적 클래스
            Person2 p2 = new Person2("test");
            Console.WriteLine(Person2.President.name);
            Console.WriteLine(p2.name);

            //프로퍼티 사용
            Circle o = new Circle();
            o.Pi = 3.14159; //쓰기
            double piValue = o.Pi; //읽기
            Console.WriteLine(piValue);

            Type type = o.GetType();

            Console.WriteLine(type.FullName);
            Console.WriteLine(type.IsClass);
            Console.WriteLine(type.IsArray);
            Console.WriteLine(o.GetType().FullName);

            Type type2 = typeof(double);

            Console.WriteLine(type2.FullName);
            Console.WriteLine(typeof(Circle).FullName);


        }
    } 

}