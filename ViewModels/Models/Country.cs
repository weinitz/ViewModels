using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ViewModels.Models
{
    public class Country
    {
        [Required] [Key] public int Id { get; set; }
        [Required] [MaxLength(100)] public string Name { get; set; }
        public List<City> Cities { get; set; } = new List<City>();
    }
}