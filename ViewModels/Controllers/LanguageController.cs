using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ViewModels.Repositories;
using ViewModels.ViewModels;

namespace ViewModels.Controllers
{
    public class LanguageController : Controller
    {
        private readonly LanguageRepository _languageRepository;

        public LanguageController(LanguageRepository languageRepository)
        {
            _languageRepository = languageRepository;
        }
        
        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("/Languages/")]
        public IActionResult Index()
        {
            var languageViewModel = _languageRepository
                .GetAll()
                .Select(language => new LanguageViewModel
                {
                    Id = language.Id, Name = language.Name
                }).ToList();
            return View(languageViewModel);
        }

        [Authorize(Roles = "Admin, User")]
        [HttpPost]
        public IActionResult Create(CreateLanguageViewModel createViewModel)
        {
            ViewBag.Cities = _languageRepository.GetAll();
            if (!ModelState.IsValid) return RedirectToAction(nameof(Index));

            _languageRepository.Create(createViewModel);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _languageRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}