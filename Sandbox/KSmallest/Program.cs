using System;

namespace KSmallest
{
    class Program
    {
        public static int Ksmallest(int[] a, int k)
        {
            Array.Sort(a);
            Console.WriteLine(a[k]);
            return a[k];
        }

        static void Main(string[] args)
        {
            var a = new int[] {7, 2, 1, 6, 1};
            var k = 3;
            Ksmallest(a, k);
        }
    }
}
