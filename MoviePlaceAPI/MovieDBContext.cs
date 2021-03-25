using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MoviePlaceAPI.Models
{
    public partial class MovieDBContext : DbContext
    {
        public MovieDBContext()
        {
        }

        public MovieDBContext(DbContextOptions<MovieDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actor> Actors { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<MovieActorCast> MovieActorCasts { get; set; }
        public virtual DbSet<Poster> Posters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-TB1NPBD\\SQLEXPRESS;Database=MovieDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Actor>(entity =>
            {
                entity.HasIndex(e => e.CountryId, "IX_Actors_CountryId");

                entity.Property(e => e.DateOfBirth).HasColumnName("Date_Of_Birth");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Actors)
                    .HasForeignKey(d => d.CountryId);
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.HasIndex(e => e.CategoryId, "IX_Movies_CategoryId");

                entity.HasIndex(e => e.CompanyId, "IX_Movies_CompanyId");

                entity.HasIndex(e => e.CountryId, "IX_Movies_CountryId");

                entity.HasIndex(e => e.PosterId, "IX_Movies_PosterId")
                    .IsUnique();

                entity.Property(e => e.Budget).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CreatedDate).HasColumnName("Created_Date");

                entity.Property(e => e.ProducerName).HasColumnName("Producer_Name");

                entity.Property(e => e.Rating).IsRequired().HasConversion(new EnumToStringConverter<Rating>());

                entity.Property(e => e.StartDate).HasColumnName("Start_Date");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Movies)
                    .HasForeignKey(d => d.CategoryId);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Movies)
                    .HasForeignKey(d => d.CompanyId);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Movies)
                    .HasForeignKey(d => d.CountryId);

                entity.HasOne(d => d.Poster)
                    .WithOne(p => p.Movie)
                    .HasForeignKey<Movie>(d => d.PosterId);
            });

            modelBuilder.Entity<MovieActorCast>(entity =>
            {
                entity.HasIndex(e => e.ActorId, "IX_MovieActorCasts_ActorId");

                entity.HasIndex(e => e.MovieId, "IX_MovieActorCasts_MovieId");

                entity.HasOne(d => d.Actor)
                    .WithMany(p => p.MovieActorCasts)
                    .HasForeignKey(d => d.ActorId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.MovieActorCasts)
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
