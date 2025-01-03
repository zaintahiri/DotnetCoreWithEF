using DotnetCoreWithEF.Models;

namespace DotnetCoreWithEF.Repository
{
    public interface IBookRepository
    {
            List<BookModel> GetAllBooks();
            List<BookModel> GetTopBooks(int count);
        public BookModel GetBook(int id);

            public List<BookModel> SearchBooks(string bookTitle, string bookAuthor);

            public List<BookModel> DataList();
            public Task<int> AddBook(BookModel book);
        string GetAppName();
    }
}
