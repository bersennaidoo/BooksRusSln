using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using BooksRus.Models;

namespace BooksRus.Controllers
{
    public class HomeController : Controller
    {
        private Repository<Book> data { get; set; }
        public HomeController(BookstoreContext ctx) => data = new Repository<Book>(ctx);

        public ViewResult Index()
        {
            // get a book at random
            var random = data.Get(new QueryOptions<Book> {
                OrderBy = b => EF.Functions.Random()
            });

            return View(random);
        }

        public ContentResult Register()
        {
            return Content("Registration has not been implemented yet. It is implemented in chapter 16.");
        }

    }
}
