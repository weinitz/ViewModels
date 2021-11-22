using System.Collections.Generic;

namespace ViewModels.Models
{
    public class PersonViewModel : CreatePersonViewModel
    {
        public PersonViewModel()
        {
            PeopleListView = new List<Person>();
        }

        public List<Person> PeopleListView { get; set; }
        public string FilterString { get; set; }
    }
}