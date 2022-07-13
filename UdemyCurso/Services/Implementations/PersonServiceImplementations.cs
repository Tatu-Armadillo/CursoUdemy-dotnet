using System;
using System.Collections.Generic;
using System.Linq;
using UdemyCurso.Model;
using UdemyCurso.Model.Context;

namespace UdemyCurso.Services.Implementations
{
    public class PersonServiceImplementations : IPersonService
    {
        private MySQLContext _context;
        public PersonServiceImplementations(MySQLContext context)
        {
            _context = context;
        }

        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return person;
        }

        public void Delete(long id)
        {
            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    _context.Persons.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }

        }

        public List<Person> FindAll()
        {
            return _context.Persons.ToList();
        }

        public Person FindById(long id)
        {
            return _context.Persons.SingleOrDefault(p => p.Id.Equals(id));
        }

        public Person Update(Person person)
        {
            bool exists = _context.Persons.Any(p => p.Id.Equals(person.Id));
            if (!exists) return new Person();

            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(person.Id)); 
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(person);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            
            return person;
        }
    }
}
