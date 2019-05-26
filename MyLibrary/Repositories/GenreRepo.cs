using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyLibrary.Models;
using MyLibrary.Repositories.Interfaces;
using System.Data.Entity;
using PagedList.Mvc;
using PagedList;
namespace MyLibrary.Repositories
{
    public class GenreRepo : IGenreRepo
    {
        private readonly LibraryContext _context;

        public GenreRepo()
        {
            _context = new LibraryContext();
        }

        public IEnumerable<Genre> GetGenres()
        {
            return _context.Genres;
        }

        public IPagedList<Genre> GetGenresPaginated(int? page, int pageSize)
        {
            return GetGenres().OrderBy(x=>x.Name).ToPagedList(page?? 1, pageSize);
        }

        public Genre GetById(int id)
        {
            return _context.Genres.Find(id);
        }

        public void Add(Genre genre)
        {
            _context.Genres.Add(genre);
            _context.SaveChanges();
        }

        public void Update(Genre genre)
        {
            _context.Entry(genre).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Genres.Remove(_context.Genres.Find(id));
            _context.SaveChanges();
        }
    }
}