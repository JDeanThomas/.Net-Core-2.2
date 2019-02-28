using System;
using System.Linq;
using ConsoleTables;
using Microsoft.EntityFrameworkCore;
using MovieApp.Entities;
using MovieApp.Models;
using MovieApp.Helpers;

namespace MovieApp
{
    public static class RelatedEntities
    {

        public static void OneToOne()
        {
            var films = MoviesContext.Instance.Films.Include(f => f.FilmImage)
                           .Select(CreateFilmDetail.CreateFilmDetailModel);
            ConsoleTable.From(films).Write();

            var x = MoviesContext.Instance.Films.Include(f => f.FilmImage)
                           .Select(CreateFilmDetail.CreateFilmDetailModel);

            films = MoviesContext.Instance.Films.Include(f => f.FilmImage)
                            .Where(f => f.FilmImage == null)
                            .Select(CreateFilmDetail.CreateFilmDetailModel);
            ConsoleTable.From(films).Write();

            films = MoviesContext.Instance.FilmImages.Include(i => i.Film)
                            .Select(CreateFilmDetail.CreateFilmDetailModel);
            ConsoleTable.From(films).Write();
        }

        public static void OneToMany()
        {
            var ratingsQuery = MoviesContext.Instance.Ratings;
            int skip = new Random().Next(0, ratingsQuery.Count());
            var ratings = ratingsQuery.Skip(skip).Take(1);

            var ratingId = ratings.First().RatingId;

            var rating = MoviesContext.Instance.Ratings.First(r => r.RatingId == ratingId);

            Console.WriteLine(new string('-', 78));
            Console.WriteLine($"{rating.Code}\t{rating.Name}");
            Console.WriteLine(new string('-', 78));
            var films = MoviesContext.Instance.Films.Where(f => f.RatingId == rating.RatingId)
                            .OrderBy(f => f.ReleaseYear);
            if (films.Any())
            {
                Console.WriteLine($"\tID\tYear\tTitle");
                Console.WriteLine($"\t{new string('-', 70)}");
                foreach (var film in films.OrderByDescending(f => f.ReleaseYear))
                {
                    Console.WriteLine($"\t{film.FilmId}\t{film.ReleaseYear}\t{film.Title}");
                }
            }
            else
            {
                Console.WriteLine("\tNo Films");
            }

            Console.WriteLine();
            Console.WriteLine(new string('-', 78));
            var filmsQuery = MoviesContext.Instance.Films;
            skip = new Random().Next(0, filmsQuery.Count());

            var filmId = filmsQuery.Skip(skip).First().FilmId;

            var film2 = MoviesContext.Instance.Films.First(f => f.FilmId == filmId);
            var rating2 = MoviesContext.Instance.Ratings.FirstOrDefault(r => r.RatingId == film2.RatingId);
            Console.WriteLine($"{film2.FilmId}\t{film2.Title}\t{rating2.Code}\t{rating2.Name}");

            /*
            var ratings = MoviesContext.Instance.Ratings
                .Include(r => r.Films);

            foreach (var rating in ratings)
            {
                Console.WriteLine(new string('-', 78));
                Console.WriteLine($"{rating.Code}\t{rating.Name}");
                Console.WriteLine(new string('-', 78));
                if (rating.Films.Any())
                {
                    Console.WriteLine($"\tID\tYear\tTitle");
                    Console.WriteLine($"\t{new string('-', 70)}");
                    foreach (var film in rating.Films.OrderByDescending(f => f.ReleaseYear))
                    {
                        Console.WriteLine($"\t{film.FilmId}\t{film.ReleaseYear}\t{film.Title}");
                    }
                }
                else
                {
                    Console.WriteLine("\tNo Films");
                }
            }
            */
        }
        

        public static void ManyToManySelect()
        {
            var films = MoviesContext.Instance.Films
                .OrderBy(f => f.Title)
                .Include(f => f.FilmActor)
                .ThenInclude(a => a.Actor);

            foreach (var film in films)
            {
                Console.WriteLine(new string('-', 78));
                Console.WriteLine($"{film.FilmId}\t{film.ReleaseYear}\t{film.Title}");
                Console.WriteLine(new string('-', 78));
                var actors = film.FilmActor.Select(a => a.Actor)
                                    .OrderBy(a => a.LastName)
                                    .ThenBy(a => a.FirstName);
                foreach (var filmActor in film.FilmActor)
                {
                    Console.WriteLine($"\t{filmActor.ActorId}\t{filmActor.Actor.LastName}, {filmActor.Actor.FirstName}");
                }
            }

            var actors2 = MoviesContext.Instance.Actors
                .OrderBy(a => a.LastName)
                .ThenBy(a => a.FirstName)
                .Include(a => a.FilmActor)
                .ThenInclude(f => f.Film);
            foreach (var actor in actors2)
            {
                Console.WriteLine(new string('-', 78));
                Console.WriteLine($"{actor.ActorId}\t{actor.LastName}, {actor.FirstName}");
                Console.WriteLine(new string('-', 78));
                var films2 = actor.FilmActor.Select(a => a.Film).OrderByDescending(f => f.ReleaseYear);
                foreach (var film in films2)
                {
                    Console.WriteLine($"\t{film.FilmId}\t{film.ReleaseYear}\t{film.Title}");
                }
            }

        }

