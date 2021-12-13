using System;
using System.Collections.Generic;
using System.Linq;
using ViewModels.DataAccess;

namespace ViewModels.Models
{
    public class PeopleRepository
    {
        private readonly PeopleContext _context;
        private static readonly List<Person> People = new List<Person>();
        private static int _idCounter;

        public PeopleRepository(PeopleContext context)
        {
            _context = context;
        }

        public PeopleRepository Create(CreatePersonViewModel createPersonViewModel)
        {
            var newPerson = new Person
            {
                Name = createPersonViewModel.Name,
                City = createPersonViewModel.City,
                PhoneNumber = createPersonViewModel.PhoneNumber
            };

            _context.People.Add(newPerson);
            _context.SaveChanges();
            _idCounter++;


            return this;
        }

        public PeopleRepository Delete(Person person)
        {
            _context.People.Remove(person);
            _context.SaveChanges();
            return this;
        }

        public PeopleRepository Delete(int id)
        {
            var person = GetById(id);
            Delete(person);
            return this;
        }

        public List<Person> Read()
        {
            return _context.People.ToList();
        }

        public Person GetById(int id)
        {
            return _context.People.Find(id);
            var person = People.Find(person => person.Id.Equals(id));
            if (person == null)
                throw new ArgumentOutOfRangeException();
            return person;
        }
    }
}