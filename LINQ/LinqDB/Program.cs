using System;
using System.Linq;
using System.Collections.Generic;
using LinqDB.Models;



namespace LinqDB
{
    class Program
    {

        
        static void Main(string[] args) 
        {
            var dbContext = new WorldContext();
            var continents = dbContext.Continent.OrderBy(c => c.Name);
            var countries = dbContext.Country.OrderBy(c => c.Name);

            var result = continents.GroupJoin(countries,
                ctn => ctn.Id, ctry => ctry.ContinentId,
                (ctn, g) => new { Continent = ctn.Name, CountryCount = g.Count() }
            );

            foreach (var item in result) 
            {
                Console.WriteLine($"{item.Continent}: {item.CountryCount}");
            }
        }
        

        /* Query syntax, GroupJoin
        static void Main(string[] args) 
        {
            var dbContext = new WorldContext();
            var continents = dbContext.Continent.OrderBy(c => c.Name);
            var countries = dbContext.Country.OrderBy(c => c.Name);

            var result = from ctn in continents join ctry in countries
                         on ctn.Id equals ctry.ContinentId into g
                         select new { Continent = ctn.Name, CountryCount = g.Count() };

            foreach (var item in result) 
            {
                Console.WriteLine($"{item.Continent}: {item.CountryCount}");
            }
        }
        */

        /* Query syntax, Join then GroupBy
        static void Main(string[] args) 
        {
            var dbContext = new WorldContext();
            var continents = dbContext.Continent.OrderBy(c => c.Name);
            var countries = dbContext.Country.OrderBy(c => c.Name);

            var result = from ctn in continents join ctry in countries
                         on ctn.Id equals ctry.ContinentId
                         group ctry by ctn.Name into g
                         select new { Continent = g.Key, CountryCount = g.Count() };

            foreach (var item in result) 
            {
                Console.WriteLine($"{item.Continent}: {item.CountryCount}");
            }
        }

        /* Query syntax
        static void Main(string[] args) 
        {
            var dbContext = new WorldContext();
            var continents = dbContext.Continent.OrderBy(c => c.Name);
            var countries = dbContext.Country.OrderBy(c => c.Name);

            var result = from ctn in continents join ctry in countries
                         on ctn.Id equals ctry.ContinentId
                         select new { Continent = ctn.Name, Country = ctry.Name };

            foreach (var r in result) 
            {
                Console.WriteLine($"{r.Continent}\t {r.Country}");
            }
        */

        /* 
        static void Main(string[] args) 
        {
            var dbContext = new WorldContext();
            var continents = dbContext.Continent.OrderBy(c => c.Name);
            var countries = dbContext.Country.OrderBy(c => c.Name);

            var result = continents.Join(countries,
            c => c.Id, c => c.ContinentId,
            (ctn, ctry) => new { Continent = ctn.Name, Country = ctry.Name });

            foreach (var r in result) 
            {
                Console.WriteLine($"{r.Continent}\t {r.Country}");
            }
        */

        /* Query syntax
        static void Main(string[] args) 
        {
            var dbContext = new WorldContext();
            var countries = dbContext.Country
                .Include(nameof(Country.Continent))
                .OrderByDescending(c => c.SurfaceArea);

            var result = from c in countries
                         group c.Name by c.Continent.Name into g
                         select $"{g.Key}: {string.Join(",", g.Take(3))}";

            foreach (var r in result) 
            {
                Console.WriteLine(r);
            }
        }
        */

        /* 
        static void Main(string[] args) 
        {
            var dbContext = new WorldContext();
            var countries = dbContext.Country
                .Include(nameof(Country.Continent))
                .OrderByDescending(c => c.SurfaceArea);

            var result = countries.GroupBy(c => c.Continent.Name, c => c.Name)
                .Select(g => $"{g.Key}: {string.Join(",", g.Take(3))}");

            foreach (var r in result) 
            {
                Console.WriteLine(r);
            }
        }
        */

        /* 
        static void Main(string[] args) 
        {
            var dbContext = new WorldContext();
            var countries = dbContext.Country
                .Include(nameof(Country.Continent))
                .Where(c => c.Continent.Name == "Europe");

            var largest = countries.Max(c => c.SurfaceArea);
            var smallest = countries.Min(c => c.SurfaceArea);
            var count = countries.Count();
            var totalPopulation = countries.Sum(c => c.Population);

            Console.WriteLine($"Europe Largest Country Area: {largest}");
            Console.WriteLine($"Europe Smallest Country Area: {smallest}");
            Console.WriteLine($"Europe Country Count: {count}");
            Console.WriteLine($"Europe Total Population: {totalPopulation}");
        }
        */

