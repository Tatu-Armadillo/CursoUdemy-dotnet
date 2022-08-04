using System.Collections.Generic;
using UdemyCurso.Model;
using UdemyCurso.Repository;

namespace UdemyCurso.Services.Implementations
{
    public class BookServiceImplementations : IBookService
    {
        private readonly IBookRepository repository;
        public BookServiceImplementations(IBookRepository repository)
        {
            this.repository = repository;
        }

        public List<Book> FindAll()
        {
            return this.repository.FindAll();
        }

        public Book FindById(int id)
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

        public void Delete(int id)
        {
            this.repository.Delete(id);

        }

    }
}
