using System;
using System.Linq;
using System.Collections.Generic;

namespace LinqApp
{
    class Program
    {

        static void Main(string[] args) {
            var records = DataLoader.Load(@"./data");
            var maleTop20 = records
                .Where(r => r.Gender == Gender.Male && r.Rank <= 20);
            var alphabet = Enumerable.Range('A', 26).Select(e => (char)e);

            var result = Enumerable.GroupJoin(
                alphabet, maleTop20,
                c => c, r => r.Name[0],
                (c, g) => (Start: c, Names: String.Join(",", g.Select(r => r.Name)))
            );

            foreach (var item in result) {
                Console.WriteLine($"{item.Start}: {item.Names}");
            }
        }

        /* 
        static void Main(string[] args) {
            var records = DataLoader.Load(@"./data");
            var maleTop5 = records
                .Where(r => r.Gender == Gender.Male && r.Rank <= 5);
            var femaleTop5 = records
                .Where(r => r.Gender == Gender.Female && r.Rank <= 5);

            var result = Enumerable.Join(
                    maleTop5, femaleTop5,
                    r => r.Rank, r => r.Rank,
                    (mr, fr) => (Rank: mr.Rank, Male: mr.Name, Female: fr.Name)
                );

            System.Console.WriteLine($"Rank\tMale\tFemale");
            foreach (var item in result) {
                System.Console.WriteLine($"{item.Rank}\t{item.Male}\t{item.Female}");
            }
        }
        */

        /* 
        static void Main(string[] args) {
            var records = DataLoader.Load(@"C:\Projects");
            var femaleTop30 = records
                .Where(r => r.Rank <= 30 && r.Gender == Gender.Female)
                .OrderBy(r => r.Name);

            var result1 = femaleTop30.GroupBy(r => r.Name[0], r => r.Name)
                .Select(g => (Key: g.Key, Count: g.Count(), Names: String.Join(",", g)));

            var result2 = from r in femaleTop30 group r.Name by r.Name[0] into g
                        select (Key: g.Key, Count: g.Count(), Names: String.Join(",", g));

            foreach (var e in result1) {
                Console.WriteLine($"Key:{e.Key} Count:{e.Count} Names:{e.Names}");
            }
        }
        */

        /* 
        static void Main(string[] args) {
            double[] source = { 1.0, 2.0, 3.0, 4.0, 5.0, 6.0 };
            var max = source.Max();
            var min = source.Min();
            var sum = source.Sum();
            var count = source.Count();
            var longCount = source.LongCount();
            var avg = source.Average();
            var result = source
                .Aggregate((variance: 0.0, avg: source.Average(), count: source.Count()),
                (acc, e) => {
                    acc.variance += Math.Pow(e - acc.avg, 2) / acc.count;
                    return acc;
                });

            Console.WriteLine($"{max.GetType().Name} {max}");
            Console.WriteLine($"{min.GetType().Name} {min}");
            Console.WriteLine($"{sum.GetType().Name} {sum}");
            Console.WriteLine($"{count.GetType().Name} {count}");
            Console.WriteLine($"{longCount.GetType().Name} {longCount}");
            Console.WriteLine($"{avg.GetType().Name} {avg}");
            Console.WriteLine($"{result.variance.GetType().Name} {result.variance}");
        }
        */

        /* 
        class StringEqualityComparer : IEqualityComparer<string> {
            public bool Equals(string x, string y) {
                return String.Compare(x, y, true) == 0;
            }

            public int GetHashCode(string obj) {
                return obj.GetHashCode();
            }
        }

        class Program {
            static void Main(string[] args) {
                string[] lower = { "aaa", "bbb", "ccc" };
                string[] upper = { "AAA", "BBB", "CCC" };
                var r1 = lower.SequenceEqual(upper);
                var r2 = lower.SequenceEqual(upper, new StringEqualityComparer());
                System.Console.WriteLine(r1);
                System.Console.WriteLine(r2);
            }
        }
        */

        /* 
        static void Main(string[] args) 
        {
            var records = DataLoader.Load(@"./data");
            var maleTop100 = records
                .Where(r => r.Rank <= 100 && r.Gender == Gender.Male);
            var list = maleTop100.ToList();
            var array = maleTop100.ToArray();
            var set = maleTop100.ToHashSet();
            var dict = maleTop100.ToDictionary(r => r.Name, r => r.Rank);
            var lookup = maleTop100.ToLookup(r => (r.Rank - 1) / 10, r => r.Name);

            // Check collection type
            System.Console.WriteLine(maleTop100.GetType());
            System.Console.WriteLine(list.GetType());
            System.Console.WriteLine(array.GetType());
            System.Console.WriteLine(set.GetType());
            System.Console.WriteLine(dict.GetType());
            System.Console.WriteLine(lookup.GetType());
            System.Console.WriteLine(lookup.First().GetType());

            System.Console.WriteLine("=======================");

            // Check values
            System.Console.WriteLine(dict["Timothy"]);
            System.Console.WriteLine(String.Join(",", lookup[0]));
        }
        */

