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
            int i = n / 2;
            int res = 0;
            if (n <= 0)
            {
                Console.Error.WriteLine("N must be a natural");
                return -1;

            }
            while (i > 0)
            {
                if (n % i == 0)
                {
                    res = res + i;
                    i--;
                }
                else
                {
                    i--;
                }
            }
            return res;
        }

        public static bool PerfectNumber(int c)
        {
            if (c == DivisorSum(c))
            {
                return true;
            }
            return false;
        }
        public static int DecodeBinary(string s)
        {
            int len = s.Length -1;
            int j = 0;
            int num = 0;
            if (s == " ")
                return 0;
            while (len >= 0)
            {
                if (s[len] - '0' == 1)
                {
                    num += Power(2, j);
                    j++;
                    len--;
                    
                }
                else
                {
                    j++;
                    len--;
                }
            }
            return num;
        }

        public static int CrackTheCode(string code)
        {
            int decode = DecodeBinary(code);
            int n = decode;
            while (decode <= n)
            {
                if (decode >= n)
                    return n;
                n--;
            }
            Console.Error.WriteLine("Error : Perfect number not found for this binary");
            return -1;
        }
    }
}