using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ViewModels.ViewModels
{
    public class CreatePersonViewModel
    {
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter a name.")]
        [MaxLength(50)]
        [MinLength(2)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter a phone number.")]
        [MaxLength(50)]
        [MinLength(2)]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        [Required] [DisplayName("City")] public int CityId { get; set; }
        [Required] public List<int> Languages { get; set; }
    }
}