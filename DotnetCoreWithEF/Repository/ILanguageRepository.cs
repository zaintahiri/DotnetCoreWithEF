using DotnetCoreWithEF.Models;

namespace DotnetCoreWithEF.Repository
{
    public interface ILanguageRepository
    {
        List<LanguageModel> GetAllLanguages();
        public LanguageModel GetLanguage(int id);

        public List<LanguageModel> SearchLanguage(string languageName);

        public List<LanguageModel> DataList();
        public Task<int> AddLanguage(LanguageModel language);
    }
}
