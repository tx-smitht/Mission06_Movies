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

        public DbSet<Category> Categories { get; set; }

        // Seeding the data
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category
                {
                    CategoryId = 1,
                    CategoryName = "Action"
                },
                new Category
                {
                    CategoryId = 2,
                    CategoryName = "Adventure"
                },
                new Category
                {
                    CategoryId = 3,
                    CategoryName = "Comedy"
                },
                new Category
                {
                    CategoryId = 4,
                    CategoryName = "Thriller"
                },
                new Category
                {
                    CategoryId = 5,
                    CategoryName = "Horror"
                },
                new Category
                {
                    CategoryId = 6,
                    CategoryName = "Documentary"
                }

                );
            mb.Entity<MovieFormResponse>().HasData(

                new MovieFormResponse
                {
                    MovieID = 1,
                    CategoryId = 3,
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
                    CategoryId = 2,
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
                    CategoryId = 4,
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
