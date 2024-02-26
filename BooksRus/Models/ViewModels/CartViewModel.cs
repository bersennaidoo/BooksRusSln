namespace BooksRus.Models
{
    public class CartViewModel 
    {
        public IEnumerable<CartItem> List { get; set; } = new List<CartItem>();
        public double Subtotal { get; set; }
    }
}
