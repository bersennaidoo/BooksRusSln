using System.Text.Json.Serialization;

namespace BooksRus.Models
{
    public class CartItem
    {
        public BookDTO Book { get; set; } = new BookDTO();
        public int Quantity { get; set; }

        [JsonIgnore]
        public double Subtotal => Book.Price * Quantity;
    }
}

