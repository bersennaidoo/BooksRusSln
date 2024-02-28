using Microsoft.AspNetCore.Mvc;
using BooksRus.Models;

namespace BooksRus.Controllers;

public class AuthorController : Controller
{
    private Repository<Author> data { get; set; }

    public AuthorController(BookstoreContext ctx) => data = new Repository<Author>(ctx);

    public IActionResult Index() => RedirectToAction("List");

    public ViewResult List(AuthorGridData values)
    {
        // Contructs a QueryOptions thats operates on an Author for the Repository instance data.
        var options = new QueryOptions<Author> 
        {
            Includes = "Books",
            PageNumber = values.PageNumber,
            PageSize = values.PageSize,
            OrderByDirection = values.SortDirection
        };

        // Checks if values IsSortByFirstName holds or not holds then assigns lambda to options OrderBy delegate.
        if (values.IsSortByFirstName)
            options.OrderBy = a => a.FirstName;
        else
            options.OrderBy = a => a.LastName;

        // Creates a view model with an instance of the AuthorGridData Authors for the list view
        // to build the route links for sorting and paging that Repository uses to OrderBy.
        var vm = new AuthorListViewModel
        {
            Authors = data.List(options),
            CurrentRoute = values,
            TotalPages = values.GetTotalPages(data.Count)
        };

        return View(vm);
    }

    public IActionResult Details(int id)
    {
        var author = data.Get(new QueryOptions<Author> 
        {
           Where = a => a.AuthorId == id,
           Includes = "Books"
        }) ?? new Author();

        return View(author);
    }
}


