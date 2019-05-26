using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLibrary.Models;
using PagedList;
using PagedList.Mvc;
namespace MyLibrary.Repositories.Interfaces
{
    public interface IBookRepo
    {
        IEnumerable<Book> GetBooks(string title, int? authorId, int? genreId);
        IPagedList<Book> GetBooksPaginated(string title, int? authorId, int? genreId, int? page, int pageSize);

        Book GetById(int id);

        void Add(Book book);

        void Update(Book book);

        void Delete(int id);

        bool IsExistingISBN(string isbn, int id);
    }
}
