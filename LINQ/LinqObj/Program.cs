using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace LinqObj
{
    class Program
    {

        static void Main(string[] args) 
        {
            var reader = new StreamReader(File.OpenRead(@"./data/male.csv"));
            var writer = new StreamWriter(File.OpenWrite(@"./data/count.csv"));
            var dict = new Dictionary<char, int>();
            while (!reader.EndOfStream) {
                var line = reader.ReadLine();
                var name = line.Split(",")[1];
                if (!dict.ContainsKey(name[0])) 
                {
                    dict[name[0]] = 0;
                }
                dict[name[0]]++;
            }

            var kvps = dict.OrderBy(kvp => kvp.Key);
            foreach (var kvp in kvps) 
            {
                writer.WriteLine($"{kvp.Key},{kvp.Value}");
            }

            writer.Flush();
            writer.Close();
        }

        /*
        static void Main(string[] args) 
        {
            var lines = File.ReadAllLines(@"./data/male.csv");
            var names = lines.Select(l => l.Split(",")[1]);
            var result = from n in names
                         group n by n[0] into g orderby g.Key
                         select $"{g.Key},{g.Count()}";
            File.WriteAllLines(@"./data/count.csv", result);
        }
        */
        

        /* 
        static void Main(string[] args) 
        {
            var nameString = "Tim,Ella,Tom,Gary,Gerry,Andrew,Marwa,Bre'Ana,Li";
            var result = from c in nameString
                         group c by Char.ToUpper(c) into g orderby g.Key
                         select new { Char = g.Key, Count = g.Count() };

            foreach (var item in result) 
            {
                if (item.Char < 'A' || item.Char > 'Z') continue;
                Console.WriteLine($"{item.Char}: {item.Count}");
            }
        }*/

        /* Strings
        static void Main(string[] args) 
        {
            var nameString = "Tim,Ella,Tom,Gary,Gerry,Andrew,Marwa,Bre'Ana,Li";
            var names = nameString.Split(",");
            var lookup = names.ToLookup(n => n[0], n => n);
            Console.WriteLine(string.Join(",", lookup['G']));
        }
        */

        /* Query file system
        static void Main(string[] args) 
        {
            var files = new DirectoryInfo(@"./")
            .GetFiles("*", SearchOption.AllDirectories).AsParallel();

            var result = (from f in files group f by f.Extension.ToLower()
            into g orderby g.Count() descending select g)
            .Take(10).Select(g => $"{(g.Key == string.Empty ? "N/A" : g.Key)}:\t{g.Count()}");

            foreach (var item in result) 
            {
                System.Console.WriteLine(item);
            }
        }
        */
    }
}
