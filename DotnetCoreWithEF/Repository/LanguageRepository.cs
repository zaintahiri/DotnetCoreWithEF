using DotnetCoreWithEF.Data;
using DotnetCoreWithEF.Models;

namespace DotnetCoreWithEF.Repository
{
    public class LanguageRepository:ILanguageRepository
    {
        private BookStoreDBContext _dbContext;
        public LanguageRepository(BookStoreDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<int> AddLanguage(LanguageModel language)
        {
            throw new NotImplementedException();
        }

        public List<LanguageModel> DataList()
        {
            throw new NotImplementedException();
        }

        public List<LanguageModel> GetAllLanguages()
        {
            var languages = new List<LanguageModel>();
            var list= _dbContext.Languages.ToList();

            foreach (var language in list)
            {
                languages.Add(new LanguageModel 
                { 
                
                    Id = language.Id,
                    Language=language.Name,
                    Description=language.Description
                });
            }
            return languages;
        }

        public LanguageModel GetLanguage(int id)
        {
            throw new NotImplementedException();
        }

        public List<LanguageModel> SearchLanguage(string languageName)
        {
            throw new NotImplementedException();
        }
    }
}
