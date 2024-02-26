using System.Linq;

namespace BooksRus.Models;

public static class QueryExtenstions
{
    public static IQueryable<T> PageBy<T>(this IQueryable<T> items, int pagenumber, int pagesize)
    {
        return items
            .Skip((pagenumber - 1) * pagesize)
            .Take(pagesize);
    }
}
