using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyLibrary.Models;
using MyLibrary.Repositories.Interfaces;
using System.Data.Entity;
using PagedList;
using PagedList.Mvc;
namespace MyLibrary.Repositories
{
    public class AuthorRepo : IAuthorRepo
    {
        private readonly LibraryContext _context;

        public AuthorRepo()
        {
            _context = new LibraryContext();
        }

        public IEnumerable<Author> GetAuthors()
        {
            return _context.Authors;
        }

        public IPagedList<Author> GetAuthorsPaginated(int? page, int pageSize)
        {
            return GetAuthors().OrderBy(x => x.FirstName).ThenBy(x => x.LastName).ToPagedList(page?? 1, pageSize);
        }

        public Author GetById(int id)
        {
            return _context.Authors.Find(id);
        }

        public void Add(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
        }

        public void Update(Author author)
        {
            _context.Entry(author).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Authors.Remove(_context.Authors.Find(id));
            _context.SaveChanges();
        }
    }
}