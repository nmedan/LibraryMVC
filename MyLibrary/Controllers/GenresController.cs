using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyLibrary.Models;
using MyLibrary.Repositories;
using MyLibrary.Repositories.Interfaces;
using PagedList;
using PagedList.Mvc;
namespace MyLibrary.Controllers
{
    public class GenresController : Controller
    {
        // GET: Genres
        IGenreRepo genreRepo = new GenreRepo();
        public ActionResult Index(int? page, int pageSize = 2)
        {
            var genres = genreRepo.GetGenresPaginated(page, pageSize);
            return View(genres);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Genre genre)
        {
            if (ModelState.IsValid)
            {
                genreRepo.Add(genre);
                return RedirectToAction("Index");
            }
            return View(genre);
        }

        public ActionResult Edit(int id)
        {
            var author = genreRepo.GetById(id);
            return View(author);
        }

        [HttpPost]
        public ActionResult Edit(Genre genre)
        {
            if (ModelState.IsValid)
            {
                genreRepo.Update(genre);
                return RedirectToAction("Index");
            }
            return View(genre);
        }

        public ActionResult Delete(int id)
        {
            genreRepo.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var genre = genreRepo.GetById(id);
            return View(genre);
        }
    }
}