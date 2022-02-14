using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ViewModels.ViewModels;

namespace ViewModels.Models
{
    public class Person
    {
        [Key] public int Id { get; set; }
        [Required] public string Name { get; set; }
        [Required] public string PhoneNumber { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public List<PersonLanguage> PersonLanguages { get; set; }

        public static Person FromCreateViewModel(CreatePersonViewModel createViewModel)
        {
            return new Person
            {
                Name = createViewModel.Name,
                CityId = createViewModel.CityId,
                PhoneNumber = createViewModel.PhoneNumber,
            };
        }
    }
}