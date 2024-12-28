using DotnetCoreWithEF.Models;
using DotnetCoreWithEF.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DotnetCoreWithEF.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            var categories = CategoryRepository.GetCategories();
            return View(categories);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            //if (id.HasValue)
            //    return new ContentResult { Content = id.ToString() };
            //else
            //    return new ContentResult { Content = "Null value found for ID" };
            //var categtory = new Category { Id = id.HasValue ? id.Value : 0 };
            ViewBag.Action = "Edit";
            var category = CategoryRepository.GetCategory(id.Value);
            return View(category);
        }

        [HttpPost]
        public ActionResult Edit(CategoryModel category)
        {
            if (ModelState.IsValid)
            {
                CategoryRepository.UpdateCategory(category.Id, category);
                return RedirectToAction(nameof(Index));

            }
            return View(category);

        }

        public ActionResult AddCategory()
        {
            ViewBag.Action = "AddCategory";
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(CategoryModel category)
        {
            if (ModelState.IsValid)
            {
                CategoryRepository.AddCategory(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }


        [HttpGet]
        public ActionResult DeleteCategory(int? id)
        {
            if (id.HasValue)
            {
                CategoryRepository.DeleteCategory(id.Value);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}

