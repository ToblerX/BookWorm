using Microsoft.AspNetCore.Mvc;
using BookWorm.Models;
using Microsoft.EntityFrameworkCore;
using BookWorm.Data;
using System.Diagnostics;

namespace BookWorm.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            // If there's a search query, redirect to the Books Index page with the search parameter
            if (!string.IsNullOrEmpty(searchString))
            {
                return RedirectToAction("Index", "Books", new { searchString });
            }

            var books = await _context.Book.ToListAsync();  // Fetch books from the database
            return View(books);  // Pass the list of books to the view
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
}
