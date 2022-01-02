using System.Collections.Generic;
using ViewModels.Models;

namespace ViewModels.ViewModels
{
    public class PeopleViewModel
    {
        public IEnumerable<Person> People { get; set; }
    }
}