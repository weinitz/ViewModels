using System.Collections.Generic;
using ViewModels.ViewModels;

namespace ViewModels.Models
{
    public class PersonViewModel : CreatePersonViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public List<LanguageViewModel> Languages { get; set; }
    }
}