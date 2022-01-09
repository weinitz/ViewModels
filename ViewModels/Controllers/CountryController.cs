using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ViewModels.Repositories;
using ViewModels.ViewModels;

namespace ViewModels.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CountryController : Controller
    {
        private readonly CountriesRepository _countriesRepository;

        public CountryController(CountriesRepository countriesRepository)
        {
            _countriesRepository = countriesRepository;
        }

        [HttpGet]
        [Route("/Countries/")]
        public IActionResult Index()
        {
            return View(_countriesRepository.GetAll());
        }

        [HttpPost]
        public IActionResult Create(CreateCountryViewModel createViewModel)
        {
            if (!ModelState.IsValid)
                return RedirectToAction(nameof(Index));
            _countriesRepository.Create(createViewModel);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _countriesRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}