        /* 
        static void Main(string[] args) 
        {
            var arrayList = new ArrayList() { 100, 200, 300, 400 };
            var nums = arrayList.Cast<int>();
            System.Console.WriteLine(nums is IEnumerable<int>);
            System.Console.WriteLine(String.Join(",", nums));
        }
        */

        /*
        static void Main(string[] args) 
        {
            var defaultGift = "Programming Books";
            string[] wishlist = { "Toy Car", "Video Games", "Skateboard" };
            string[] storeInventory = { "Computer", "Candy", "Flowers" };
            var iGot = wishlist.Intersect(storeInventory).DefaultIfEmpty(defaultGift);

            foreach (var gift in iGot) {
                System.Console.WriteLine(gift);
            }
        }
        */

        /*
        static void Main(string[] args) 
        {
            var r1 = Range(0, 9);
            var r2 = Range(9, 0);

            Console.WriteLine(String.Join(",", r1));
            Console.WriteLine(String.Join(",", r2));
        }

        static IEnumerable<int> Range(int start, int end) {
            if (start <= end) {
                return Enumerable.Range(start, end - start + 1);
            } else {
                return Enumerable.Empty<int>();
            }
        }
        */

        /*
        static void Main(string[] args) 
        {
            var r1 = Enumerable.Repeat("Hello", 5);
            var r2 = Enumerable.Range(0, 10);
            var r3 = Enumerable.Range(0, 10).Select(e => Math.Pow(2, e));
            var r4 = Enumerable.Range('A', 26).Select(e => (char)e);

            Console.WriteLine(String.Join(",", r1));
            Console.WriteLine(String.Join(",", r2));
            Console.WriteLine(String.Join(",", r3));
            Console.WriteLine(String.Join(",", r4));
        }
        */

        /*
        static void Main(string[] args) 
        {
            string[] source = { "A1", "B1", "C1", "A2", "B2", "C2" };
            var r1 = source.TakeWhile(e => e.StartsWith("A"));
            var r2 = source.TakeWhile(e => !e.StartsWith("C"));
            var r3 = source.TakeWhile(e => e.StartsWith("C"));
            var r4 = source.SkipWhile(e => e.StartsWith("A"));
            var r5 = source.SkipWhile(e => !e.StartsWith("C"));
            var r6 = source.SkipWhile(e => e.StartsWith("C"));

            Console.WriteLine(String.Join(",", r1));
            Console.WriteLine(String.Join(",", r2));
            Console.WriteLine(String.Join(",", r3));
            Console.WriteLine(String.Join(",", r4));
            Console.WriteLine(String.Join(",", r5));
            Console.WriteLine(String.Join(",", r6));
        }
        */

        /*
        static void Main(string[] args) 
        {
            string[] source = { "A1", "A2", "B1", "B2", "C1", "C2" };
            var r1 = source.Take(3);
            var r2 = source.Take(100);
            var r3 = source.Skip(2);
            var r4 = source.Skip(100);
            var r5 = source.Skip(2).Take(2);
            var r6 = source.TakeLast(2);
            var r7 = source.TakeLast(100);

            Console.WriteLine(String.Join(",", r1));
            Console.WriteLine(String.Join(",", r2));
            Console.WriteLine(String.Join(",", r3));
            Console.WriteLine(String.Join(",", r4));
            Console.WriteLine(String.Join(",", r5));
            Console.WriteLine(String.Join(",", r6));
            Console.WriteLine(String.Join(",", r7));
        }
            */

        /*
        static void Main(string[] args) {
            
            var record = DataLoader.Load(@"./data");
            var dict = new Dictionary<string, IEnumerable<Record>>();
            dict["FemaleTop5"] = records.Where(r => r.Rank <= 5 && r.Gender == Gender.Female);
            dict["MaleTop5"] = records.Where(r => r.Rank <= 5 && r.Gender == Gender.Male);

            // Fluent API approach
            var names2 = new List<string>();
            var selectManyResult = dict.SelectMany(kvp => kvp.Value);
            foreach (var r in selectManyResult) {
                names2.Add(r.Name);
            }

            // Query Expression approach (more parsimonious)
            var names3 =
                from kvp in dict
                from r in kvp.Value
                select r.Name;
        }
        */

