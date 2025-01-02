using DotnetCoreWithEF.Models;
using DotnetCoreWithEF.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace DotnetCoreWithEF.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _repository;
        private readonly ILanguageRepository _languageRepo;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public BookController(IBookRepository repository,IWebHostEnvironment hostEnvironment,ILanguageRepository languageRepo)
        {
            _repository = repository;
            _languageRepo = languageRepo;
            _webHostEnvironment = hostEnvironment;
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
            //var group1 = new SelectListGroup { Name="Group-1"};
            //var group2 = new SelectListGroup { Name = "Group-2",Disabled=true};
            //var group3 = new SelectListGroup { Name = "Group-3" };
            //ViewBag.Lanuages = new List<SelectListItem>()
            //{
            //    new SelectListItem(){ Text="English",Value="1",Group=group1},
            //    new SelectListItem(){ Text="Urdu",Value="2",Group=group2},
            //    new SelectListItem(){ Text="Sindhi",Value="3",Selected=true,Group=group2},
            //    new SelectListItem(){ Text="Siraiki",Value="4",Group=group2},
            //    new SelectListItem(){ Text="Balouchi",Value="5",Group=group2},
            //    new SelectListItem(){ Text="Punjabi",Value="6",Group=group3},
            //    new SelectListItem(){ Text="Pashto",Value="7",Group=group3},
            //    new SelectListItem(){ Text="Kashmiri",Value="8",Group=group3},
            //};

            var languages = new SelectList(_languageRepo.GetAllLanguages() as IEnumerable<LanguageModel>, "Id", "Language");
            ViewBag.Lanuages = languages;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(BookModel book)
        {
            if (ModelState.IsValid)
            {
                if (book.CoverPhoto != null)
                {
                    var folder = "photos/cover/";
                    book.CoverPhotoUrl = await FileUrl(book.CoverPhoto, folder);
                    
                }

                if (book.GalleryPhotos != null)
                {
                    var folder = "photos/gallary/";
                    book.GalleryModels=new List<GalleryModel>();
                    foreach (var photo in book.GalleryPhotos)
                    {
                        book.GalleryModels.Add(new GalleryModel()
                        {
                            Name=photo.FileName,
                            URL= await FileUrl(photo, folder)

                        });
                    }
                    
                }

                if (book.BookPdf != null)
                {
                    var folder = "photos/pdf/";
                    book.BookPdfURL = await FileUrl(book.BookPdf, folder);

                }

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

            //var group1 = new SelectListGroup { Name = "Group-1" };
            //var group2 = new SelectListGroup { Name = "Group-2" };
            //var group3 = new SelectListGroup { Name = "Group-3" };
            //ViewBag.Lanuages = new List<SelectListItem>()
            //{
            //    new SelectListItem(){ Text="English",Value="1",Group=group1},
            //    new SelectListItem(){ Text="Urdu",Value="2",Disabled=true,Group=group2},
            //    new SelectListItem(){ Text="Sindhi",Value="3",Selected=true,Group=group2},
            //    new SelectListItem(){ Text="Siraiki",Value="4",Disabled=true,Group=group2},
            //    new SelectListItem(){ Text="Balouchi",Value="5",Selected=true,Group=group2},
            //    new SelectListItem(){ Text="Punjabi",Value="6",Disabled=true,Group=group3},
            //    new SelectListItem(){ Text="Pashto",Value="7",Selected=true,Group=group3},
            //    new SelectListItem(){ Text="Kashmiri",Value="8",Disabled=true,Group=group3},
            //};

            var languages =new SelectList(_languageRepo.GetAllLanguages() as IEnumerable<LanguageModel>,"Id", "Language");
            ViewBag.Lanuages = languages;
            return View();
        }

        private async Task<string> FileUrl(IFormFile file, string folder)
        {
            folder = folder + "" + Guid.NewGuid().ToString() + "_" + file.FileName;
            var serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
            await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
            return "/"+folder;
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