        /* 
        static void Main(string[] args) 
        {
            var dbContext = new WorldContext();
            var array = dbContext.Continent.ToArray();
            var list = dbContext.Continent.ToList();
            var dict = dbContext.Country.ToDictionary(c => c.Name, c => c.Population);
            var lookup = dbContext.Country.Include(nameof(Country.Continent))
                .ToLookup(c => c.Continent.Name, c => c.Name);

            Console.WriteLine(array.Length);
            Console.WriteLine(list.Count);
            Console.WriteLine(dict["China"]);
            Console.WriteLine(string.Join(",", lookup["Antarctica"]));
        }
        */

        /* 
        static void Main(string[] args) 
        {
            var dbContext = new WorldContext();
            var sorted = dbContext.Country.OrderByDescending(c => c.SurfaceArea);
            var largest5 = sorted.Take(5);
            var the21to25 = sorted.Skip(20).Take(5);
            var smallest5 = sorted.ToList().TakeLast(5);

            Console.WriteLine("[Largest 5]");
            foreach (var c in largest5) 
            {
                Console.WriteLine($"{c.Name} {c.SurfaceArea}");
            }

            Console.WriteLine("===================");
            Console.WriteLine("[Largest 21 to 25]");
            foreach (var c in the21to25) 
            {
                Console.WriteLine($"{c.Name} {c.SurfaceArea}");
            }

            Console.WriteLine("===================");
            Console.WriteLine("[Smallest 5]");
            foreach (var c in smallest5) 
            {
                Console.WriteLine($"{c.Name} {c.SurfaceArea}");
            }
        }
        */

        /* 
        static void Main(string[] args) 
        {
            var dbContext = new WorldContext();

            try {
                var seattle = dbContext.City.Single(c => c.Name == "Seattle");
                Console.WriteLine($"There is a city called Seattle.");
            } catch {
                Console.WriteLine($"There maybe zero or more than one Seattle.");
            }

            try {
                var foundOneKirkland = dbContext.City.Single(c => c.Name == "Kirkland");
                Console.WriteLine($"There is a city called Kirkland.");
            } catch {
                Console.WriteLine($"There maybe zero or more than one Kirkland.");
            }

            try {
                var foundOneSantaClara = dbContext.City.Single(c => c.Name == "Santa Clara");
                Console.WriteLine($"There is a city called Santa Clara.");
            } catch {
                Console.WriteLine($"There maybe zero or more than one Santa Clara.");
            }
        }
        */

        /* 
        static void Main(string[] args) 
        {
            var dbContext = new WorldContext();
            var sorted = dbContext.Country.OrderByDescending(c => c.SurfaceArea);
            var largest = sorted.First();
            var smallest = sorted.Last();

            Console.WriteLine($"Largest: {largest.Name} {largest.SurfaceArea}");
            Console.WriteLine($"Smallest: {smallest.Name} {smallest.SurfaceArea}");
        }
        */

        /* Query snytax equivalent
        static void Main(string[] args) 
        {
            var dbContext = new WorldContext();
            var countries =
                from c in dbContext.Country.Include(nameof(Country.Continent))
                orderby c.Continent.Name, c.Population descending
                select c;
            
            foreach (var c in countries) 
            {
                Console.WriteLine($"{c.Continent.Name} {c.Name} {c.Population}");
            }
        }
        */

        /* 
        static void Main(string[] args) 
        {
            var dbContext = new WorldContext();
            var countries = dbContext.Country
            .Include(nameof(Country.Continent))
            .OrderBy(c => c.Continent.Name)
            .ThenByDescending(c => c.Population);
            
            foreach (var c in countries) 
            {
                Console.WriteLine($"{c.Continent.Name} {c.Name} {c.Population}");
            }
        }
        */

        /* Distonct unnecessay
        static void Main(string[] args) 
        {
            var dbContext = new WorldContext();
            var continents = dbContext.Continent
                .Include(nameof(Continent.Country))
                .Where(c => c.Country.Any());
            
            foreach (var c in continents) 
            {
                System.Console.WriteLine(c.Name);
            }
        }
        */

