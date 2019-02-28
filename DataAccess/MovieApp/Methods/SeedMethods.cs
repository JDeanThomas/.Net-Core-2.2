using System;
using System.Linq;
using MovieApp.Entities;
using MovieApp.DataSeed;
using Microsoft.EntityFrameworkCore;
using MovieApp.Extensions;

namespace MovieApp
{
    public static class SeedMethods
    {
        public static void AddSeedData()
        {
            if (!MoviesContext.Instance.Films.Any())
            {
                Console.WriteLine("Seeding films");
                
                SeedData.Films.ForEach(f =>
                {
                    f.FilmId = 0;
                    MoviesContext.Instance.Films.Add(f);
                });
                Console.WriteLine("Done");
            }
            else
            {
                Console.WriteLine("Skipping films");
            }

            if (!MoviesContext.Instance.Categories.Any())
            {
                Console.WriteLine("Seeding categories");
                SeedData.Categories.ForEach(c =>
                {
                    c.CategoryId = 0;
                    MoviesContext.Instance.Categories.Add(c);
                });
                Console.WriteLine("Done");
            }
            else
            {
                Console.WriteLine("Skipping categories");
            }

            if (!MoviesContext.Instance.FilmCategories.Any())
            {
                Console.WriteLine("Seeding film categories");
                SeedData.FilmCategories.ForEach(fc => MoviesContext.Instance.FilmCategories.Add(fc));
                Console.WriteLine("Done");
            }
            else
            {
                Console.WriteLine("Skipping film categories");
            }

            MoviesContext.Instance.SaveChanges();
        }

        public static void AddOrUpdateSeedData()
        {
            var updatedCount = 0;
            var addedCount = 0;

            Console.WriteLine("Seeding films");
            SeedData.Films.ForEach(f =>
            {
                var film = MoviesContext.Instance.Films.SingleOrDefault(e => e.FilmId == f.FilmId);
                if (film == null)
                {
                    MoviesContext.Instance.Films.Attach(f);
                    MoviesContext.Instance.Entry(f).State = EntityState.Added;
                    addedCount++;
                }
                else
                {
                    f.Copy(film);
                    updatedCount++;
                }
            });
            Console.WriteLine($"Done. Updated: {updatedCount}, Added: {addedCount}");

            addedCount = updatedCount = 0;
            Console.WriteLine("Seeding categories");
            SeedData.Categories.ForEach(c =>
            {
                var category = MoviesContext.Instance.Categories.SingleOrDefault(e => e.CategoryId == c.CategoryId);
                if (category == null)
                {
                    MoviesContext.Instance.Categories.Attach(c);
                    MoviesContext.Instance.Entry(c).State = EntityState.Added;
                    addedCount++;
                }
                else
                {
                    c.Copy(category);
                    updatedCount++;
                }
            });
            Console.WriteLine($"Done. Updated: {updatedCount}, Added: {addedCount}");

            addedCount = updatedCount = 0;
            Console.WriteLine("Seeding film categories");
            SeedData.FilmCategories.ForEach(fc =>
            {
                var filmCategory = MoviesContext.Instance.FilmCategories
                                    .SingleOrDefault(e => e.FilmId == fc.FilmId && e.CategoryId == fc.CategoryId);
                if (filmCategory == null)
                {
                    MoviesContext.Instance.FilmCategories.Attach(fc);
                    MoviesContext.Instance.Entry(fc).State = EntityState.Added;
                    addedCount++;
                }
            });
            Console.WriteLine($"Done. Updated: {updatedCount}, Added: {addedCount}");

            MoviesContext.Instance.SaveChanges();
        }

        public static void WriteDataCount()
        {
            var count = MoviesContext.Instance.Films.Count();
            Console.WriteLine($"films: {count}");
            count = MoviesContext.Instance.Categories.Count();
            Console.WriteLine($"categories: {count}");
            count = MoviesContext.Instance.FilmCategories.Count();
            Console.WriteLine($"film categories: {count}");
        }
    }
}