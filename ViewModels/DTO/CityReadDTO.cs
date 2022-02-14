using ViewModels.Models;

namespace ViewModels.DTO
{
    public class CityReadDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CountryName { get; set; }
        public int CountryId { get; set; }

        public static CityReadDTO FromCity(City city)
        {
            return new CityReadDTO
            {
                Name = city.Name,
                Id = city.Id,
                CountryId = city.CountryId,
                CountryName = city.Country.Name
            };
        }
    }
}