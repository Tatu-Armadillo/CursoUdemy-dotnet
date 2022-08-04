using System.Collections.Generic;
using UdemyCurso.Model;

namespace UdemyCurso.Repository
{
    public interface IBookRepository
    {
        Book Create(Book person);
        List<Book> FindAll();
        Book FindById(long id);
        Book Update(Book book);
        void Delete(long id);
    }
}