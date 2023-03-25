using BookStore.Models.Domain;
using BookStore.Repositories.Abstract_Interfaces_;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService bookService;
        private readonly IAuthorService authorService;
        private readonly IGenreService genreService;
        private readonly IPublisherService publisherService;

        public BookController(IBookService bService, IAuthorService aService, IGenreService gService, IPublisherService pService)
        {
            bookService = bService;
            authorService= aService;
            genreService = gService;
            publisherService= pService;
        }

        public IActionResult Add()
        {
            var model = new Book(); 
            model.AuthorList = authorService.GetAll().Select( a=> new SelectListItem{ Text = a.AuthorName, Value=a.ID.ToString()}).ToList();
            model.PublisherList = publisherService.GetAll().Select(p => new SelectListItem { Text = p.PublisherName, Value = p.ID.ToString()}).ToList();
            model.GenreList = genreService.GetAll().Select(g => new SelectListItem { Text = g.Name, Value = g.ID.ToString()}).ToList();
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(Book model)
        {
            model.AuthorList = authorService.GetAll().Select(a => new SelectListItem { Text = a.AuthorName, Value = a.ID.ToString(), Selected=a.ID==model.AuthorID}).ToList();
            model.PublisherList = publisherService.GetAll().Select(p => new SelectListItem { Text = p.PublisherName, Value = p.ID.ToString(), Selected = p.ID == model.PublisherID}).ToList();
            model.GenreList = genreService.GetAll().Select(g => new SelectListItem { Text = g.Name, Value = g.ID.ToString(), Selected = g.ID == model.GenreID}).ToList();

            if (!ModelState.IsValid) return View(model);

            var result = bookService.Add(model);
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
            var model = bookService.FindByID(id);
            model.AuthorList = authorService.GetAll().Select(a => new SelectListItem { Text = a.AuthorName, Value = a.ID.ToString(), Selected = a.ID == model.AuthorID }).ToList();
            model.PublisherList = publisherService.GetAll().Select(p => new SelectListItem { Text = p.PublisherName, Value = p.ID.ToString(), Selected = p.ID == model.PublisherID }).ToList();
            model.GenreList = genreService.GetAll().Select(g => new SelectListItem { Text = g.Name, Value = g.ID.ToString(), Selected = g.ID == model.GenreID }).ToList();
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(Book model)
        {
            model.AuthorList = authorService.GetAll().Select(a => new SelectListItem { Text = a.AuthorName, Value = a.ID.ToString(), Selected = a.ID == model.AuthorID }).ToList();
            model.PublisherList = publisherService.GetAll().Select(p => new SelectListItem { Text = p.PublisherName, Value = p.ID.ToString(), Selected = p.ID == model.PublisherID }).ToList();
            model.GenreList = genreService.GetAll().Select(g => new SelectListItem { Text = g.Name, Value = g.ID.ToString(), Selected = g.ID == model.GenreID }).ToList();

            if (!ModelState.IsValid) return View(model);

            var result = bookService.Update(model);
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
            var result = bookService.Delete(id);
            return RedirectToAction("GetAll");
        }

        public IActionResult GetAll(int id)
        {
            var data = bookService.GetAll();
            return View(data);
        }
    }
}