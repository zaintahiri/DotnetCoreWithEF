using DotnetCoreWithEF.Data;
using DotnetCoreWithEF.Models;
using Microsoft.Extensions.Configuration;

namespace DotnetCoreWithEF.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreDBContext _dbContext;
        private readonly IConfiguration _configuration;
        public BookRepository(BookStoreDBContext dbContext,IConfiguration configuration)
        { 
            _dbContext = dbContext;
            _configuration = configuration; 
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
                LanguageId = book.LanguageId,
                CoverPhotoUrl=book.CoverPhotoUrl,
                BookPdfURL=book.BookPdfURL
            };

            newBook.BookGallery=new List<BookGallery>();
            foreach (var gallery in book.GalleryModels)
            {
                newBook.BookGallery.Add(new BookGallery()
                {
                    Name= gallery.Name,
                    URL= gallery.URL
                });
            }
            await _dbContext.Books.AddAsync(newBook);
            await _dbContext.SaveChangesAsync();
            return newBook.Id;
        }
        public List<BookModel> GetAllBooks()
        {
            //var books = new List<BookModel>();
            //sdfasd
            var data = _dbContext.Books.Select(book => new BookModel
            {
                Id = book.Id,
                Titile = book.Titile,
                Author = book.Author,
                Description = book.Description,
                TotalPages = book.TotalPages,
                LanguageId = book.LanguageId,
                Language = book.Language.Name,
                CoverPhotoUrl = book.CoverPhotoUrl,
                BookPdfURL=book.BookPdfURL
            }).ToList();
           
            return data;
        }
        public BookModel GetBook(int id)
        {
            var book= _dbContext.Books.Where(x=>x.Id==id).Select(book=> new BookModel
            {
                Id = book.Id,
                Titile = book.Titile,
                Author = book.Author,
                Description = book.Description,
                TotalPages = book.TotalPages,
                LanguageId = book.LanguageId,
                Language = book.Language.Name,
                CoverPhotoUrl = book.CoverPhotoUrl,
                GalleryModels = book.BookGallery.Select(x => new GalleryModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    URL = x.URL
                }).ToList(),
                BookPdfURL=book.BookPdfURL
            }).FirstOrDefault();
            return  book;

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

        public List<BookModel> GetTopBooks(int count)
        {
            var data = _dbContext.Books.Select(book => new BookModel
            {
                Id = book.Id,
                Titile = book.Titile,
                Author = book.Author,
                Description = book.Description,
                TotalPages = book.TotalPages,
                LanguageId = book.LanguageId,
                Language = book.Language.Name,
                CoverPhotoUrl = book.CoverPhotoUrl,
                BookPdfURL = book.BookPdfURL
            }).Take(count).ToList();

            return data;
        }

        public string GetAppName()
        {
            return _configuration["AppName"].ToString();
        }
    }
}
