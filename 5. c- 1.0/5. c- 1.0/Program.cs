using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.c__1._0
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Environment.Version);

            //string txt = Console.ReadLine();

            //if(string.IsNullOrEmpty(txt) == false)
            //{
            //    Console.WriteLine("사용자 입력 : " + txt);
            //}

            string txt = ConfigurationSettings.AppSettings["AdminEmailAddress"];
            Console.WriteLine(txt);

            txt = ConfigurationSettings.AppSettings["Delay"];
            int delay = int.Parse(txt);
            Console.WriteLine(delay);
        }
    }
}
