using System;
using System.Linq;
using MovieApp.Entities;
using MovieApp.DataSeed;
using Microsoft.EntityFrameworkCore;
using MovieApp.Extensions;

namespace MovieApp
{
    public static class SeedDB
    {
        public static void SeedDatabase()
        {
            SeedMethods.WriteDataCount();
            SeedMethods.AddSeedData();
            SeedMethods.WriteDataCount();
        }

        public static void SeedDatabaseAddUpdate()
        {
            SeedMethods.WriteDataCount();
            SeedMethods.AddOrUpdateSeedData();
            SeedMethods.WriteDataCount();
        }
    }
}