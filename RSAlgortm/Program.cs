using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RSAlgortm
{
    class Program
    {
        static void Main(string[] args)
        {
            int primeP,primeQ, n, eulerTo, phi, de=0;
            Random rnd = new Random();

            Console.ForegroundColor = ConsoleColor.Green;
            do
            {
                primeP = rnd.Next(2, 20);

            } while (!IsItPrime(primeP));
            do
            {
                primeQ = rnd.Next(2, 20);

            } while (!IsItPrime(primeQ));

            n = primeP * primeQ;
            phi = EnumeratePhi(primeP, primeQ);
            eulerTo = FindCypherExponentE(phi);

            do
            {
                de++;
            } while ((eulerTo*de)!=(1%phi));

            Console.WriteLine("NUMBER MUST BE BETWEEN 1 AND 16 !!!!!");
            bool errCount = false;
            Console.ReadKey();
        }

        public static int FindCypherExponentE(int phi)
        {
            int e = 0;
            for (int i = 2; i < phi; i++)
            {
                if(GCD(i,phi)==1)
                {
                    e=i;
                break;
                }
            }
            return e;
        }

        public static int EnumeratePhi(int p, int q)
        {
            return ((p - 1) * (q - 1));
        }

        public static int GCD(int a, int b)
        {
            return b == 0 ? a : GCD(b, a % b);
        }

        public static bool IsItPrime(int value)
        {
            for (int i = 2; i < value; i++)
            {
                if ((value % i) == 0)
                {
                    return false;
                }
                
            }
            return true;
        }


    }
}
