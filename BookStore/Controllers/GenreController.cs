using BookStore.Models.Domain;
using BookStore.Repositories.Abstract_Interfaces_;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class GenreController : Controller
    {
        private readonly IGenreService _genreService;

        public GenreController(IGenreService service)
        {
            _genreService = service;
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Genre model)
        {
            if (!ModelState.IsValid) return View(model);

            var result = _genreService.Add(model);
            if (result)
            {
                TempData["msg"] = "Added successfully!";
                return RedirectToAction(nameof(Add));
            }
            TempData["msg"] = "Error has occured!";
            return View(model);
        }

        public IActionResult Update(int id)
        {
            var record = _genreService.FindByID(id);
            return View(record);
        }

        [HttpPost]
        public IActionResult Update(Genre model)
        {
            if (!ModelState.IsValid) return View(model);

            var result = _genreService.Update(model);
            if (result)
            {
                TempData["msg"] = "Updated successfully!";
                return RedirectToAction(nameof(Add));
            }
            TempData["msg"] = "Error has occured!";
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var result = _genreService.Delete(id);
            return RedirectToAction("GetAll");
        }

        public IActionResult GetAll(int id)
        {
            var data = _genreService.GetAll();
            return View(data);
        }
    }
}