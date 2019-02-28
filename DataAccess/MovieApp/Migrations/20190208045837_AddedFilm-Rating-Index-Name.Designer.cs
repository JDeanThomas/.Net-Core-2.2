﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieApp.Entities;

namespace MovieApp.Migrations
{
    [DbContext(typeof(MoviesContext))]
    [Migration("20190208045837_AddedFilm-Rating-Index-Name")]
    partial class AddedFilmRatingIndexName
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MovieApp.Entities.Actor", b =>
                {
                    b.Property<int>("ActorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(45);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(45);

                    b.HasKey("ActorId");

                    b.ToTable("actor");
                });

            modelBuilder.Entity("MovieApp.Entities.ApplicationUser", b =>
                {
                    b.Property<int>("ApplicationUserId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("InvalidLoginAttempts");

                    b.Property<DateTime?>("LastLoginDate");

                    b.Property<string>("Password");

                    b.Property<string>("UserName");

                    b.HasKey("ApplicationUserId");

                    b.ToTable("ApplicationUser");
                });

            modelBuilder.Entity("MovieApp.Entities.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<string>("Name")
                        .HasMaxLength(45);

                    b.HasKey("CategoryId");

                    b.ToTable("category");
                });

            modelBuilder.Entity("MovieApp.Entities.Film", b =>
                {
                    b.Property<int>("FilmId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Rating")
                        .HasMaxLength(45);

                    b.Property<int?>("ReleaseYear")
                        .HasColumnType("int(11)");

                    b.Property<int?>("Runtime");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("FilmId");

                    b.HasIndex("Rating")
                        .HasName("film_rating_index");

                    b.ToTable("film");
                });

            modelBuilder.Entity("MovieApp.Entities.FilmActor", b =>
                {
                    b.Property<int>("FilmId")
                        .HasColumnType("int(11)");

                    b.Property<int>("ActorId")
                        .HasColumnType("int(11)");

                    b.HasKey("FilmId", "ActorId");

                    b.HasIndex("ActorId")
                        .HasName("film_actor_actor_idx");

                    b.ToTable("film_actor");
                });

            modelBuilder.Entity("MovieApp.Entities.FilmCategory", b =>
                {
                    b.Property<int>("FilmId")
                        .HasColumnType("int(11)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int(11)");

                    b.HasKey("FilmId", "CategoryId");

                    b.HasIndex("CategoryId")
                        .HasName("film_category_category_fk_idx");

                    b.ToTable("film_category");
                });

            modelBuilder.Entity("MovieApp.Entities.FilmImage", b =>
                {
                    b.Property<int>("FilmImageId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("FilmId");

                    b.Property<string>("ImageUrl");

                    b.Property<string>("Title");

                    b.HasKey("FilmImageId");

                    b.HasIndex("FilmId");

                    b.ToTable("FilmImage");
                });

            modelBuilder.Entity("MovieApp.Entities.FilmActor", b =>
                {
                    b.HasOne("MovieApp.Entities.Actor", "Actor")
                        .WithMany("FilmActor")
                        .HasForeignKey("ActorId")
                        .HasConstraintName("film_actor_actor");

                    b.HasOne("MovieApp.Entities.Film", "Film")
                        .WithMany("FilmActor")
                        .HasForeignKey("FilmId")
                        .HasConstraintName("film_actor_film");
                });

            modelBuilder.Entity("MovieApp.Entities.FilmCategory", b =>
                {
                    b.HasOne("MovieApp.Entities.Category", "Category")
                        .WithMany("FilmCategory")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("film_category_category_fk");

                    b.HasOne("MovieApp.Entities.Film", "Film")
                        .WithMany("FilmCategory")
                        .HasForeignKey("FilmId")
                        .HasConstraintName("film_category_film_fk");
                });

            modelBuilder.Entity("MovieApp.Entities.FilmImage", b =>
                {
                    b.HasOne("MovieApp.Entities.Film", "Film")
                        .WithMany()
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
