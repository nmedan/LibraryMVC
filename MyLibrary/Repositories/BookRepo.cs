using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyLibrary.Repositories.Interfaces;
using MyLibrary.Models;
using System.Data.Entity;
using PagedList.Mvc;
using PagedList;

namespace MyLibrary.Repositories
{
    public class BookRepo : IBookRepo
    {
        private readonly LibraryContext _context;

        public BookRepo()
        {
            _context = new LibraryContext();
        }

        public IEnumerable<Book> GetBooks(string title, int? authorId, int? genreId)
        {
            var books = _context.Books.Include(x => x.Author).Include(x => x.Genre);

            if (!String.IsNullOrEmpty(title))
            {
                books = books.Where(x => x.Title.StartsWith(title));
            }

            if (authorId != null)
            {
                books = books.Where(x => x.AuthorId == authorId);
            }

            if (genreId != null)
            {
                books = books.Where(x => x.GenreId == genreId);
            }

            return books;
        }
        public IPagedList<Book> GetBooksPaginated(string title, int? authorId, int? genreId, int? page, int pageSize)
        {
            return GetBooks(title, authorId, genreId).OrderBy(x => x.Title).ThenBy(x => x.PublishingYear).ToPagedList(page ?? 1, pageSize);
        }

        public Book GetById(int id)
        {
            return _context.Books.Find(id);
        }

        public void Add(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void Update(Book book)
        {
            _context.Entry(book).State = EntityState.Modified;
            _context.SaveChanges();
            
        }

        public void Delete(int id)
        {
            _context.Books.Remove(_context.Books.Find(id));
            _context.SaveChanges();
        }

        public bool IsExistingISBN(string isbn, int currentBookId)
        {
            return _context.Books.Any(x => x.ISBN.Equals(isbn) && x.Id != currentBookId);
        }
    }
}