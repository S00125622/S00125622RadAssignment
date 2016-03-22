namespace S00125622RadAss2.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<S00125622RadAss2.Models.MovieContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(S00125622RadAss2.Models.MovieContext context)
        {
            context.Directors.AddOrUpdate(x => x.Id,
                new Director () { Id = 1, Name = "Steven Spielberg" },
                new Director() { Id = 2, Name = "Quentin Tarantino" },
                new Director() { Id = 3, Name = "Peter Jackson" },
                new Director() { Id = 4, Name = "Martin Scorsese" },
                new Director() { Id = 5, Name = "Guillermo del Toro" }
                );

            context.Movies.AddOrUpdate(x => x.Id,
                new Movie()
                {
                    Id =1,
                    Title = "Saving Private Ryan",
                    Year = 1998,
                    DirectorId = 1,
                    Genre = "War, Action"
                },

                new Movie()
                {
                    Id = 2,
                    Title = "Reservoir Dogs",
                    Year = 1992,
                    DirectorId = 2,
                    Genre = "Crime, Drama"
                },

                new Movie()
                {
                    Id = 3,
                    Title = "The Lord of the Rings: The Fellowship of the Ring",
                    Year = 2001,
                    DirectorId = 3,
                    Genre = "Adventure, Fantasy"
                },

                new Movie()
                {
                    Id = 4,
                    Title = "The Departed ",
                    Year = 2006,
                    DirectorId = 4,
                    Genre = "Crime, Thriller"
                },

                new Movie()
                {
                    Id = 5,
                    Title = "Pacific Rim",
                    Year = 2013,
                    DirectorId = 5,
                    Genre = "Sci-Fi, Action"
                }

                );
        }
    }
}
