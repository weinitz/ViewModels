using System.Collections.Generic;
using System.Linq;
using ViewModels.DataAccess;
using ViewModels.Models;
using ViewModels.ViewModels;

namespace ViewModels.Repositories
{
    public class LanguageRepository : IRepository<Language, CreateLanguageViewModel>
    {
        private readonly ApplicationContext _context;

        public LanguageRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IRepository<Language, CreateLanguageViewModel> Create(CreateLanguageViewModel createViewModel)
        {
            _context.Languages.Add(
                new Language
                {
                    Name = createViewModel.Name
                });
            _context.SaveChanges();
            return this;
        }

        public IRepository<Language, CreateLanguageViewModel> Delete(Language language)
        {
            _context.Languages.Remove(language);
            _context.SaveChanges();
            return this;
        }

        public IRepository<Language, CreateLanguageViewModel> Delete(int id)
        {
            var person = GetById(id);
            return Delete(person);
        }

        public List<Language> GetAll()
        {
            return _context.Languages.ToList();
        }

        public Language GetById(int id)
        {
            return _context.Languages.Find(id);
        }

        public Language GetByName(string name)
        {
            return _context.Languages.First(language => language.Name.Equals(name));
        }
    }
}