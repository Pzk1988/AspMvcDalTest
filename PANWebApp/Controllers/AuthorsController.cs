using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using AutoMapper;
using PANWebApp.DAL;
using PANWebApp.DAL.DTO;
using PANWebApp.Models;

namespace PANWebApp.Controllers
{
    [Authorize]
    public class AuthorsController : Controller
    {
        private DataAccess _dataAccess;
        public AuthorsController()
        {
            _dataAccess = new DataAccess();
        }

        // GET: Authors
        public ActionResult Index()
        {
            var allAuthors = _dataAccess.GetAuthors();
            List<AuthorViewModel> model = Mapper.Instance.Map<List<AuthorViewModel>>(allAuthors);

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(AuthorDetailsViewModel authorDetails, HttpPostedFileBase ImageFile)
        {
            using (var ms = new MemoryStream())
            {
                ImageFile.InputStream.CopyTo(ms);
                authorDetails.Image = ms.ToArray();
            }

            if (ModelState.IsValid)
            {
                var authorDto = Mapper.Map<AuthorDTO>(authorDetails);
                _dataAccess.CreateNewAuthor(authorDto);
                _dataAccess.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(authorDetails);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AuthorDetailsViewModel authorDetails, HttpPostedFileBase ImageFile)
        {
            var authorDto = Mapper.Map<AuthorDTO>(authorDetails);
            if (ImageFile == null)
            {
                var authorDto2 = _dataAccess.GetAuthorDetails(authorDetails.Id);
                authorDto.Image = authorDto2.Image;
            }
            else
            {
                using(var ms = new MemoryStream())
                {
                    ImageFile.InputStream.CopyTo(ms);
                    authorDto.Image = ms.ToArray();
                }
            }

            if (ModelState.IsValid)
            {
                _dataAccess.UpdateAuthor(authorDto);
                _dataAccess.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(authorDetails);
        }

        public ActionResult Edit(Guid? authorId)
        {
            var detailedAuthor = _dataAccess.GetAuthorDetails(authorId.GetValueOrDefault());
            AuthorDetailsViewModel model = Mapper.Instance.Map<AuthorDetailsViewModel>(detailedAuthor);
            return View(model);
        }

        public FileContentResult GetAuhtorsImage(Guid? authorId)
        {

            byte[] _dummyImage = System.IO.File.ReadAllBytes(Server.MapPath("~/Content/dummy-image.jpg"));


            var detailedAuthor = _dataAccess.GetAuthorDetails(authorId.GetValueOrDefault());
            AuthorDetailsViewModel model = Mapper.Instance.Map<AuthorDetailsViewModel>(detailedAuthor);

            if (model != null && model.Id == authorId.GetValueOrDefault())
            {

                FileContentResult fcr = model.Image.Length == 0 ?
                    new FileContentResult(_dummyImage, "image/jpg") :
                    new FileContentResult(model.Image, "image/jpg");
                return fcr;
            }

            return new FileContentResult(_dummyImage, "image/jpg");
        }

        public ActionResult Details(Guid? authorId)
        {
            var detailedAuthor = _dataAccess.GetAuthorDetails(authorId.GetValueOrDefault());
            AuthorDetailsViewModel model = Mapper.Instance.Map<AuthorDetailsViewModel>(detailedAuthor);

            return View(model);
        }

        public ActionResult Delete(Guid? authorId)
        {
            _dataAccess.DeleteAuthor(authorId.GetValueOrDefault());
            _dataAccess.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}