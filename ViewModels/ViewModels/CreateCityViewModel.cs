using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ViewModels.ViewModels
{
    public class CreateCityViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        [DisplayName("City Name")]
        public string Name { get; set; }

        [Required] [DisplayName("Country")] public int CountryId { get; set; }
    }
}