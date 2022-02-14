using System.Collections.Generic;
using System.Linq;
using ViewModels.Models;

namespace ViewModels.DTO
{
    public class PersonDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string CityName { get; set; }
        public List<string> Languages { get; set; }
        public string CountryName { get; set; }

        public static PersonDTO FromPerson(Person person)
        {
            return new PersonDTO
            {
                Id = person.Id,
                Name = person.Name,
                CityName = person.City?.Name,
                CountryName = person.City?.Country?.Name,
                PhoneNumber = person.PhoneNumber,
                Languages = person.PersonLanguages?
                    .Select(personLanguage => personLanguage?.Language?.Name).ToList()
            };
        }
    }
}