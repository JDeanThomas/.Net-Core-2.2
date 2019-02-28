using System;
using System.Linq;
using MovieApp.Entities;

namespace MovieApp.Helpers
{
    public class RandomActor
    {
        public static void Write(FilmActor filmActor)
        {
            if (filmActor == null)
            {
                Console.WriteLine("Film Actor Not Found");
                return;
            }

            var film = filmActor.Film;
            var actor = filmActor.Actor;
            if (film == null)
            {
                film = MoviesContext.Instance.Films
                            .FirstOrDefault(f => f.FilmId == filmActor.FilmId);
            }
            if (actor == null)
            {
                actor = MoviesContext.Instance.Actors
                            .FirstOrDefault(a => a.ActorId == filmActor.ActorId);
            }

            Console.WriteLine($"Film: {film.FilmId}  -  {film.Title}\t Actor: {actor.ActorId}  -  {actor.FirstName} {actor.LastName}");
        }

        public static FilmActor GetRandomFilmActor()
        {
            int count = MoviesContext.Instance.FilmActors.Count();
            var skip = new Random().Next(0, count);
            return MoviesContext.Instance.FilmActors
                        .Skip(skip)
                        .Select(fa => new FilmActor
                        {
                            FilmId = fa.FilmId,
                            ActorId = fa.ActorId
                        })
                        .First();
        }
    }


}