using System.ComponentModel.DataAnnotations;

namespace ViewModels.ViewModels
{
    public class CreateLanguageViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        [MaxLength(150)]
        public string Name { get; set; }
    }
}