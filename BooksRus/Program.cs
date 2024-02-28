using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BooksRus.Models;

namespace BooksRus;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRouting(options => options.LowercaseUrls = true);

        builder.Services.AddMemoryCache();
        builder.Services.AddSession();

        builder.Services.AddControllersWithViews();

        builder.Services.AddDbContext<BookstoreContext>(options =>
          options.UseSqlite(builder.Configuration.GetConnectionString("BookstoreContext") ?? throw new InvalidOperationException("Connection string 'LittleLemonContext' not found.")));


        builder.Services.AddHttpContextAccessor();
        //builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
        builder.Services.AddTransient<IBookRepository, BookRepository>();
        builder.Services.AddTransient<ICart, Cart>();
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseSession();

        app.UseAuthorization();

        app.MapControllerRoute(
           name: "page_sort",
           pattern: "{controller}/{action}/page/{pagenumber}/size/{pagesize}/sort/{sortfield}/{sortdirection}");

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}/{slug?}");

        app.Run();
    }
}
