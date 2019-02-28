using System;

namespace Avg
{
    class Program
    {
        public static int Average(int[] a)
        {
            double sum = 0;
            foreach(int number in a)
            {
                sum += (double) number;
            }
            var result = Math.Round(sum / (double)a.Length, MidpointRounding.ToEven);
            
            Console.WriteLine(result);
            return (int)result;
        }

        static void Main(string[] args)
        {
            int[] a = new int[] {-2,4,-1,6};
            Average(a);
        }
    }
}
