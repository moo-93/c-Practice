using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _6.BCL
{
    class Program
    {
        static void Main(string[] args)
        {
            string email = "tester@test.com";
            Console.WriteLine(IsEmail(email));
        }

        static bool IsEmail(string email)
        {
            Regex regex =
                new Regex(@"^([0-9a-zA-z]+)@([0-9a-zA-Z]+)(\.[0-9a-zA-Z]+){1,}$");
            return regex.IsMatch(email);
        }
    }
}
