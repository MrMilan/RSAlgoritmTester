using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace RSAlgortm
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger de;
            int primeP, primeQ, n, eulerTo = 0, phi, message;
            Random rnd = new Random();
            bool japepa = true;

            Console.ForegroundColor = ConsoleColor.Green;
            do
            {
                de = 0;
                do
                {
                    if (japepa)
                    {
                        primeP = rnd.Next(2, 17);
                    }
                    else
                    {
                        primeP = rnd.Next(2, 20);
                    }

                } while (!IsItPrime(primeP));
                do
                {
                    if (japepa)
                    {
                        primeQ = rnd.Next(2, 15);
                    }
                    else
                    {
                        primeQ = rnd.Next(2, 20);
                    }

                } while (!IsItPrime(primeQ) || primeP == primeQ);

                n = primeP * primeQ;
                phi = EnumeratePhi(primeP, primeQ);
                eulerTo = FindCypherExponentE(phi);
                if (japepa) { japepa = false; } else { japepa = true; }

                do
                {
                    if (((eulerTo * de) % phi) == (1) && de < phi)
                    { break; }
                    de++;
                } while (de < 4294967296);

            } while (de > 300|| de == eulerTo);

            Console.WriteLine("Values - primeP {0}, primeQ {1}, n {2}, e {3}, phi {4}, d {5}", primeP, primeQ, n, eulerTo, phi, de);
            bool errCount = false;
            do
            {
                if (errCount) { Console.WriteLine("NUMBER MUST BE BETWEEN 1 AND 50 !!!!!"); }
                Console.WriteLine("Enter your message (number 1-50) ");
                message = ValidateReadNumber(Console.ReadLine());
                errCount = true;
            } while (message < 0 || message > 51);

            BigInteger cryptM, decryptM;

            cryptM = BigInteger.ModPow(message, eulerTo,n);
            Console.WriteLine("Crypted message {0}", cryptM);
            decryptM = BigInteger.ModPow(cryptM, de, n);
            Console.WriteLine("DeCrypted message {0}", decryptM);

            Console.WriteLine("\nFor end of program press any key");

            Console.ReadKey();
        }

        public static int FindCypherExponentE(int phi)
        {
            int e = 0;
            for (int i = 2; i < phi; i++)
            {
                if (GCD(i, phi) == 1)
                {
                    e = i;
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
        public static int ValidateReadNumber(string valueNumber)
        {
            int number = 0;
            try
            {
                number = Convert.ToInt32(valueNumber);
            }
            catch (Exception exc)
            {

                throw new ArgumentException("Not valid input" + exc.Message);
            }

            return number;
        }


    }
}