        /* Value tuple version
        static void Main(string[] args) 
        {
            var record = DataLoader.Load(@"./data");
            var items = records.Select(r => (r.Rank, r.Name));
            foreach (var item in items) 
            {
                // System.Console.WriteLine(item.GetType());
                System.Console.WriteLine($"Rank:{item.Rank} Name:{item.Name}");
            }
        }
        */
        
        /* Anonymous type version
        static void Main(string[] args) 
        {
            var record = DataLoader.Load(@"./data");
            var items = records.Select(r => new { Rank = r.Rank, Name = r.Name });
            foreach (var item in items) {
                // System.Console.WriteLine(item.GetType());
                System.Console.WriteLine($"Rank:{item.Rank} Name:{item.Name}");
            }
        }
        */

        /*
        class RankAndName 
        {
            public int Rank { get; set; }
            public string Name { get; set; }
        }

        class Program 
        {
            static void Main(string[] args) 
            {
                var record = DataLoader.Load(@"./data");
                var items = records.Select(r => new RankAndName { Rank = r.Rank, Name = r.Name });
                foreach (var item in items) {
                    System.Console.WriteLine($"Rank:{item.Rank} Name:{item.Name}");
                }
            }
        }
        */        
        
        /*
        class RecordComparer : IComparer<Record> 
        {
            public int Compare(Record x, Record y) 
            {
                if (x.Rank < y.Rank) {
                    return -1;
                } else if (x.Rank > y.Rank) {
                    return 1;
                }

                if (x.Gender < y.Gender) {
                    return -1;
                } else if (x.Gender > y.Gender) {
                    return 1;
                }

                return String.Compare(x.Name, y.Name);
            }
        }

            class Program 
            {
                static void Main(string[] args) 
                {
                    var record = DataLoader.Load(@"./data");
                    var sorted = records.OrderBy(r => r, new RecordComparer());
                    foreach (var r in sorted) 
                    {
                        System.Console.WriteLine(r.ToString());
                    }
                }
            } 
            */
        
        /*
        static void Main(string[] args) 
        {
            int[] array1 = { 1, 2, 3, 4, 5 };
            int[] array2 = { 3, 4, 5, 6, 7 };

            var concatResult = array1.Concat(array2);
            var unionResult = array1.Union(array2);

            System.Console.WriteLine($"Concat: {string.Join(",", concatResult)}");
            System.Console.WriteLine($"Union: {string.Join(",", unionResult)}");
        } 
        */

        /* 
        static void Main(string[] args) 
        {
        var record = DataLoader.Load(@"./data");
        int[] left = { 1, 1, 2, 3, 3, 4, 4 };
        int[] right = { 3, 4, 5, 6 };

        var distinctResult = left.Distinct();
        var intersectResult = left.Intersect(right);
        var exceptResult = left.Except(right);
        var unionResult = left.Union(right);

        Console.WriteLine($"Distinct: {string.Join(",", distinctResult)}"); 
        Console.WriteLine($"Intersect: {string.Join(",", intersectResult)}"); 
        Console.WriteLine($"Except: {string.Join(",", exceptResult)}"); 
        Console.WriteLine($"Union: {string.Join(",", unionResult)}"); 
        } 
        */        

        /*
        class RecordComparer : IEqualityComparer<Record> 
        {
        public bool Equals(Record x, Record y) {
            return x.Name == y.Name && x.Gender == y.Gender && x.Rank == y.Rank;
        }

        public int GetHashCode(Record obj) 
        {
            return obj.GetHashCode();
        }

        static void Main(string[] args) 
        {
            var record = DataLoader.Load(@"./data");
            var record = new Record("Timothy", Gender.Male, 38);
            var result = records.Contains(record, new RecordComparer()); 
            System.Console.WriteLine(result);
        }
        */

        /*
        static void Main(string[] args)
        {
            var record = DataLoader.Load(@"./data");
            var femaleTop10 = record
                .Where(r => r.Gender == Gender.Female && r.Rank <= 10);
            var maleTop10 = from r in record
                            where r.Gender == Gender.Male && r.Rank <= 10
                            select r;
            foreach (var r in femaleTop10)
                System.Console.WriteLine(r);
            foreach (var r in maleTop10)
                System.Console.WriteLine(r);
        }
        */
    }
}

