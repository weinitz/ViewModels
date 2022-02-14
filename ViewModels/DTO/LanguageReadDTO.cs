using ViewModels.Models;

namespace ViewModels.DTO
{
    public class LanguageReadDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static LanguageReadDTO FromLanguage(Language language)
        {
            return new LanguageReadDTO
            {
                Name = language.Name,
                Id = language.Id
            };
        }
    }
}