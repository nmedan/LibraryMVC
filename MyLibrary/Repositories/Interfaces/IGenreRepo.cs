using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLibrary.Models;
using PagedList.Mvc;
using PagedList;
namespace MyLibrary.Repositories.Interfaces
{
    public interface IGenreRepo
    {
        IEnumerable<Genre> GetGenres();
        IPagedList<Genre> GetGenresPaginated(int? page, int pageSize);

        Genre GetById(int id);

        void Add(Genre genre);

        void Update(Genre genre);

        void Delete(int id);
    }
}
