using AutoMapper;
using PANWebApp.DAL;
using PANWebApp.DAL.DTO;
using PANWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PANWebApp.Controllers
{
    public class MoviesController : Controller
    {
        private DataAccess _dataAccess;

        public MoviesController()
        {
            _dataAccess = new DataAccess();
        }

        // GET: Movies
        public ActionResult Index()
        {
            var allMovies = _dataAccess.GetMovies();
            List<MovieViewModel> model = Mapper.Instance.Map<List<MovieViewModel>>(allMovies);

            return View(model);
        }

        // GET: Movies
        public ActionResult Edit(Guid id)
        {
            return RedirectToAction("Index");
        }

        // GET: Movies
        public ActionResult Remove(Guid id)
        {
            _dataAccess.RemoveMovie(id);
            _dataAccess.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Movies
        public ActionResult Details(Guid id)
        {
            return RedirectToAction("Index");
        }

        // GET: Movies
        public ActionResult Add()
        {
            _dataAccess.CreateNewMovie(new MovieDTO {Director = "Ktos", Title = "Cos", Year = 1970 });
            _dataAccess.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}