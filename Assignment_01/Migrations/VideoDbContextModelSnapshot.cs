﻿// <auto-generated />
using Assignment_01.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Assignment_01.Migrations
{
    [DbContext(typeof(VideoDbContext))]
    partial class VideoDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Assignment_01.Video", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Year")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Videos");

                    b.HasData(
                        new
                        {
                            Id = "mss01",
                            Author = "Frank Darabont",
                            Description = "Directed by Frank Darabont, based on the novel Rita Hayworth and Shawshank Redemption by Stephen King.",
                            IsAvailable = true,
                            Title = "The Shawshank Redemption",
                            Year = "1994"
                        },
                        new
                        {
                            Id = "mss02",
                            Author = "Francis Ford Coppola",
                            Description = "Directed by Francis Ford Coppola, based on the novel of the same name by Mario Puzo.",
                            IsAvailable = true,
                            Title = "The Godfather",
                            Year = "2016"
                        },
                        new
                        {
                            Id = "mss03",
                            Author = "Christopher Nolan",
                            Description = "Directed by Christopher Nolan, co-written by Nolan, David S. Goyer, and Jonathan Nolan. Based on the DC Comics character Batman created by Bob Kane and Bill Finger.",
                            IsAvailable = true,
                            Title = "The Dark Knight",
                            Year = "2008"
                        },
                        new
                        {
                            Id = "mss04",
                            Author = "Quentin Tarantino",
                            Description = "Written and Directed by Quentin Tarantino",
                            IsAvailable = true,
                            Title = "Pulp Fiction",
                            Year = "1994"
                        },
                        new
                        {
                            Id = "mss05",
                            Author = "Martin Scorsese",
                            Description = "Directed by Martin Scorsese, based on the 1986 non-fiction book Wiseguy by Nicholas Pileggi.",
                            IsAvailable = true,
                            Title = "Goodfellas",
                            Year = "1990"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}