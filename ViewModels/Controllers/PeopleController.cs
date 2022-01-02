using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ViewModels.Models;
using ViewModels.Repositories;
using ViewModels.ViewModels;

namespace ViewModels.Controllers
{
    public class PeopleController : Controller
    {
        private readonly CitiesRepository _citiesRepository;
        private readonly LanguageRepository _languagesRepository;
        private readonly PeopleRepository _peopleRepository;

        public PeopleController(PeopleRepository peopleRepository, CitiesRepository citiesRepository,
            LanguageRepository languagesRepository)
        {
            _peopleRepository = peopleRepository;
            _citiesRepository = citiesRepository;
            _languagesRepository = languagesRepository;
        }

        // GET
        public IActionResult Index()
        {
            ViewBag.Cities = _citiesRepository.GetAll();
            ViewBag.Languages = _languagesRepository.GetAll();
            return View(new PeopleViewModel
            {
                People = _peopleRepository.GetAll().OrderBy(person => person.Id).ToList()
            });
        }

        private static List<LanguageViewModel> LanguageViewModelsFromPerson(Person person)
        {
            return person.PersonLanguages.Select(personLanguage =>
                    new LanguageViewModel
                    {
                        Name = personLanguage.Language.Name, Id = personLanguage.Language.Id
                    })
                .ToList();
        }

        [HttpGet]
        [Route("/People/{id:int}")]
        public IActionResult View(int id)
        {
            var person = _peopleRepository.GetById(id);
            return View(new PersonViewModel
            {
                Id = person.Id,
                Phone = person.PhoneNumber,
                Name = person.Name,
                Languages = LanguageViewModelsFromPerson(person)
            });
        }

        [HttpPost]
        public IActionResult Create(CreatePersonViewModel createViewModel)
        {
            ViewBag.Cities = _citiesRepository.GetAll();
            if (!ModelState.IsValid) return RedirectToAction(nameof(Index));

            _peopleRepository.Create(createViewModel);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Search(SearchPersonViewModel searchPersonViewModel)
        {
            if (!ModelState.IsValid) return RedirectToAction(nameof(Index));

            return View("Index", new PeopleViewModel
            {
                People = _peopleRepository
                    .GetAll()
                    .FindAll(person =>
                        person.Name.Contains(searchPersonViewModel.Query, StringComparison.CurrentCultureIgnoreCase) ||
                        person.City.Name.Contains(searchPersonViewModel.Query,
                            StringComparison.CurrentCultureIgnoreCase)
                    )
            });
        }

        public IActionResult Delete(int id)
        {
            var person = _peopleRepository.GetById(id);
            _peopleRepository.Delete(person);

            return RedirectToAction("Index");
        }
    }
}