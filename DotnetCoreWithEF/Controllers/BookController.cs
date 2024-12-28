using DotnetCoreWithEF.Models;
using DotnetCoreWithEF.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DotnetCoreWithEF.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _repository;
        public BookController(IBookRepository repository)
        {
            _repository = repository;
        }

       
        public IActionResult GetAllBooks()
        {
            var books = _repository.GetAllBooks();
            return View(books);
        }

        public List<BookModel> SearchBooks(string bookTitle, string bookAuthor)
        {
            return _repository.SearchBooks(bookTitle, bookAuthor);
        }

        [HttpGet]
        public IActionResult BookDetails(int id)
        {
            var model=_repository.GetBook(id);
            return View(model);
        }

        public IActionResult AddBook(bool isSuccess=false,int id=0)
        {
            ViewBag.IsSuccess = isSuccess;
            ViewBag.Id=id;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(BookModel book)
        {
           int id= await _repository.AddBook(book);
            if (id > 0)
            {   
                return RedirectToAction(nameof(AddBook),new { isSuccess= true,id=id});
            }
            return View();
        }
    }
}
