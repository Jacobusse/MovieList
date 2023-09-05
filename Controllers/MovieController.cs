using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MovieList.Models;

namespace MovieList.Controllers;

public class MovieController : Controller
{
    private readonly MovieContext _db;
    private readonly ILogger<HomeController> _logger;

    public MovieController(MovieContext db, ILogger<HomeController> logger)
    {
        _db = db;
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Add()
    {
        return View("Edit", new Movie());
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var movie = _db.Movies.SingleOrDefault(m => m.MovieId == id);
        return View(movie);
    }

    [HttpPost]
    public IActionResult Edit(Movie movie)
    {
        if (!ModelState.IsValid) {
            return View(movie);
        }

        if (movie.MovieId == 0) {
            _db.Movies.Add(movie);
        } else {
            _db.Movies.Update(movie);
        }

        _db.SaveChanges();
        return RedirectToAction("Index", "Home");
    }
}
