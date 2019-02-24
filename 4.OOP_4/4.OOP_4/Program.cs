using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.OOP_4
{

    class PrimeCallbackArg : EventArgs // 콜백 값을 담는 클래스 정의
    {
        public int Prime;

        public PrimeCallbackArg(int Prime)
        {
            this.Prime = Prime;
        }
    }

    // 소수 생성기: 소수가 발생할 때마다 등록된 콜백 메서드 호출
    class PrimeGenerator
    {
        public event EventHandler PrimeGenerated;

        // 소수 발견되면 콜백 메서드 호출
        public void Run(int limit)
        {
            for (int i = 2; i <= limit; i++)
            {
                if (IsPrime(i) == true && PrimeGenerated != null)
                {
                    // 콜백을 발생시킨 측의 인스턴스와 발견된 소수를 콜백 메서드에 전달
                    PrimeGenerated(this, new PrimeCallbackArg(i));
                }
            }
        }

        // 소수 판정 메서드
        private bool IsPrime(int candidate)
        {
            if ((candidate & 1) == 0)
            {
                return candidate == 2;
            }

            for (int i = 3; (i * i) <= candidate; i++)
            {
                if ((candidate % i) == 0) return false;
            }

            return candidate != 1;
        }
    }




    class Program
    {
        // 콜백으로 등록될 메서드 1
        static void PrintPrime(object sender, EventArgs arg)
        {
            Console.Write((arg as PrimeCallbackArg).Prime + ", ");
        }

        static int Sum;

        // 콜백으로 등록될 메서드 2
        static void SumPrime(object sender, EventArgs arg)
        {
            Sum += (arg as PrimeCallbackArg).Prime;
        }
        static void Main(string[] args)
        {
            PrimeGenerator gen = new PrimeGenerator();

            gen.PrimeGenerated += PrintPrime;
            gen.PrimeGenerated += SumPrime;

            gen.Run(10);
            Console.WriteLine();
            Console.WriteLine(Sum);

            gen.PrimeGenerated -= SumPrime;
            gen.Run(15);
        }
    }
}
