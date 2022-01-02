using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ViewModels.Models
{
    public class Language
    {
        [Key] public int Id { get; set; }
        [MaxLength(100)] public string Name { get; set; }
        public List<PersonLanguage> PersonLanguages { get; set; }
    }
}