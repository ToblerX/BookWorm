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
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Challenge(); // Redirects to the configured login page
            }

            var book = await _context.Book.FindAsync(bookId);
            if (book == null)
            {
                return NotFound("Book not found.");
            }

            var cartItem = new Cart
            {
                UserId = user.Id,
                BookId = book.Id,
                BookName = book.Title,
                // Explicit cast from float to decimal
                Price = (decimal)book.Price // Casting the Price to decimal
            };

            _context.Carts.Add(cartItem);
            await _context.SaveChangesAsync();

            return RedirectToAction("ViewCart", "Cart");
        }

        // Action to view the user's cart
        public async Task<IActionResult> ViewCart()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Challenge(); // Redirects to the configured login page
            }

            var cartItems = await _context.Carts
                .Where(c => c.UserId == user.Id)
                .ToListAsync();

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
        public IActionResult Payment()
        {
            // Fetch cart items for display during payment
            var user = _userManager.GetUserAsync(User).Result;
            if (user == null)
            {
                return Challenge();
            }

            var cartItems = _context.Carts
                .Where(c => c.UserId == user.Id)
                .ToList();

            var totalAmount = cartItems.Sum(item => item.Price);

            // Mock payment page
            var paymentViewModel = new PaymentViewModel
            {
                CartItems = cartItems,
                TotalAmount = totalAmount
            };

            return View(paymentViewModel);
        }

        [HttpPost]
        public IActionResult ConfirmPayment()
        {
            // Mock payment success
            TempData["PaymentSuccess"] = "Your payment was successful! Thank you for your purchase.";

            // Optionally, clear the cart after payment
            var user = _userManager.GetUserAsync(User).Result;
            var cartItems = _context.Carts.Where(c => c.UserId == user.Id).ToList();
            _context.Carts.RemoveRange(cartItems);
            _context.SaveChanges();

            return RedirectToAction("ViewCart");
        }

    }
}
