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
    public class BooksController : Controller
    {
        // GET: Books
        IBookRepo bookRepo = new BookRepo();
        IAuthorRepo authorRepo = new AuthorRepo();
        IGenreRepo genreRepo = new GenreRepo();
        public ActionResult Index(string bookTitle, int? authorId, int? genreId, int? page, int pageSize = 3)
        {
            var books = bookRepo.GetBooksPaginated(bookTitle, authorId, genreId, page, pageSize);
            ViewBag.Authors = new SelectList(authorRepo.GetAuthors(), "Id", "FullName");
            ViewBag.Genres = new SelectList(genreRepo.GetGenres(), "Id", "Name");
            ViewBag.bookTitle = bookTitle;
            ViewBag.authorId = authorId;
            ViewBag.genreId = genreId;
            return View(books);
        }

        public ActionResult Create()
        {
            ViewBag.Authors = new SelectList(authorRepo.GetAuthors(), "Id", "FullName");
            ViewBag.Genres = new SelectList(genreRepo.GetGenres(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Book book)
        {
            if (bookRepo.IsExistingISBN(book.ISBN, book.Id))
            {
                ModelState.AddModelError("ISBN", "This ISBN number already exists");
            }

            if (ModelState.IsValid)
            {
                bookRepo.Add(book);
                return RedirectToAction("Index");
            }
            ViewBag.Authors = new SelectList(authorRepo.GetAuthors(), "Id", "FullName", book.AuthorId);
            ViewBag.Genres = new SelectList(genreRepo.GetGenres(), "Id", "Name", book.GenreId);
            return View(book);
        }

        public ActionResult Edit(int id)
        {
            var book = bookRepo.GetById(id);
            ViewBag.Authors = new SelectList(authorRepo.GetAuthors(), "Id", "FullName");
            ViewBag.Genres = new SelectList(genreRepo.GetGenres(), "Id", "Name");
            return View(book);
        }

        [HttpPost]
        public ActionResult Edit(Book book)
        {
            if (bookRepo.IsExistingISBN(book.ISBN, book.Id))
            {
                ModelState.AddModelError("ISBN", "This ISBN number already exists.");
            }

            if (ModelState.IsValid)
            {
                bookRepo.Update(book);
                return RedirectToAction("Index");
            }
            ViewBag.Authors = new SelectList(authorRepo.GetAuthors(), "Id", "FullName", book.AuthorId);
            ViewBag.Genres = new SelectList(genreRepo.GetGenres(), "Id", "Name", book.GenreId);

            return View(book);
        }

        public ActionResult Delete(int id)
        {
            bookRepo.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var book = bookRepo.GetById(id);
            return View(book);
        }
    }
}