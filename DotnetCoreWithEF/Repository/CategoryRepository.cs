using DotnetCoreWithEF.Models;

namespace DotnetCoreWithEF.Repository
{
    public static class CategoryRepository
    {
        private static List<CategoryModel> _categories = new List<CategoryModel> {
            new CategoryModel{ Id=1,Name="Beverage",Description="Beverage Category"},
            new CategoryModel{ Id=2,Name="Bakery",Description="Bakery Category"},
            new CategoryModel{ Id=3,Name="Meat",Description="Meat Category"},
        };

        public static void AddCategory(CategoryModel category)
        {
            var _maxId = _categories.Max(x => x.Id);
            category.Id = _maxId + 1;
            _categories.Add(category);

        }

        // everything done perfectly

        public static List<CategoryModel> GetCategories() => _categories;

        public static CategoryModel? GetCategory(int categoryId)
        {
            var category = _categories.FirstOrDefault(x => x.Id == categoryId);
            if (category != null)
            {
                return new CategoryModel { Id = category.Id, Name = category.Name, Description = category.Description };
            }

            return null;
        }

        public static void UpdateCategory(int categoryId, CategoryModel category)
        {
            var categoryToUpdate = _categories.FirstOrDefault(x => x.Id == categoryId);
            if (categoryToUpdate != null)
            {
                categoryToUpdate.Name = category.Name;
                categoryToUpdate.Description = category.Description;
            }
        }

        public static void DeleteCategory(int categoryId)
        {
            var cat = _categories.FirstOrDefault(x => x.Id == categoryId);
            if (cat != null)
            {
                _categories.Remove(cat);
            }
        }
    }
}
