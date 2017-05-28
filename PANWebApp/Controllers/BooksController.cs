using AutoMapper;
using PANWebApp.DAL;
using PANWebApp.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PANWebApp.Controllers
{
    public class BooksController : Controller
    {
        private DataAccess _dataAcces;

        public BooksController()
        {
            _dataAcces = new DataAccess();
        }

        public ActionResult Index()
        {
            var allBooks = _dataAcces.GetBooks();
            List<BookViewModel> model = Mapper.Instance.Map<List<BookViewModel>>(allBooks);

            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(Guid? bookId)
        {
            var book = _dataAcces.GetBookDetails(bookId.GetValueOrDefault());
            BookViewModel model = Mapper.Instance.Map<BookViewModel>(book);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BookViewModel model)
        {
            if(ModelState.IsValid)
            {
                var item = Mapper.Map<DAL.DTO.BookDTO>(model);

                _dataAcces.UpdateBook(item);
                _dataAcces.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Details(Guid? bookId)
        {
            var item = _dataAcces.GetBookDetails(bookId.GetValueOrDefault());
            var model = Mapper.Instance.Map<BookDetailsViewModel>(item);
            return View(model);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(BookDetailsViewModel model)
        {
            return RedirectToAction("Index");
        }
    }
}