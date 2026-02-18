using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        ViewBag.Categories = _context.Categories
            .OrderBy(x => x.CategoryName)
            .ToList();
        
        return View("AddMovies", new Movie()); // Creates a new movie object that we can then "fill in"
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
        else // Invalid data
        {
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();
            
            // If validation fails, show the form again with errors + the user's input still filled in
            return View(response);
        }
    }
    
    public IActionResult MovieCollection()
    {
        // Linq
        var movies = _context.Movies
            .Include(x => x.Category)
            .OrderBy(x => x.Title).ToList();
        
        return View(movies);
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        // Getting single movie and storing in variable
        var movieToEdit = _context.Movies
            .Single(x => x.MovieId == id);

        // Load category table into bag for dropdown
        ViewBag.Categories = _context.Categories
            .OrderBy(x => x.CategoryName)
            .ToList();
        
        return View("AddMovies", movieToEdit);
    }

    [HttpPost]
    public IActionResult Edit(Movie updatedMovie)
    {
        if (ModelState.IsValid)
        {
            // Update the database and save the changes
            _context.Update(updatedMovie); // updates existing row
            _context.SaveChanges();
            return RedirectToAction("MovieCollection");
        }
        
        ViewBag.Categories = _context.Categories.OrderBy(x => x.CategoryName).ToList();
        return View("AddMovies", updatedMovie);
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        // Getting the singular movie to delete
        var movieToDelete = _context.Movies
            .Single(x => x.MovieId == id);
        
        return View(movieToDelete);
    }

    [HttpPost]
    public IActionResult Delete(Movie movie)
    {
        _context.Movies.Remove(movie); // Make the change in the temp database
        _context.SaveChanges();
        
        return RedirectToAction("MovieCollection");
    }

}