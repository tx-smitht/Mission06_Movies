﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Mission06_Movies.Models;

namespace Mission06_Movies.Migrations
{
    [DbContext(typeof(MovieEntryContext))]
    partial class MovieEntryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.32");

            modelBuilder.Entity("Mission06_Movies.Models.MovieFormResponse", b =>
                {
                    b.Property<int>("MovieID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Director")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Edited")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LentTo")
                        .HasColumnType("TEXT");

                    b.Property<string>("Notes")
                        .HasColumnType("TEXT");

                    b.Property<string>("Rating")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Year")
                        .HasColumnType("INTEGER");

                    b.HasKey("MovieID");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            MovieID = 1,
                            Category = "Comedy",
                            Director = "Richard Linklater",
                            Edited = false,
                            LentTo = "My brother Tad",
                            Rating = "PG-13",
                            Title = "School of Rock",
                            Year = 2003
                        },
                        new
                        {
                            MovieID = 2,
                            Category = "Action/Adventure",
                            Director = "James Cameron",
                            Edited = true,
                            Rating = "PG-13",
                            Title = "Avatar, Way of Water",
                            Year = 2023
                        },
                        new
                        {
                            MovieID = 3,
                            Category = "Thriller/Action",
                            Director = "Christopher Nolan",
                            Edited = false,
                            LentTo = "Noone: I keep forever",
                            Notes = "This movie is so cool",
                            Rating = "PG-13",
                            Title = "The Prestige",
                            Year = 2006
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
