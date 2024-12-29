using DotnetCoreWithEF.Data;
using DotnetCoreWithEF.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// add controllers will add all controllers in the project
builder.Services.AddDbContext<BookStoreDBContext>(option =>
                        option.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=BookStore;Integrated Security=True;"));
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<ILanguageRepository,LanguageRepository>();
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();
builder.Services.AddControllersWithViews();
var app = builder.Build();

// second way is simpler just use following line
app.MapControllers();
app.UseStaticFiles();
// first way to use Controller routing
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
//// this will give us permission use  controllers as endpoints
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllers();
//});


//app.MapGet("/", () => "Hello World!");

app.Run();
