using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ViewModels.Models
{
    public class Person
    {
        [Key] public int Id { get; set; }
        [Required] public string Name { get; set; }
        [Required] public string PhoneNumber { get; set; }
        public int CityId { get; set; }
        [Required] public City City { get; set; }
        public List<PersonLanguage> PersonLanguages { get; set; }
    }
}