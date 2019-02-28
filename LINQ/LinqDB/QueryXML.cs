using System;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using LinqDB.Models;

namespace WorldApp {
    class Program {
        /*
        static void Main(string[] args) 
        {
            var rootElement = XElement.Load(@"C:\Projects\world.xml");

            // Query 1:
            var continents = rootElement.Elements()
                .Select(e => e.Attribute("name").Value);
            foreach (var item in continents) 
            {
                System.Console.WriteLine(item);
            }

            // Query 2:
            var northAmericaPop = rootElement.Elements()
                .Single(e => e.Attribute("name").Value == "North America")
                .Descendants("country")
                .Sum(e => int.Parse(e.Attribute("population").Value));
            System.Console.WriteLine(northAmericaPop);
        }
        */
    }
    
}