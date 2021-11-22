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
    }
}