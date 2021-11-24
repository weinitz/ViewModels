using System;
using System.Collections.Generic;

namespace ViewModels.Models
{
    public class PeopleRepository
    {
        private static readonly List<Person> People = new List<Person>();
        private static int _idCounter;

        public void Seed()
        {
            var people = new PeopleRepository();
            people.Add(
                name: "Tim",
                city: "Halmstad",
                phoneNumber: "112"
            ).Add(
                name: "Johan",
                city: "Laholm",
                phoneNumber: "114114"
            );
        }


        public PeopleRepository Add(string name, string city, string phoneNumber)
        {
            var person = new Person(id: _idCounter, name: name, city: city, phoneNumber: phoneNumber);
            People.Add(person);
            _idCounter++;

            return this;
        }

        public PeopleRepository Delete(Person person)
        {
            People.Remove(person);
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
            return People;
        }

        public Person GetById(int id)
        {
            var person = People.Find(person => person.Id.Equals(id));
            if (person == null)
                throw new ArgumentOutOfRangeException();
            return person;
        }
    }
}