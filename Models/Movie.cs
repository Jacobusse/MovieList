
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace MovieList.Models;

public class Movie
{
    public int MovieId { get; set; }

    public string? Name { get; set; }
    public int? Year { get; set; }
    public int? Rating { get; set; }

    public char GenreKey { get; set; }

    [ValidateNever]
    public Genre Genre { get; } = null!;
}