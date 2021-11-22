using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace ViewModels.Models
{
    public class PersonViewModel: CreatePersonViewModel
    {
        public List<Person> PeopleListView { get; set; }
        public string FilterString { get; set; }
        public PersonViewModel()
        {
            PeopleListView = new List<Person>();
        }
    }
}
