using Microsoft.EntityFrameworkCore;

namespace DotnetCoreWithEF.Data
{
    public class BookStoreDBContext : DbContext
    {
        public BookStoreDBContext(DbContextOptions<BookStoreDBContext> options) : base(options)
        {

        }

        public DbSet<Books> Books { get; set; }
        public DbSet<Languages> Languages { get; set; }
        


        // either you can define connection string here, otherwise you can define in the
        // builder.Services.AddDBContext<nameofdbcontext>(option=>option.UseSqlServer("write connection string here"))
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=.;Database=BookStore;Integrated Security=True;");
        //    base.OnConfiguring(optionsBuilder);
        //}
    }
}
