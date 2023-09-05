using Microsoft.EntityFrameworkCore;

namespace MovieList.Models;

public class Genre
{
    public char GenreKey { get; set; }

    public string? Name { get; set; }

    public List<Movie>? Movies { get; }
}