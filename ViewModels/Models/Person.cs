using System.ComponentModel.DataAnnotations;

namespace ViewModels.Models
{
    public class Person
    {
        public int Id;

        [Required] public string Name;
        [Required] public string PhoneNumber;
        [Required] public string City;

        public Person(int id, string name, string phoneNumber, string city)
        {
            Id = id;
            Name = name;
            PhoneNumber = phoneNumber;
            City = city;
        }
    }
}