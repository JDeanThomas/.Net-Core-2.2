using System;

namespace MaxDiff
{
    class Program
    {

        public static int Difference(int[] a)
        {
            Array.Sort(a);
            var smallest = a[0];
            var largest = a[a.Length - 1];

            Console.WriteLine(largest - smallest);
            return largest - smallest;
        }
        static void Main(string[] args)
        {
            var a = new int[] {3, 2, 9, 5};
            Difference(a);
            
        }
    }
}
