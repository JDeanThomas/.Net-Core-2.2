using System.Collections.Generic;
using System.Linq;
using MovieApp.Entities;

namespace MovieApp.DataSeed
{
    public static class SeedData
    {
        public static List<Film> Films
        {
            get
            {
                var id = 1;
                return new[] {
                    new Film { FilmId = id++, Title="Captain America: The Winter Soldier", Description = "As Steve Rogers struggles to embrace his role in the modern world, he teams up with a fellow Avenger and S.H.I.E.L.D agent, Black Widow, to battle a new threat from history: an assassin known as the Winter Soldier.", ReleaseYear = 2014, RatingCode= "PG-13"},
                    new Film { FilmId = id++, Title = "The Avengers", Description = "Earth's mightiest heroes must come together and learn to fight as a team if they are to stop the mischievous Loki and his alien army from enslaving humanity.",ReleaseYear = 2012, RatingCode= "PG-13"},
                    new Film { FilmId = id++, Title="Thor", Description = "The powerful but arrogant god Thor is cast out of Asgard to live amongst humans in Midgard (Earth), where he soon becomes one of their finest defenders.", ReleaseYear = 2011, RatingCode ="PG-13"},
                    new Film { FilmId = id++, Title="Avengers: Age of Ultron", Description = "When Tony Stark and Bruce Banner try to jump-start a dormant peacekeeping program called Ultron, things go horribly wrong and it's up to Earth's mightiest heroes to stop the villainous Ultron from enacting his terrible plan.", ReleaseYear = 2015, RatingCode = "PG-13"},
                    new Film { FilmId = id++, Title="Captain America: The First Avenger", Description = "Steve Rogers, a rejected military soldier transforms into Captain America after taking a dose of a \"Super-Soldier serum\". But being Captain America comes at a price as he attempts to take down a war monger and a terrorist organization.", ReleaseYear = 2011, RatingCode ="PG-13"},
                    new Film { FilmId = id++, Title="Star Wars: Episode IV - A New Hope", Description = "Luke Skywalker joins forces with a Jedi Knight, a cocky pilot, a Wookiee, and two droids to save the galaxy from the Empire's world-destroying battle-station, while also attempting to rescue Princess Leia from the evil Darth Vader. ", ReleaseYear = 1977, RatingCode ="PG"},
                    new Film { FilmId = id++, Title="Star Wars: Episode V - The Empire Strikes Back", Description = "After the rebels are overpowered by the Empire on their newly established base, Luke Skywalker begins Jedi training with Master Yoda. His friends accept shelter from a questionable ally as Darth Vader hunts them in a plan to capture Luke.", ReleaseYear = 1980, RatingCode ="PG"},
                    new Film { FilmId = id++, Title="Star Wars: Episode VI - Return of the Jedi", Description = "After a daring mission to rescue Han Solo from Jabba the Hutt, the rebels dispatch to Endor to destroy a more powerful Death Star. Meanwhile, Luke struggles to help Vader back from the dark side without falling into the Emperor's trap.", ReleaseYear = 1983, RatingCode = "PG"},
                    new Film { FilmId = id++, Title="Star Wars: Episode I - The Phantom Menace", Description = "Two Jedi Knights escape a hostile blockade to find allies and come across a young boy who may bring balance to the Force, but the long dormant Sith resurface to claim their old glory.", ReleaseYear = 1999, RatingCode = "PG"},
                    new Film { FilmId = id++, Title="Star Wars: Episode II - Attack of the Clones", Description = "Ten years after initially meeting, Anakin Skywalker shares a forbidden romance with Padmé, while Obi-Wan investigates an assassination attempt on the Senator and discovers a secret clone army crafted for the Jedi.", ReleaseYear = 2002, RatingCode = "PG"},
                    new Film { FilmId = id++, Title="Star Wars: Episode III - Revenge of the Sith", Description = "Three years into the Clone Wars, the Jedi rescue Palpatine from Count Dooku. As Obi-Wan pursues a new threat, Anakin acts as a double agent between the Jedi Council and Palpatine and is lured into a sinister plan to rule the galaxy.",ReleaseYear =  2005, RatingCode = "PG-13"},
                    new Film { FilmId = id++, Title="Rogue One", Description = "Three decades after the Empire's defeat, a new threat arises in the militant First Order. Stormtrooper defector Finn and spare parts scavenger Rey are caught up in the Resistance's search for the missing Luke Skywalker.", ReleaseYear = 2016, RatingCode = "PG-13"}
                }.ToList();
            }
        }

        public static List<Category> Categories
        {
            get
            {
                var id = 1;
                return new[] {
                    new Category{ CategoryId = id++, Name="Action"},
                    new Category{ CategoryId = id++, Name="Animation"},
                    new Category{ CategoryId = id++, Name="Children"},
                    new Category{ CategoryId = id++, Name="Classics"},
                    new Category{ CategoryId = id++, Name="Comedy"},
                    new Category{ CategoryId = id++, Name="Documentary"},
                    new Category{ CategoryId = id++, Name="Drama"},
                    new Category{ CategoryId = id++, Name="Family"},
                    new Category{ CategoryId = id++, Name="Foreign"},
                    new Category{ CategoryId = id++, Name="Games"},
                    new Category{ CategoryId = id++, Name="Horror"},
                    new Category{ CategoryId = id++, Name="Music"},
                    new Category{ CategoryId = id++, Name="New"},
                    new Category{ CategoryId = id++, Name="Sci-Fi"},
                    new Category{ CategoryId = id++, Name="Sports"},
                    new Category{ CategoryId = id++, Name="Travel"}
                }.ToList();
            } 
        }

        public static List<FilmCategory> FilmCategories
        {
            get
            {
                return new[] {
                    new FilmCategory { FilmId = 1, CategoryId = 1 },
                    new FilmCategory { FilmId = 2, CategoryId = 1 },
                    new FilmCategory { FilmId = 3, CategoryId = 1 },
                    new FilmCategory { FilmId = 4, CategoryId = 1 },
                    new FilmCategory { FilmId = 5, CategoryId = 1 },
                    new FilmCategory { FilmId = 6, CategoryId = 4 },
                    new FilmCategory { FilmId = 7, CategoryId = 4 },
                    new FilmCategory { FilmId = 8, CategoryId = 4 },
                    new FilmCategory { FilmId = 6, CategoryId = 14 },
                    new FilmCategory { FilmId = 7, CategoryId = 14 },
                    new FilmCategory { FilmId = 8, CategoryId = 14 },
                    new FilmCategory { FilmId = 9, CategoryId = 14 },
                    new FilmCategory { FilmId = 10, CategoryId = 14 },
                    new FilmCategory { FilmId = 11, CategoryId = 14 },
                    new FilmCategory { FilmId = 12, CategoryId = 14 }
                }.ToList();
            }
        }
    }
}