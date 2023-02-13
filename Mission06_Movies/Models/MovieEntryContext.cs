using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission06_Movies.Models
{
    public class MovieEntryContext : DbContext
    {
        // Constructor 
        public MovieEntryContext(DbContextOptions<MovieEntryContext> options) : base(options)
        {
            // Leave blank for now
        }

        public DbSet<MovieFormResponse> Movies { get; set; }

        // Seeding the data
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<MovieFormResponse>().HasData(

                new MovieFormResponse
                {
                    MovieID = 1,
                    Category = "Comedy",
                    Title = "School of Rock",
                    Year = 2003,
                    Director = "Richard Linklater",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "My brother Tad",
                    Notes = null
                },
                new MovieFormResponse
                {
                    MovieID = 2,
                    Category = "Action/Adventure",
                    Title = "Avatar, Way of Water",
                    Year = 2023,
                    Director = "James Cameron",
                    Rating = "PG-13",
                    Edited = true,
                    LentTo = null,
                    Notes = null
                },
                new MovieFormResponse
                {
                    MovieID = 3,
                    Category = "Thriller/Action",
                    Title = "The Prestige",
                    Year = 2006,
                    Director = "Christopher Nolan",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "Noone: I keep forever",
                    Notes = "This movie is so cool"
                }
            );
        }


    }

}
