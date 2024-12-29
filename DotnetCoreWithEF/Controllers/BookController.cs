using DotnetCoreWithEF.Models;
using DotnetCoreWithEF.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            var model = new BookModel
            {
                Language = "Sindhi"
            };
            ViewBag.IsSuccess = isSuccess;
            ViewBag.Id=id;
            //ViewBag.Lanuages = new List<string>
            //{
            //    "English","Urdu","Sindhi"
            //};

            //ViewBag.Lanuages = new SelectList(new List<string> { "Sindhi", "English", "Urdu" });
            ViewBag.Lanuages=new SelectList(GetLanguages(), "Id", "Language");
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(BookModel book)
        {
            if (ModelState.IsValid)
            {
                int id = await _repository.AddBook(book);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddBook), new { isSuccess = true, id = id });
                }

            }
            ViewBag.IsSuccess = false;
            ViewBag.Id = 0;
            //ViewBag.Lanuages = new List<string>
            //{
            //    "English","Urdu","Sindhi"
            //};
            ViewBag.Lanuages = new SelectList(GetLanguages(), "Id", "Language");
            return View();
        }

        private List<LanguageModel> GetLanguages()
        {
            return new List<LanguageModel>()
            {
                new LanguageModel(){ Id=1,Language="Sindhi"},
                new LanguageModel(){ Id=2,Language="English"},
                new LanguageModel(){ Id=3,Language="Urdu"},
                new LanguageModel(){ Id=4,Language="Siraiki"}
            };
        }
    }
}
