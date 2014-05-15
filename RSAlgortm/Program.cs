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
            IsItPrime(17);

            FindCypherExponentE(80);
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
