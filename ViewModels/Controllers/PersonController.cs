using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ViewModels.Models;
using ViewModels.Repositories;

namespace ViewModels.Controllers
{
    public class PersonController : Controller
    {
        private readonly PeopleRepository _peopleRepository;

        public PersonController(PeopleRepository peopleRepository)
        {
            _peopleRepository = peopleRepository;
        }

        // GET
        public IActionResult Index()
        {

            var listViewModel = new PersonViewModel { PeopleListView = _peopleRepository.GetAll() };

            return View(listViewModel);
        }

        [HttpPost]
        public IActionResult Create(CreatePersonViewModel createViewModel)
        {
            var viewModel = new PersonViewModel();

            if (ModelState.IsValid)
            {
                viewModel.PeopleListView = _peopleRepository.GetAll();
                _peopleRepository.Create(createViewModel);
                ViewBag.Message = $"Successfully added {createViewModel.Name}!";

                return View("Index", viewModel);
            }

            ViewBag.Message = "Failed to add person" + ModelState.Values;
            return View("Index", viewModel);
        }

        public IActionResult Delete(int id)
        {
            var person = _peopleRepository.GetById(id);
            _peopleRepository.Delete(person);

            return RedirectToAction("Index");
        }
    }
}