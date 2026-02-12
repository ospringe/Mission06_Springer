using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission06_Springer.Models;

namespace Mission06_Springer.Controllers;

public class HomeController : Controller
{
    // Database context used to access the Movie collection database
    private MovieCollectionContext _context;
    // Constructor that receives the database context via dependency injection
    public HomeController(MovieCollectionContext temp) // Constructor
    {
        _context = temp; // Assign injected context to a local variable
    }
    
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult GetToKnow()
    {
        return View();
    }

    // Going to the movie form page
    [HttpGet]
    public IActionResult AddMovies()
    {
        return View();
    }

    // Saving the info from the form to database
    [HttpPost]
    public IActionResult AddMovies(Movie response)
    {
        if (ModelState.IsValid)
        {
            _context.Movies.Add(response); // Add record to the database
            _context.SaveChanges(); 
            return View("Confirmation", response);
        }

        // If validation fails, show the form again with errors + the user's input still filled in
        return View(response);
    }

}