        /* 
        static void Main(string[] args) 
        {
            var dbContext = new WorldContext();
            var continents = dbContext.Country
                  .Include(nameof(Country.Continent))
                  .Select(c => c.Continent).Distinct();
            
            foreach (var c in continents) 
            {
                System.Console.WriteLine(c.Name);
            }
        }
        */

        /* 
        static void Main(string[] args) 
        {
            var dbContext = new WorldContext();
            var bigArea = dbContext.Country
                .OrderByDescending(c => c.SurfaceArea).Take(10);
            var bigPopulation = dbContext.Country
                .OrderByDescending(c => c.Population).Take(10);

            var r1 = bigArea.Union(bigPopulation);
            var r2 = bigArea.Intersect(bigPopulation);
            var r3 = bigArea.Except(bigPopulation);

            Console.WriteLine("[Big Area or Big Population]");
            foreach (var r in r1) 
            {
                Console.WriteLine(r.Name);
            }

            Console.WriteLine("========================");
            Console.WriteLine("[Big Area and Big Population]");
            foreach (var r in r2) 
            {
                Console.WriteLine(r.Name);
            }

            Console.WriteLine("========================");
            Console.WriteLine("[Big Area but Not Big Population]");
            foreach (var r in r3) 
            {
                Console.WriteLine(r.Name);
            }
        }
        */

        /* Alt of below using select
        static void Main(string[] args) 
        {
            var dbContext = new WorldContext();
            var names = dbContext.Country
                .Include(nameof(Country.Continent))
                .Where(c => c.Continent.Name == "North America"
                || c.Continent.Name == "South America")
                .Select(c => c.Name);

            foreach (var n in names) 
            {
                System.Console.WriteLine(n);
            }
        }
        */

        /* 
        static void Main(string[] args) 
        {
            var dbContext = new WorldContext();
            var names = dbContext.Continent
                  .Include(nameof(Continent.Country))
                  .Where(c => c.Name == "North America" || c.Name == "South America")
                  .SelectMany(c => c.Country).Select(c => c.Name);

            foreach (var n in names) 
            {
                System.Console.WriteLine(n);
            }
        }
        */

        /* 
        static void Main(string[] args) 
        {
            var dbContext = new WorldContext();
            var names = dbContext.Country
                  .Where(c => c.Population > 100000000)
                  .Select(c => c.Name);
            foreach (var n in names) 
            {
                System.Console.WriteLine(n);
            }
        }
            
        */

        /* 
        static void Main(string[] args) 
        {
            var dbContext = new WorldContext();
            var continents = dbContext.Continent
                .Include(nameof(Continent.Country));
            foreach (var c in continents) 
            {
                Console.WriteLine($"{c.Name.PadRight(16)} {c.Country.Count}");
            }
        }
        */

        /* 
        static void Main(string[] args) 
        {
            var dbContext = new WorldContext();
            var seattle = new City { Name = "Seattle", District = "Washington" };
            var result = dbContext.City
                .Any(c => c.Name == seattle.Name && c.District == seattle.District);
            System.Console.WriteLine(result);
        }
        */

        /* 
        static void Main(string[] args) 
        {
            var dbContext = new WorldContext();
            var r1 = dbContext.Continent.Any();
            var r2 = dbContext.City.Any(c => c.Population > 10000000);
            Console.WriteLine(r1);
            Console.WriteLine(r2);
        }
        */

        /* 
        static void Main(string[] args) 
        {
            var dbContext = new WorldContext();
            var result = dbContext.City.All(c => c.Population > 1000);
            Console.WriteLine(result);
        }
        */

        /* 
        static void Main(string[] args) 
        {
            var dbContext = new WorldContext();
            var countries = dbContext.Country
                .Where(c => c.Population > 100000000);
            foreach (var c in countries) 
            {
                Console.WriteLine($"{c.Name} => {c.Population}");
            }
        }
        */
     
        /*
        static void Main(string[] args)
        {
            var dbContext = new WorldContext();
            var continents = dbContext.Continent.ToList();
            foreach (var c in continents) 
            {
                System.Console.WriteLine($"ID:{c.Id} Name:{c.Name}");
            }
        }
        */

        
        
    }
}
