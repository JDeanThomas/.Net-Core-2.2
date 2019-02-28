using System;
using System.Xml;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;
using LinqDB.Models;

namespace XML {
    class Program {
        /*
        static void Main(string[] args) 
        {
            // Read data
            var dbContext = new WorldContext();
            var continents = dbContext.Continent.Include(c => c.Country)
                    .ThenInclude(country => country.City);

            // Construct XML
            var rootElement = new XElement("world");
            foreach (var continent in continents) 
            {
                var continentElement = new XElement("continent");
                continentElement.Add(new XAttribute("name", continent.Name));
                foreach (var country in continent.Country) 
                {
                    var countryElement = new XElement("country");
                    countryElement.Add(new XAttribute("code", country.Code));
                    countryElement.Add(new XAttribute("name", country.Name));
                    countryElement.Add(new XAttribute("area", country.SurfaceArea));
                    countryElement.Add(new XAttribute("population", country.Population));
                    foreach (var city in country.City) 
                    {
                        var cityElement = new XElement("city");
                        cityElement.Add(new XAttribute("id", city.Id));
                        cityElement.Add(new XAttribute("name", city.Name));
                        cityElement.Add(new XAttribute("population", city.Population));
                        countryElement.Add(cityElement);
                    }
                    continentElement.Add(countryElement);
                }
                rootElement.Add(continentElement);
            }

            // Persist in-memory XML data to XML file
            var writer = XmlWriter.Create(@"C:\Projects\world.xml");
            rootElement.WriteTo(writer);
            writer.Flush();
            writer.Close();
            System.Console.WriteLine("DONE!");
        }
        */
    }
}