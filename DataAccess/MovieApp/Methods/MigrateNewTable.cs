using System;
using System.Linq;
using ConsoleTables;
using MovieApp.Entities;
using MovieApp.Extensions;
using MovieApp.Models;

namespace MovieApp
{
    public static class MigrateNewTable
    {
        public static void MigrationAddTable()
        {
            var user = new ApplicationUser{
                UserName = "testuser",
                InvalidLoginAttempts = 0
            };

            MoviesContext.Instance.ApplicationUsers.Add(user);
            MoviesContext.Instance.SaveChanges();

            var users = MoviesContext.Instance.ApplicationUsers;
            ConsoleTable.From(users).Write();
        }
    }
}