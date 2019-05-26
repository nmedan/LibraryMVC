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
    public interface IAuthorRepo
    {
        IEnumerable<Author> GetAuthors();

        IPagedList<Author> GetAuthorsPaginated(int? page, int pageSize);

        Author GetById(int id);

        void Add(Author author);

        void Update(Author author);

        void Delete(int id);
    }
}
