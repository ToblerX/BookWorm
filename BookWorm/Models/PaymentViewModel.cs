using BookWorm.Models;

namespace BookWorm.Models
{
    public class PaymentViewModel
    {
        public IEnumerable<Cart> CartItems { get; set; }
        public decimal TotalAmount { get; set; }
    }
}

