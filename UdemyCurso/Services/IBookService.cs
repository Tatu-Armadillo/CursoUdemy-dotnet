using System.Collections.Generic;
using UdemyCurso.Model;

namespace UdemyCurso.Services
{
    public interface IBookService
    {
        Book Create(Book book);
        List<Book> FindAll();
        Book FindById(long id);
        Book Update(Book book);
        void Delete(long id);
    }
}