        public static void ManyToManyInsert()
        {
            var actorId = 3;
            var filmId = 12;

            var actor = MoviesContext.Instance.Actors
                            .Include(a => a.FilmActor)
                            .ThenInclude(fa => fa.Film)
                            .Single(a => a.ActorId == actorId);
            if (actor.FilmActor.All(fa => fa.FilmId != filmId))
            {
                Console.WriteLine("Adding film to actor");
                actor.FilmActor.Add(new FilmActor { Actor = actor, FilmId = filmId });
                MoviesContext.Instance.SaveChanges();
            }

            actor = MoviesContext.Instance.Actors
                            .Include(a => a.FilmActor)
                            .ThenInclude(fa => fa.Film)
                            .Single(a => a.ActorId == actorId);
            foreach (var film in actor.FilmActor.Select(fa => fa.Film))
            {
                Console.WriteLine($"{film.FilmId}\t{film.ReleaseYear}\t{film.Title}");
            }
        }

        public static void ManyToManyDelete()
        {
            var filmActor = RandomActor.GetRandomFilmActor();
            var filmId = filmActor.FilmId;
            var actorId = filmActor.ActorId;

            
            RandomActor.Write(filmActor);

            var entity = new FilmActor
            {
                FilmId = filmId,
                ActorId = actorId
            };
            MoviesContext.Instance.FilmActors.Remove(entity);
            MoviesContext.Instance.SaveChanges();

            filmActor = MoviesContext.Instance.FilmActors
                            .SingleOrDefault(fa => fa.FilmId == filmId &&
                                                   fa.ActorId == actorId);

            RandomActor.Write(filmActor);

            MoviesContext.Instance.FilmActors.Add(new FilmActor
            {
                FilmId = filmId,
                ActorId = actorId
            });
            MoviesContext.Instance.SaveChanges();

            filmActor = MoviesContext.Instance.FilmActors
                            .SingleOrDefault(fa => fa.FilmId == filmId &&
                                                   fa.ActorId == actorId);

            RandomActor.Write(filmActor);
        }

        public static void LazyLoadFilm()
        {
            var filmId = 4;
            var film = MoviesContext.Instance.Films.Single(f => f.FilmId == filmId);
            Console.WriteLine($"{film.FilmId} - {film.Title}");
            MoviesContext.Instance.Entry(film).Collection(f => f.FilmActor).Load();
            foreach (var filmActor in film.FilmActor)
            {
                MoviesContext.Instance.Entry(filmActor).Reference(fa => fa.Actor).Load();
                Console.WriteLine($"\tfilm id: {filmActor.FilmId} actor id: {filmActor.ActorId}");
                Console.WriteLine($"\t\tactor id: {filmActor.Actor.ActorId} - {filmActor.Actor.FirstName} {filmActor.Actor.LastName}");
            }
        }

        public static void LazyLoadCategory()
        {
            var categories = MoviesContext.Instance.Categories;
            foreach (var category in categories)
            {
                Console.WriteLine($"Category: {category.CategoryId} - {category.Name}");
                MoviesContext.Instance.Entry(category).Collection(c => c.FilmCategory).Load();
                if (category.FilmCategory.Any())
                {
                    foreach (var filmCategory in category.FilmCategory)
                    {
                        MoviesContext.Instance.Entry(filmCategory).Reference(fc => fc.Film).Load();
                        Console.WriteLine($"\t{filmCategory.Film.FilmId} - {filmCategory.Film.Title}");
                    }
                }
                else
                {
                    Console.WriteLine("\tNo Films");
                }
            }
        }

        public static void EagerLoadFilm()
        {
            var filmId = 4;
            var film = MoviesContext.Instance.Films
                        .Include(f => f.FilmActor)
                            .ThenInclude(fa => fa.Actor)
                        .Single(f => f.FilmId == filmId);
            Console.WriteLine($"{film.FilmId} - {film.Title}");
            foreach (var filmActor in film.FilmActor)
            {
                Console.WriteLine($"\tfilm id: {filmActor.FilmId} actor id: {filmActor.ActorId}");
                if (filmActor.Actor != null)
                {
                    Console.WriteLine($"\t\tactor id: {filmActor.Actor.ActorId} - {filmActor.Actor.FirstName} {filmActor.Actor.LastName}");
                }
            }
        }

        public static void EagerLoadCategory()
        {
            var categories = MoviesContext.Instance.Categories
                    .Include(c => c.FilmCategory)
                        .ThenInclude(fc => fc.Film);
            foreach (var category in categories)
            {
                Console.WriteLine($"Category: {category.CategoryId} - {category.Name}");
                MoviesContext.Instance.Entry(category).Collection(c => c.FilmCategory);
                if (category.FilmCategory.Any())
                {
                    foreach (var filmCategory in category.FilmCategory)
                    {
                        MoviesContext.Instance.Entry(filmCategory).Reference(fc => fc.Film);
                        Console.WriteLine($"\t{filmCategory.Film.FilmId} - {filmCategory.Film.Title}");
                    }
                }
                else
                {
                    Console.WriteLine("\tNo Films");
                }
            }
        }
    }
}