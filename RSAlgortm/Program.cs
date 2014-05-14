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

            FindCypherExponentE(31);
        }

        public static int FindCypherExponentE(int phi)
        {
            int e = 0;
            for (int i = 1; i < phi; i++)
            {
                if(Coprime(i,phi))
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

        public static bool Coprime(int value1, int value2)
        {

            if (value1 > value2)
            {
                if ((value1 %= value2)==1)
                {
                    return true;
                }
                return false;
                
            }
            else
            {
                if((value2 %= value1)==1)
                {
                    return true;
                }
                return false;
            }
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
