using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MovieList.Models;

namespace MovieList.Controllers;

public class HomeController : Controller
{
    private readonly MovieContext _db;
    private readonly ILogger<HomeController> _logger;

    public HomeController(MovieContext db, ILogger<HomeController> logger)
    {
        _db = db;
        _logger = logger;
    }

    public IActionResult Index()
    {
        var movies = _db.Movies.OrderBy(m => m.Name).ToList();
        return View(movies);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
