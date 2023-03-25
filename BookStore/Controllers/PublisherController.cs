using BookStore.Models.Domain;
using BookStore.Repositories.Abstract_Interfaces_;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class PublisherController : Controller
    {
        private readonly IPublisherService _service;

        public PublisherController(IPublisherService service)
        {
            _service = service;
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Publisher model)
        {
            if (!ModelState.IsValid) return View(model);

            var result = _service.Add(model);
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
            var record = _service.FindByID(id);
            return View(record);
        }

        [HttpPost]
        public IActionResult Update(Publisher model)
        {
            if (!ModelState.IsValid) return View(model);

            var result = _service.Update(model);
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
            var result = _service.Delete(id);
            return RedirectToAction("GetAll");
        }

        public IActionResult GetAll(int id)
        {
            var data = _service.GetAll();
            return View(data);
        }
    }
}