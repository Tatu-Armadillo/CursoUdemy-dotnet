using System;
using System.Collections.Generic;
using System.Linq;
using UdemyCurso.Model;
using UdemyCurso.Model.Context;

namespace UdemyCurso.Repository.Implementations
{
    public class BookRepositoryImplementations : IBookRepository
    {
        private MySQLContext context;
        public BookRepositoryImplementations(MySQLContext context)
        {
            this.context = context;
        }

        public Book Create(Book book)
        {
            try
            {
                this.context.Add(book);
                this.context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return book;
        }
        public Book FindById(long id)
        {
            return this.context.Books.SingleOrDefault(p => p.Id.Equals(id));
        }
        public bool Exists(long id)
        {
            return this.context.Books.Any(p => p.Id.Equals(id));
        }

        public List<Book> FindAll()
        {
            return this.context.Books.ToList();
        }


        public Book Update(Book book)
        {
            bool exists = this.context.Books.Any(b => b.Id.Equals(book.Id));
            if (!exists) return null;

            var result = this.context.Books.SingleOrDefault(b => b.Id.Equals(book.Id));
            if (result != null)
            {
                try
                {
                    this.context.Entry(result).CurrentValues.SetValues(book);
                    this.context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return book;
        }

        public void Delete(long id)
        {
            var result = this.context.Books.SingleOrDefault(b => b.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    this.context.Books.Remove(result);
                    this.context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
