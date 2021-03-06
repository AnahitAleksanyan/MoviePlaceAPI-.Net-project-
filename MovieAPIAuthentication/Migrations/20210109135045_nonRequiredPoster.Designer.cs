// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieAPIAuthentication.Models;

namespace MovieAPIAuthentication.Migrations
{
    [DbContext(typeof(MovieDBContext))]
    [Migration("20210109135045_nonRequiredPoster")]
    partial class nonRequiredPoster
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("MovieAPIAuthentication.Models.Actor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2")
                        .HasColumnName("Date_Of_Birth");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "CountryId" }, "IX_Actors_CountryId");

                    b.ToTable("Actors");
                });

            modelBuilder.Entity("MovieAPIAuthentication.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("MovieAPIAuthentication.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("MovieAPIAuthentication.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Population")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("MovieAPIAuthentication.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<decimal>("Budget")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Created_Date");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Length")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PosterId")
                        .HasColumnType("int");

                    b.Property<string>("ProducerName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Producer_Name");

                    b.Property<string>("Rating")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Start_Date");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "CategoryId" }, "IX_Movies_CategoryId");

                    b.HasIndex(new[] { "CompanyId" }, "IX_Movies_CompanyId");

                    b.HasIndex(new[] { "CountryId" }, "IX_Movies_CountryId");

                    b.HasIndex(new[] { "PosterId" }, "IX_Movies_PosterId")
                        .IsUnique();

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("MovieAPIAuthentication.Models.MovieActorCast", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("ActorId")
                        .HasColumnType("int");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "ActorId" }, "IX_MovieActorCasts_ActorId");

                    b.HasIndex(new[] { "MovieId" }, "IX_MovieActorCasts_MovieId");

                    b.ToTable("MovieActorCasts");
                });

            modelBuilder.Entity("MovieAPIAuthentication.Models.MovieUserCast", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "MovieId" }, "IX_MovieActorCasts_MovieId")
                        .HasDatabaseName("IX_MovieActorCasts_MovieId1");

                    b.HasIndex(new[] { "UserId" }, "IX_MovieActorCasts_UserId");

                    b.ToTable("TbImovieUsers");
                });

            modelBuilder.Entity("MovieAPIAuthentication.Models.Poster", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<byte[]>("File")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Posters");
                });

            modelBuilder.Entity("MovieAPIAuthentication.Models.TbIuser", b =>
                {
                    b.Property<string>("Username")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("DateOfBirth")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("('0001-01-01T00:00:00.0000000')");

                    b.Property<string>("Email")
                        .HasMaxLength(150)
                        .IsUnicode(false)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("FullName")
                        .HasMaxLength(150)
                        .IsUnicode(false)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasDefaultValueSql("('')");

                    b.Property<string>("Password")
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValueSql("(N'')");

                    b.Property<string>("Salt")
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.HasKey("Username");

                    b.ToTable("tbIUser");
                });

            modelBuilder.Entity("MovieAPIAuthentication.Models.Actor", b =>
                {
                    b.HasOne("MovieAPIAuthentication.Models.Country", "Country")
                        .WithMany("Actors")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("MovieAPIAuthentication.Models.Movie", b =>
                {
                    b.HasOne("MovieAPIAuthentication.Models.Category", "Category")
                        .WithMany("Movies")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieAPIAuthentication.Models.Company", "Company")
                        .WithMany("Movies")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieAPIAuthentication.Models.Country", "Country")
                        .WithMany("Movies")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieAPIAuthentication.Models.Poster", "Poster")
                        .WithOne("Movie")
                        .HasForeignKey("MovieAPIAuthentication.Models.Movie", "PosterId");

                    b.Navigation("Category");

                    b.Navigation("Company");

                    b.Navigation("Country");

                    b.Navigation("Poster");
                });

            modelBuilder.Entity("MovieAPIAuthentication.Models.MovieActorCast", b =>
                {
                    b.HasOne("MovieAPIAuthentication.Models.Actor", "Actor")
                        .WithMany("MovieActorCasts")
                        .HasForeignKey("ActorId")
                        .IsRequired();

                    b.HasOne("MovieAPIAuthentication.Models.Movie", "Movie")
                        .WithMany("MovieActorCasts")
                        .HasForeignKey("MovieId")
                        .IsRequired();

                    b.Navigation("Actor");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("MovieAPIAuthentication.Models.MovieUserCast", b =>
                {
                    b.HasOne("MovieAPIAuthentication.Models.Movie", "Movie")
                        .WithMany("MovieUserCasts")
                        .HasForeignKey("MovieId")
                        .IsRequired();

                    b.HasOne("MovieAPIAuthentication.Models.TbIuser", "TbIuser")
                        .WithMany("MovieUserCasts")
                        .HasForeignKey("UserId");

                    b.Navigation("Movie");

                    b.Navigation("TbIuser");
                });

            modelBuilder.Entity("MovieAPIAuthentication.Models.Actor", b =>
                {
                    b.Navigation("MovieActorCasts");
                });

            modelBuilder.Entity("MovieAPIAuthentication.Models.Category", b =>
                {
                    b.Navigation("Movies");
                });

            modelBuilder.Entity("MovieAPIAuthentication.Models.Company", b =>
                {
                    b.Navigation("Movies");
                });

            modelBuilder.Entity("MovieAPIAuthentication.Models.Country", b =>
                {
                    b.Navigation("Actors");

                    b.Navigation("Movies");
                });

            modelBuilder.Entity("MovieAPIAuthentication.Models.Movie", b =>
                {
                    b.Navigation("MovieActorCasts");

                    b.Navigation("MovieUserCasts");
                });

            modelBuilder.Entity("MovieAPIAuthentication.Models.Poster", b =>
                {
                    b.Navigation("Movie");
                });

            modelBuilder.Entity("MovieAPIAuthentication.Models.TbIuser", b =>
                {
                    b.Navigation("MovieUserCasts");
                });
#pragma warning restore 612, 618
        }
    }
}
