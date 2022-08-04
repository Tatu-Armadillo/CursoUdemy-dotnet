using System.Collections.Generic;
using UdemyCurso.Model;
using UdemyCurso.Repository;

namespace UdemyCurso.Services.Implementations
{
    public class BookServiceImplementations : IBookService
    {
        private readonly IRepository<Book> repository;
        public BookServiceImplementations(IRepository<Book> repository)
        {
            this.repository = repository;
        }

        public List<Book> FindAll()
        {
            return this.repository.FindAll();
        }

        public Book FindById(long id)
        {
            return this.repository.FindById(id);
        }

        public Book Create(Book book)
        {
            return this.repository.Create(book);
        }

        public Book Update(Book book)
        {
            this.repository.Update(book);
            return book;
        }

        public void Delete(long id)
        {
            this.repository.Delete(id);

        }

    }
}
