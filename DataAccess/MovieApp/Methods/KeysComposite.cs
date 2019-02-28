using System;
using ConsoleTables;
using MovieApp.Entities;

namespace MovieApp
{
    class KeysComposite
    {
        public static void CompositeKeys()
        {
            var data = new[] {
            new FilmInfo { Title = "Thor", ReleaseYear = 2011, Rating = "PG-13" },
            new FilmInfo { Title = "The Avengers", ReleaseYear = 2012, Rating = "PG-13" },
            new FilmInfo { Title = "Rogue One", ReleaseYear = 2016, Rating = "PG-13" }
        };

        MoviesContext.Instance.FilmInfos.AddRange(data);
        MoviesContext.Instance.SaveChanges();

        var infos = MoviesContext.Instance.FilmInfos;
        ConsoleTable.From(infos).Write();
        }
    }
}

