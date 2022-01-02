using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ViewModels.ViewModels
{
    public class SearchPersonViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        [DisplayName("Search")]
        public string Query { get; set; }
    }
}