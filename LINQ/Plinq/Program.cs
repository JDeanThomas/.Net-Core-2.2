using System;
using System.Linq;
using System.Threading.Tasks;

namespace Plinq
{
    class Program
    {

        static void Main(string[] args) {
            var source = Enumerable.Range(0, 20).ToList();

            // TPL version
            Parallel.ForEach(source, (item) => {
                Console.Write($"{item.ToString().PadLeft(2, '0')}|");
            });

            Console.WriteLine();
            Console.WriteLine("======================");

            // PLINQ version
            source.AsParallel().ForAll((item) => {
                Console.Write($"{item.ToString().PadLeft(2, '0')}|");
            });
        }        

        /* 
        static void Main(string[] args) 
        {
            int[] source = Enumerable.Range(0, 20).ToArray();
            var query1 = source.AsParallel().AsOrdered()
                .Where(n => n % 2 == 1).Select(n => -n);
            var query2 = source.AsParallel().AsOrdered()
                .Where(n => n % 2 == 1).AsUnordered().Select(n => -n);

            Console.WriteLine(string.Join(", ", query1));
            Console.WriteLine(string.Join(", ", query2));
        }
        */

        /* 
        static void Main(string[] args) 
        {
            int[] source = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var query1 = source
                .Where(n => n % 2 == 1).Select(n => -n);
            var query2 = source.AsParallel()
                .Where(n => n % 2 == 1).Select(n => -n);

            Console.WriteLine(string.Join(", ", query1));
            Console.WriteLine(string.Join(", ", query2));
        }
        */
    }
}
