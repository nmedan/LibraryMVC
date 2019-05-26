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
    public class AuthorsController : Controller
    {
        // GET: Authors
        IAuthorRepo authorRepo = new AuthorRepo();
        public ActionResult Index(int? page, int pageSize = 2)
        {
            var authors = authorRepo.GetAuthorsPaginated(page, pageSize);
            return View(authors);
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Author author)
        {
            if (ModelState.IsValid)
            {
                authorRepo.Add(author);
                return RedirectToAction("Index");
            }
            return View(author);
        }

        public ActionResult Edit(int id)
        {
            var author = authorRepo.GetById(id);
            return View(author);
        }

        [HttpPost]
        public ActionResult Edit(Author author)
        {
            if (ModelState.IsValid)
            {
                authorRepo.Update(author);
                return RedirectToAction("Index");
            }
            return View(author);
        }

        public ActionResult Delete(int id)
        {
            authorRepo.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var author = authorRepo.GetById(id);
            return View(author);
        }
    }
}