using DotnetCoreWithEF.Data;
using DotnetCoreWithEF.Models;

namespace DotnetCoreWithEF.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreDBContext _dbContext;
        public BookRepository(BookStoreDBContext dbContext)
        { 
            _dbContext = dbContext;
        }
        public async Task<int> AddBook(BookModel book)
        {
            var newBook = new Books
            {
                Titile = book.Titile,
                Author = book.Author,
                Description = book.Description,
                TotalPages = book.TotalPages,
                CreatedOn = DateTime.UtcNow,
                UpdatedOn = DateTime.UtcNow,
                Language= book.Language
            };
            await _dbContext.Books.AddAsync(newBook);
            await _dbContext.SaveChangesAsync();
            return newBook.Id;
        }
        public List<BookModel> GetAllBooks()
        {
            var books = new List<BookModel>();
            var data = _dbContext.Books.ToList();
            if (data?.Any() == true)
            {
                foreach (var record in data)
                {
                    books.Add(new BookModel 
                    {
                        Id=record.Id,
                        Titile=record.Titile,
                        Author = record.Author,
                        Description = record.Description,
                        TotalPages = record.TotalPages
                    });
                }
            }
            return books;
        }
        public BookModel GetBook(int id)
        {
            var book= _dbContext.Books.Where(x=>x.Id==id).FirstOrDefault();
            return new BookModel
            {
                Id = book.Id,
                Titile=book.Titile,
                Author=book.Author, 
                Description=book.Description,   
                TotalPages = book.TotalPages,
                Language=book.Language
            };

        }

        public List<BookModel> SearchBooks(string bookTitle, string bookAuthor)
        {
            return DataList()
                .Where(x => x.Titile.Contains(bookTitle) && x.Author.Contains(bookAuthor))
                .ToList();

        }

        public List<BookModel> DataList()
        {
            return new List<BookModel>()
            {
                new BookModel(){Id=101,Titile="Java",Author="zain",Category="IT"},
                new BookModel(){Id=102,Titile="C#",Author="Ajmal",Category=""},
                new BookModel(){Id=103,Titile="Asp.Net",Author="Adeel",Category=""},
                new BookModel(){Id=104,Titile="Android",Author="Naeem",Category=""},
                new BookModel(){Id=105,Titile="Kotlin",Author="Usman",Category=""},
                new BookModel(){Id=106,Titile="SQL-SERVER",Author="zain",Category=""},
                new BookModel(){Id=107,Titile="VB",Author="Kareem Bux",Category=""}
            };

        }
    }
}
