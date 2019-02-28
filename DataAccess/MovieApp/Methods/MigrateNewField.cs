using System;
using System.Linq;
//using System.Linq.Expressions;
using ConsoleTables;
using MovieApp.Entities;
using MovieApp.Extensions;
using MovieApp.Models;

namespace MovieApp
{
    public static class MigrateNewField
    {
        public static void MigrationAddColumn()
        {            
            var film = MoviesContext.Instance.Films
                    .FirstOrDefault(f => f.Title.Contains("the first avenger"));
            if (film != null)
            {
                Console.WriteLine($"Updating film with id {film.FilmId}");
                film.Runtime = 124;
                MoviesContext.Instance.SaveChanges();
            }

            var films = MoviesContext.Instance.Films
                            .Select(f => f.Copy<Film, FilmModel>());
            ConsoleTable.From(films).Write();
        }
    }
}