using Microsoft.EntityFrameworkCore;

namespace Assignment_01.Data
{
    public class VideoDbContext:DbContext
    {
        public DbSet<Video> Videos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Emcee\source\repos\CSharpAdvanceMasters\CSharpAdvanceMasters\CSharpAdvanceMasters\Assignment_01\Data\VideoDb.mdf;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Video>().HasData(
                new Video
                {
                    Id= "mss01",
                    Title= "The Shawshank Redemption",
                    Author= "Frank Darabont",
                    Description= "Directed by Frank Darabont, based on the novel Rita Hayworth and Shawshank Redemption by Stephen King.",
                    Year= "1994"
                },
                new Video {
                    Id = "mss02",
                    Title = "The Godfather",
                    Author = "Francis Ford Coppola",
                    Description = "Directed by Francis Ford Coppola, based on the novel of the same name by Mario Puzo.",
                    Year = "2016"
                },
                new Video {
                    Id = "mss03",
                    Title = "The Dark Knight",
                    Author = "Christopher Nolan",
                    Description = "Directed by Christopher Nolan, co-written by Nolan, David S. Goyer, and Jonathan Nolan. Based on the DC Comics character Batman created by Bob Kane and Bill Finger.",
                    Year = "2008"
                },
                new Video
                {
                    Id = "mss04",
                    Title = "Pulp Fiction",
                    Author = "Quentin Tarantino",
                    Description = "Written and Directed by Quentin Tarantino",
                    Year = "1994"
                },
                new Video
                {
                    Id = "mss05",
                    Title = "Goodfellas",
                    Author = "Martin Scorsese",
                    Description = "Directed by Martin Scorsese, based on the 1986 non-fiction book Wiseguy by Nicholas Pileggi.",
                    Year = "1990"
                }

                );

             
    }
        
    }
}
