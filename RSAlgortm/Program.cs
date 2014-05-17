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
            double message, eulerTo = 0, phi;
            int primeP, primeQ, n, de;
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
                        primeP = rnd.Next(2, 5);
                    }
                    else
                    {
                        primeP = rnd.Next(2, 12);
                    }

                } while (!IsItPrime(primeP));
                do
                {
                    if (japepa)
                    {
                        primeQ = rnd.Next(2, 7);
                    }
                    else
                    {
                        primeQ = rnd.Next(2, 12);
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
                } while (de < 30);

            } while (de > 25);//|| de == eulerTo);

            Console.WriteLine("Values - primeP {0}, primeQ {1}, n {2}, e {3}, phi {4}, d {5}", primeP, primeQ, n, eulerTo, phi, de);
            bool errCount = false;
            do
            {
                if (errCount) { Console.WriteLine("NUMBER MUST BE BETWEEN 1 AND 16 !!!!!"); }
                Console.WriteLine("Enter your message (number 1-16) ");
                message = ValidateReadNumber(Console.ReadLine());
                errCount = true;
            } while (message < 0 || message > 17);

            double cryptM, decryptM;

            cryptM = (Math.Pow(message, eulerTo)) % n;
            Console.WriteLine("Crypted message {0}", cryptM);
            decryptM = (Math.Pow(cryptM, de)) % n;
            Console.WriteLine("DeCrypted message {0}", decryptM);

            Console.WriteLine("\nFor end of program press any key");

            Console.ReadKey();
        }

        public static double FindCypherExponentE(double phi)
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

        public static double EnumeratePhi(double p, double q)
        {
            return ((p - 1) * (q - 1));
        }

        public static double GCD(double a, double b)
        {
            return b == 0 ? a : GCD(b, a % b);
        }

        public static bool IsItPrime(double value)
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
