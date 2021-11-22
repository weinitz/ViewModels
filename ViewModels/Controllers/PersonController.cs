using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ViewModels.Models;

namespace ViewModels.Controllers
{
    public class PersonController : Controller
    {
        // GET
        public IActionResult Index()
        {
            var people = new PeopleRepository();

            var listViewModel = new PersonViewModel {PeopleListView = people.Read()};

            if (listViewModel.PeopleListView.Count == 0 || listViewModel.PeopleListView == null) people.Seed();

            return View(listViewModel);
        }

        [HttpPost]
        public IActionResult Index(PersonViewModel viewModel)
        {
            var people = new PeopleRepository();
            viewModel.PeopleListView.Clear();

            foreach (var person in people.Read().Where(person =>
                person.Name.Contains(viewModel.FilterString, StringComparison.OrdinalIgnoreCase)))
                viewModel.PeopleListView.Add(person);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(CreatePersonViewModel createViewModel)
        {
            var viewModel = new PersonViewModel();
            var people = new PeopleRepository();

            if (ModelState.IsValid)
            {
                viewModel.PeopleListView = people.Read();
                people.Add(createViewModel.Name);
                ViewBag.Message = $"Successfully added {createViewModel.Name}!";

                return View("Index", viewModel);
            }

            ViewBag.Message = "Failed to add person" + ModelState.Values;
            return View("Index", viewModel);
        }

        public IActionResult Delete(int id)
        {
            var people = new PeopleRepository();
            var person = people.GetById(id);
            people.Delete(person);

            return RedirectToAction("Index");
        }

        public PartialViewResult CarList()
        {
            return PartialView("_peopleListPartial");
        }
    }
}