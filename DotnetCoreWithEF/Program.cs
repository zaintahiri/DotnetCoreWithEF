using DotnetCoreWithEF.Data;
using DotnetCoreWithEF.Models;
using DotnetCoreWithEF.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Load configuration from appsettings.json
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
//// add controllers will add all controllers in the project
//builder.Services.AddDbContext<BookStoreDBContext>(option =>
//                        option.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=BookStore;Integrated Security=True;"));

// there are different ways to read the appSettings file 

//1 way
//IConfiguration _iConfig = builder.Configuration;
//var connection = _iConfig["ConnectionStrings:DefaultConnection"];

//2 way
//var connection = builder.Configuration.GetValue<string>("ConnectionStrings:DefaultConnection");

//3 way
var appSettingsSection = builder.Configuration.GetSection("ConnectionStrings");
var connection = appSettingsSection.GetValue<string>("DefaultConnection");
builder.Services.AddDbContext<BookStoreDBContext>(option =>option.UseSqlServer("" + connection));

// Add Identity services (this is necessary for UserManager<IdentityUser>)
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<BookStoreDBContext>()
    .AddDefaultTokenProviders();

// password configuration using identity framework
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequiredLength = 7;
    options.Password.RequiredUniqueChars = 1;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
});

// if the user is not authorized and clicking any option from navbar then redirect it to login page.
// if the authorize keyword is applied on action method of any.
// you can set it in the appsettings file too

builder.Services.ConfigureApplicationCookie(config =>
{
    //config.LoginPath = "/signin";
    config.LoginPath = builder.Configuration["Application:LoginPath"];
});

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<ILanguageRepository,LanguageRepository>();
builder.Services.AddScoped<IMessageRepository, MessageRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();

builder.Services.Configure<NewBookAlertConfig>("NewBookAlert", builder.Configuration.GetSection("NewBookAlert"));
builder.Services.Configure<NewBookAlertConfig>("ThirdPartyBook", builder.Configuration.GetSection("ThirdPartyBook"));

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
app.UseAuthentication();
app.UseAuthorization();
app.Run();
