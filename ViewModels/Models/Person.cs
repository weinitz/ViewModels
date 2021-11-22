using System.ComponentModel.DataAnnotations;

namespace ViewModels.Models
{
    public class Person
    {
        public int Id;
        [Required]
        public string Name;

        public Person(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}