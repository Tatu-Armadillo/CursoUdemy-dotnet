using System.Collections.Generic;
using System.Linq;
using UdemyCurso.Data.Converter.Contrat;
using UdemyCurso.Data.VO;
using UdemyCurso.Model;

namespace UdemyCurso.Data.Converter.Implementations
{
    public class BookConverter : IParse<BookVO, Book>, IParse<Book, BookVO>
    {
        public Book Parse(BookVO origin)
        {
            if (origin == null) return null;
            
            return new Book
            {
                Id = origin.Id,
                Author = origin.Author,
                LaunchDate = origin.LaunchDate,
                Price = origin.Price,
                Title = origin.Title,
            };
        }

        public BookVO Parse(Book origin)
        {
            if (origin == null) return null;
            
            return new BookVO
            {
                Id = origin.Id,
                Author = origin.Author,
                LaunchDate = origin.LaunchDate,
                Price = origin.Price,
                Title = origin.Title,
            };
        }

        public List<Book> Parse(List<BookVO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<BookVO> Parse(List<Book> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}