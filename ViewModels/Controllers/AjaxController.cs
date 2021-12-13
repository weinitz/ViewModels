using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ViewModels.Models;

namespace ViewModels.Controllers
{
    public class AjaxController : Controller
    {
        private readonly PeopleRepository _peopleRepository;

        public AjaxController(PeopleRepository peopleRepository)
        {
            _peopleRepository = peopleRepository;
        }

        public IActionResult Index()
        {
            var people = _peopleRepository;
            var listViewModel = new PersonViewModel { PeopleListView = people.Read() };
            //            if (listViewModel.PeopleListView.Count == 0 || listViewModel.PeopleListView == null) people.Seed();
            return View();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var repository = _peopleRepository;
            var list = repository.Read();
            return PartialView("_PeopleListPartial", list);
        }

        [HttpPost]
        public IActionResult FindById(int id)
        {
            var repository = _peopleRepository;
            var person = repository.GetById(id);
            var people = new List<Person>();
            if (person != null) people.Add(person);

            return PartialView("_peopleListPartial", people);
        }

        [HttpPost]
        public IActionResult DeleteById(int id)
        {
            var repository = _peopleRepository;
            try
            {
                repository.Delete(id);
                return StatusCode(200);
            }
            catch
            {
                return StatusCode(404);
            }
        }
    }
}