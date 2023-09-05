
using Microsoft.EntityFrameworkCore;

namespace MovieList.Models;

public class MovieContext : DbContext
{
    public DbSet<Movie> Movies { get; set; } = null!;
    public DbSet<Genre> Genres { get; set; } = null!;

    public MovieContext(DbContextOptions<MovieContext> opt) : base(opt) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Genre>().HasKey(g => g.GenreKey);
        modelBuilder.Entity<Genre>()
            .HasMany(g => g.Movies)
            .WithOne(g => g.Genre)
            .HasForeignKey(m => m.GenreKey)
            .IsRequired();

        modelBuilder.Entity<Genre>().HasData(
            new Genre { GenreKey = 'A', Name = "Action" },
            new Genre { GenreKey = 'C', Name = "Comedy" },
            new Genre { GenreKey = 'D', Name = "Drama" },
            new Genre { GenreKey = 'H', Name = "Horror" },
            new Genre { GenreKey = 'M', Name = "Musical" },
            new Genre { GenreKey = 'R', Name = "RomCom" },
            new Genre { GenreKey = 'S', Name = "SciFi" }
        );

        modelBuilder.Entity<Movie>().HasData(
            new Movie
            {
                MovieId = 4,
                Name = "Casablanca",
                Year = 1942,
                Rating = 5,
                GenreKey = 'D'
            },
            new Movie
            {
                MovieId = 2,
                Name = "Wonder Woman",
                Year = 2017,
                Rating = 3,
                GenreKey = 'A'
            },
            new Movie
            {
                MovieId = 3,
                Name = "Moonstruck",
                Year = 1988,
                Rating = 4,
                GenreKey = 'R'
            }
        );
    }
}