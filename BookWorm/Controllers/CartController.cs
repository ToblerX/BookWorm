using BookWorm.Models;
using BookWorm.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BookWorm.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public CartController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // Action to add a book to the cart
        public async Task<IActionResult> AddToCart(int bookId)
        {
            // Get the current logged-in user
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Account");  // Redirect to the login page if the user is not logged in
            }

            // Find the book by its ID
            var book = await _context.Book.FindAsync(bookId);
            if (book == null)
            {
                return NotFound("Book not found.");
            }

            // Create a new Cart item and add it to the user's cart
            var cartItem = new Cart
            {
                UserId = user.Id,
                BookId = book.Id,
                BookName = book.Title
            };

            _context.Carts.Add(cartItem);
            await _context.SaveChangesAsync();

            // After adding the book, redirect the user to the ViewCart page (their own cart)
            return RedirectToAction("ViewCart", "Cart");  // Ensure it redirects to the Cart controller
        }



        // Action to view the user's cart
        public async Task<IActionResult> ViewCart()
        {
            // Get the current logged-in user
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Account");  // Redirect to login if the user is not logged in
            }

            // Retrieve the cart items for the logged-in user
            var cartItems = await _context.Carts
                .Where(c => c.UserId == user.Id)
                .ToListAsync();

            // Pass the cart items to the ViewCart view
            return View(cartItems);
        }


        // Action to remove a book from the cart
        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(int id)
        {
            var cartItem = await _context.Carts.FindAsync(id);
            if (cartItem != null)
            {
                _context.Carts.Remove(cartItem);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("ViewCart");
        }

    }
}
