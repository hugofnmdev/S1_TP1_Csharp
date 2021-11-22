using System;

namespace Case1_HangedMan.Basics
{
    public static class Loops
    {
        public static ulong Factorial(ulong n)
        {
            ulong res = 1;
            if (n == 0)
            {
                res = 1;
            }
            else
            {
                while (n > 0)
                {
                    res = res * n;
                    n = n - 1;
                }   
            }
            return res;
        }

        public static int Power(int a, int b)
        {
            int res = 1;
            while (b > 0)
            {
                res = res * a;
                b = b - 1;
            }
            return res;
        }
        
        public static int DivisorSum(int n)
        {
            int res = 1;
            if (n <= 0)
            {
                Console.Error.WriteLine("N must be positive");
                return -1;
            }
            else
            {
                while (n >= 0)
                {
                    Console.WriteLine('b');
                }
            }
            return res;
        }

        public static bool PerfectNumber(int c)
        {
            // TODO remove this
            throw new NotImplementedException();
        }
        public static int DecodeBinary(string s)
        {
            int res = 0;
            int n = Convert.ToInt32(s);
            int len = s.Length;
            int i = len;
            if (s == "")
            {
                res = 0;
            }
            else
            {
                while (i>=len)
                {
                    res = (n % 10) * Power(10, i);
                    i = i - 1;
                }
            }
            return res;
        }
        
        public static int CrackTheCode(string code)
        {
            // TODO remove this
            throw new NotImplementedException();
        }
    }
}