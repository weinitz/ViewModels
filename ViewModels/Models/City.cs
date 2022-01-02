using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ViewModels.Models
{
    public class City
    {
        [Key] public int Id { get; set; }
        [Required] public string Name { get; set; }
        [Required] public List<Person> People { get; set; }

        [Required] public Country Country { get; set; }
        public int CountryId { get; set; }
    }
}