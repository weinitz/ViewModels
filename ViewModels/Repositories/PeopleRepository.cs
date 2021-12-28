using System.Collections.Generic;
using System.Linq;
using ViewModels.DataAccess;
using ViewModels.Models;

namespace ViewModels.Repositories
{
    public class PeopleRepository : IRepository<Person, CreatePersonViewModel>
    {
        private readonly ApplicationContext _context;

        public PeopleRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IRepository<Person, CreatePersonViewModel> Create(CreatePersonViewModel createPersonViewModel)
        {
            var newPerson = new Person
            {
                Name = createPersonViewModel.Name,
                City = createPersonViewModel.City,
                PhoneNumber = createPersonViewModel.PhoneNumber
            };

            _context.People.Add(newPerson);
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
            Delete(person);
            return this;
        }

        public List<Person> GetAll()
        {
            return _context.People.ToList();
        }

        public Person GetById(int id)
        {
            return _context.People.Find(id);
        }

        public Person GetByName(string name)
        {
            return _context.People.AsQueryable().First(e => e.Name.Equals(name));
        }
    }
}