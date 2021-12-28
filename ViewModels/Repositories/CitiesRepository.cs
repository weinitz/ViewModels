using System.Collections.Generic;
using System.Linq;
using ViewModels.DataAccess;
using ViewModels.Models;
using ViewModels.ViewModels;

namespace ViewModels.Repositories
{
    public class CitiesRepository : IRepository<City, CreateCityViewModel>
    {
        private readonly ApplicationContext _context;

        public CitiesRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IRepository<City, CreateCityViewModel> Create(CreateCityViewModel createViewModel)
        {
            _context.Cities.Add(
                new City {Name = createViewModel.Name, Country = _context.Countries.Find(createViewModel.CountryId)}
            );
            _context.SaveChanges();
            return this;
        }

        public IRepository<City, CreateCityViewModel> Delete(City city)
        {
            _context.Cities.Remove(city);
            _context.SaveChanges();
            return this;
        }

        public IRepository<City, CreateCityViewModel> Delete(int id)
        {
            var city = GetById(id);
            return Delete(city);
        }

        public List<City> GetAll()
        {
            return _context.Cities.ToList();
        }

        public City GetById(int id)
        {
            return _context.Cities.Find(id);
        }

        public City GetByName(string name)
        {
            return _context.Cities.First(c => c.Name.Equals(name));
        }
    }
}