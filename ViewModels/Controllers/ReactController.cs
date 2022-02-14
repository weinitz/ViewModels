using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ViewModels.DTO;
using ViewModels.Repositories;
using ViewModels.ViewModels;

namespace ViewModels.Controllers
{
    public class ReactController : Controller
    {
        private readonly CitiesRepository _citiesRepository;
        private readonly LanguageRepository _languageRepository;
        private readonly PeopleRepository _peopleRepository;


        public ReactController(PeopleRepository peopleRepository, LanguageRepository languageRepository,
            CitiesRepository citiesRepository)
        {
            _peopleRepository = peopleRepository;
            _languageRepository = languageRepository;
            _citiesRepository = citiesRepository;
        }

        // GET
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetFormData()
        {
            return Json(new {
                cities =_citiesRepository
                    .GetAll()
                    .Select(CityReadDTO.FromCity),
                languages = _languageRepository
                .GetAll()
                .Select(LanguageReadDTO.FromLanguage),

            });
            
            return Json(new
            {
                languages = _languageRepository
                    .GetAll()
                    .Select(LanguageReadDTO.FromLanguage),
                cities = _citiesRepository.GetAll()
            });
        }

        [HttpGet]
        [Route("/React/People")]
        public IActionResult GetPeople()
        {
            
            return Ok(
                JsonConvert
                    .SerializeObject(
                        _peopleRepository
                            .GetAll()
                            .Select(PersonDTO.FromPerson)
                    )
            );
        }

        [HttpGet]
        [Route("/React/Person/{id:int}")]
        public IActionResult GetPerson(int id)
        {
            var person = _peopleRepository.GetById(id);
            return Ok(JsonConvert.SerializeObject(
                PersonDTO.FromPerson(person)
            ));
        }

        [HttpPut]
        [Route("/React/Person/Create")]
        public IActionResult CreatePerson(CreatePersonViewModel personViewModel)
        {
            var person = _peopleRepository.CreateAndReturn(personViewModel);
            return Ok(JsonConvert.SerializeObject(
                PersonDTO.FromPerson(
                    person
                )
            ));
        }

        [HttpDelete]
        [Route("/React/Person/{Id:int}")]
        public IActionResult DeletePerson(int id)
        {
            try
            {
                _peopleRepository.Delete(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("/React/Cities")]
        public IActionResult GetCities()
        {
            return Ok(JsonConvert.SerializeObject(
                _citiesRepository
                    .GetAll()
                    .Select(CityReadDTO.FromCity)
            ));
        }

        [HttpGet]
        [Route("/React/Languages")]
        public IActionResult GetLanguages()
        {
            return Ok(JsonConvert.SerializeObject(
                _languageRepository
                    .GetAll()
                    .Select(LanguageReadDTO.FromLanguage)
            ));
        }
    }
}