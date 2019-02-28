using System;
using System.Linq;
using ConsoleTables;
using Microsoft.EntityFrameworkCore;
using MovieApp.Entities;
using MovieApp.Extensions;
using MovieApp.Models;

namespace MovieApp
{
    public static class RawSQL
    {
        public static void ExecuteRawSql()
        {
            var sql = "select * from actor where actorid = ?";
            var actors = MoviesContext.Instance.Actors
                                    .FromSql(sql, 2)
                                    .Select(a => a.Copy<Actor, ActorModel>());
            ConsoleTable.From(actors).Write();

            sql = "select * from film limit 1";
            var films = MoviesContext.Instance.Films
                                    .FromSql(sql)
                                    .Select(f => f.Copy<Film, FilmModel>());
            ConsoleTable.From(films).Write();
        }

        public static void ExecuteStoredProcedure()
        {
            var sql = "call FilmStartsWithTitle({0})";
            var films = MoviesContext.Instance.Films
                                    .FromSql(sql, "t")
                                    .Select(f => f.Copy<Film, FilmModel>());
            ConsoleTable.From(films).Write();

            sql = "call FindActor({0})";
            var actors = MoviesContext.Instance.Actors
                                    .FromSql(sql, "on")
                                    .Select(a => a.Copy<Actor, ActorModel>());
            ConsoleTable.From(actors).Write();
        }
    }
}