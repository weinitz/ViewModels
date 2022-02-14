using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ViewModels.DataAccess;
using ViewModels.Models;
using ViewModels.ViewModels;

namespace ViewModels.Repositories
{
    public class PeopleRepository : IRepository<Person, CreatePersonViewModel>
    {
        private readonly ApplicationContext _context;

        public PeopleRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IRepository<Person, CreatePersonViewModel> Create(CreatePersonViewModel createViewModel)
        {
            var newPerson = Person.FromCreateViewModel(createViewModel);

            _context.People.Add(newPerson);
            _context.SaveChanges();
            return AddLanguages(newPerson, createViewModel.Languages);
        }

        public Person CreateAndReturn(CreatePersonViewModel createViewModel)
        {
            var newPerson = Person.FromCreateViewModel(createViewModel);

            _context.People.Add(newPerson);
            _context.SaveChanges();
            
            foreach (var languageId in createViewModel.Languages)
            {
                _context.PersonLanguages.Add(new PersonLanguage
                {
                    PersonId = newPerson.Id,
                    LanguageId = languageId
                });
                
            }
            _context.SaveChanges();
            return GetById(newPerson.Id);
        }

        public IRepository<Person, CreatePersonViewModel> Delete(Person person)
        {
            _context.People.Remove(person);
            _context.SaveChanges();
            return this;
        }

        public IRepository<Person, CreatePersonViewModel> Delete(int id)
        {
            var person = GetById(id);
            return Delete(person);
        }

        public List<Person> GetAll()
        {
            return _context.People
                .Include(person => person.PersonLanguages)
                .ThenInclude(personLanguage => personLanguage.Language)
                .Include(person => person.City)
                .ThenInclude(city => city.Country)
                .ToList();
        }

        public Person GetById(int id)
        {
            return _context.People
                .Include(person => person.PersonLanguages)
                .ThenInclude(personLanguage => personLanguage.Language)
                .Include(person => person.City)
                .ThenInclude(city => city.Country)
                .First(person => person.Id.Equals(id));
        }

        public Person GetByName(string name)
        {
            return _context.People
                .First(person => person.Name.Equals(name));
        }

        private IRepository<Person, CreatePersonViewModel> AddLanguages(Person person, List<int> languageIds)
        {
            foreach (var languageId in languageIds)
                _context.PersonLanguages.Add(new PersonLanguage
                {
                    PersonId = person.Id,
                    LanguageId = languageId
                });
            _context.SaveChanges();
            return this;
        }
    }
}