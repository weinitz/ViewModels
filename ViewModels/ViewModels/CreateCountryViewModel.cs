using System.ComponentModel.DataAnnotations;

namespace ViewModels.ViewModels
{
    public class CreateCountryViewModel
    {
        [DataType(DataType.Text)]
        [Display(Name = "Country Name")]
        public string Name { get; set; }
    }
}