using System.Collections.Generic;

namespace ViewModels.ViewModels
{
    public class PersonViewModel : CreatePersonViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public List<LanguageViewModel> Languages { get; set; }
    }
}