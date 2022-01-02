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
            var newPerson = new Person
            {
                Name = createViewModel.Name,
                City = _context.Cities.Find(createViewModel.CityId),
                PhoneNumber = createViewModel.PhoneNumber
            };

            _context.People.Add(newPerson);
            _context.SaveChanges();

            foreach (var languageId in createViewModel.Languages)
                _context.PersonLanguages.Add(new PersonLanguage
                {
                    PersonId = newPerson.Id,
                    LanguageId = languageId
                });
            _context.SaveChanges();
            return this;
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
            return _context.People.Include(person => person.City).ToList();
        }

        public Person GetById(int id)
        {
            var person = _context.People.Find(id);
            return JoinLanguages(person);
        }

        public Person GetByName(string name)
        {
            return _context.People.AsQueryable().First(e => e.Name.Equals(name));
        }

        private Person JoinLanguages(Person person)
        {
            var id = person.Id;
            var personLanguages = _context.PersonLanguages
                .Include(personLanguage => personLanguage.Language)
                .Where(thePerson => thePerson.PersonId == id);

            person.PersonLanguages = personLanguages.ToList();
            return person;
        }
    }
}