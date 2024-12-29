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
                //Language = "Sindhi"
            };
            ViewBag.IsSuccess = isSuccess;
            ViewBag.Id=id;
            //ViewBag.Lanuages = new List<string>
            //{
            //    "English","Urdu","Sindhi"
            //};

            //1-way
            //ViewBag.Lanuages = new SelectList(new List<string> { "Sindhi", "English", "Urdu" });

            //2-way
            //ViewBag.Lanuages=new SelectList(GetLanguages(), "Id", "Language");

            //3-way
            //ViewBag.Lanuages = new List<SelectListItem>()
            //{
            //    new SelectListItem(){ Text="English",Value="1"},
            //    new SelectListItem(){ Text="Urdu",Value="2",Disabled=true},
            //    new SelectListItem(){ Text="Sindhi",Value="3",Selected=true},
            //    new SelectListItem(){ Text="Siraiki",Value="4",Disabled=true},
            //};

            //4-way
            var group1 = new SelectListGroup { Name="Group-1"};
            var group2 = new SelectListGroup { Name = "Group-2",Disabled=true};
            var group3 = new SelectListGroup { Name = "Group-3" };
            ViewBag.Lanuages = new List<SelectListItem>()
            {
                new SelectListItem(){ Text="English",Value="1",Group=group1},
                new SelectListItem(){ Text="Urdu",Value="2",Group=group2},
                new SelectListItem(){ Text="Sindhi",Value="3",Selected=true,Group=group2},
                new SelectListItem(){ Text="Siraiki",Value="4",Group=group2},
                new SelectListItem(){ Text="Balouchi",Value="5",Group=group2},
                new SelectListItem(){ Text="Punjabi",Value="6",Group=group3},
                new SelectListItem(){ Text="Pashto",Value="7",Group=group3},
                new SelectListItem(){ Text="Kashmiri",Value="8",Group=group3},
            };
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
            //ViewBag.Lanuages = new SelectList(GetLanguages(), "Id", "Language");
            //ViewBag.Lanuages = new List<SelectListItem>()
            //{
            //    new SelectListItem(){ Text="English",Value="1"},
            //    new SelectListItem(){ Text="Urdu",Value="2",Disabled=true},
            //    new SelectListItem(){ Text="Sindhi",Value="3",Selected=true},
            //    new SelectListItem(){ Text="Siraiki",Value="4",Disabled=true},
            //};

            var group1 = new SelectListGroup { Name = "Group-1" };
            var group2 = new SelectListGroup { Name = "Group-2" };
            var group3 = new SelectListGroup { Name = "Group-3" };
            ViewBag.Lanuages = new List<SelectListItem>()
            {
                new SelectListItem(){ Text="English",Value="1",Group=group1},
                new SelectListItem(){ Text="Urdu",Value="2",Disabled=true,Group=group2},
                new SelectListItem(){ Text="Sindhi",Value="3",Selected=true,Group=group2},
                new SelectListItem(){ Text="Siraiki",Value="4",Disabled=true,Group=group2},
                new SelectListItem(){ Text="Balouchi",Value="5",Selected=true,Group=group2},
                new SelectListItem(){ Text="Punjabi",Value="6",Disabled=true,Group=group3},
                new SelectListItem(){ Text="Pashto",Value="7",Selected=true,Group=group3},
                new SelectListItem(){ Text="Kashmiri",Value="8",Disabled=true,Group=group3},
            };
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
