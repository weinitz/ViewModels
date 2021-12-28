using System.Collections.Generic;
using System.Linq;
using ViewModels.DataAccess;
using ViewModels.Models;
using ViewModels.ViewModels;

namespace ViewModels.Repositories
{
    public class CountriesRepository : IRepository<Country, CreateCountryViewModel>
    {
        private readonly ApplicationContext _context;

        public CountriesRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IRepository<Country, CreateCountryViewModel> Create(CreateCountryViewModel createViewModel)
        {
            _context.Countries.Add(
                new Country {Name = createViewModel.Name}
            );
            _context.SaveChanges();
            return this;
        }

        public IRepository<Country, CreateCountryViewModel> Delete(Country county)
        {
            _context.Countries.Remove(county);
            _context.SaveChanges();
            return this;
        }

        public IRepository<Country, CreateCountryViewModel> Delete(int id)
        {
            var county = GetById(id);
            return Delete(county);
        }

        public List<Country> GetAll()
        {
            return _context.Countries.ToList();
        }

        public Country GetById(int id)
        {
            return _context.Countries.Find(id);
        }

        public Country GetByName(string name)
        {
            return _context.Countries.First(c => c.Name.Equals(name));
        }
    }
}