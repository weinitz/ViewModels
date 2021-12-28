using System.ComponentModel.DataAnnotations;

namespace ViewModels.Models
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
        [Required(ErrorMessage = "Please enter a phonenumber.")]
        [MaxLength(50)]
        [MinLength(2)]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter a city.")]
        [MaxLength(50)]
        [MinLength(2)]
        [Display(Name = "City")]
        public City City { get; set; }
    }
}