using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ViewModels.Models;
using ViewModels.Repositories;
using ViewModels.ViewModels;

namespace ViewModels.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CityController : Controller
    {
        private readonly IRepository<City, CreateCityViewModel> _citiesRepository;
        private readonly IRepository<Country, CreateCountryViewModel> _countriesRepository;

        public CityController(CitiesRepository citiesRepository, CountriesRepository countriesRepository)
        {
            _citiesRepository = citiesRepository;
            _countriesRepository = countriesRepository;
        }

        [HttpGet]
        [Route("/Cities/")]
        public IActionResult Index()
        {
            ViewBag.Countries = _countriesRepository.GetAll();
            return View(_citiesRepository.GetAll());
        }

        public IActionResult Create(CreateCityViewModel model)
        {
            if (!ModelState.IsValid) return RedirectToAction(nameof(Index));
            _citiesRepository.Create(model);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _citiesRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}