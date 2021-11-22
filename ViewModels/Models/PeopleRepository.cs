using System.Collections.Generic;
using Microsoft.AspNetCore.Http.Connections;

namespace ViewModels.Models
{
    public class PeopleRepository
    {
        
        private static readonly List<Person> People = new List<Person>();
        private static int _idCounter;
        public void Seed()
        {
            var people = new PeopleRepository();
            people.Add("Tim", "Johan", "Michael", "Weinitz");

        }

        public PeopleRepository Add(params string[] names)
        {
            foreach (var name in names)
            {
                var person = new Person(id: _idCounter, name: name);
                People.Add(person);
                _idCounter++;                
            }

            return this;
        }

        public PeopleRepository Delete(Person person)
        { 
            People.Remove(person);
            return this;
        }

        public List<Person> Read()
        {
            return People;
        }

        public Person GetById(int id)
        {
            return People.Find(person => person.Id.Equals(id));
        }
    }
}