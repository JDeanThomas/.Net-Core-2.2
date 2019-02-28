

using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MovieApp.Entities;
using MovieApp.Extensions;

namespace MovieApp
{
    public static class DisconnectedEntities
    {
        public static void DetachedEntities()
        {
            Console.WriteLine();

            const int filmId = 1;
            var year = MoviesContext.Instance.Films.Where(f => f.FilmId == filmId).Select(f => f.ReleaseYear).First();
            Console.WriteLine($"Original Release Year:\t{year}");

            var model = new FilmUpdateModel
            {
                FilmId = filmId,
                Description = "Fetishistic, patriotic, nerd entertainment.",
                Title = "Captain America: The Winter Soldier",
                RatingId = 3,
                ReleaseYear = 2013
            };

            var film = model.Copy<FilmUpdateModel, Film>();

            MoviesContext.Instance.Films.Attach(film);
            MoviesContext.Instance.Entry(film).State = EntityState.Modified;

            MoviesContext.Instance.SaveChanges();

            year = MoviesContext.Instance.Films.Where(f => f.FilmId == filmId).Select(f => f.ReleaseYear).First();
            Console.WriteLine($"Updated Release Year:\t{year}");

            film.ReleaseYear = 2014;
            MoviesContext.Instance.SaveChanges();

            year = MoviesContext.Instance.Films.Where(f => f.FilmId == filmId).Select(f => f.ReleaseYear).First();
            Console.WriteLine($"Reverted Release Year:\t{year}");
        }
    }
}