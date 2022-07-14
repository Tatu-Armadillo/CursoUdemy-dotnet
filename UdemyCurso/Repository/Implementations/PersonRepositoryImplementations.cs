using System;
using System.Collections.Generic;
using System.Linq;
using UdemyCurso.Model;
using UdemyCurso.Model.Context;

namespace UdemyCurso.Repository.Implementations
{
    public class PersonRepositoryImplementations : IPersonRepository
    {
        private MySQLContext context;
        public PersonRepositoryImplementations(MySQLContext context)
        {
            this.context = context;
        }

        public Person Create(Person person)
        {
            try
            {
                this.context.Add(person);
                this.context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return person;
        }
        public Person FindById(long id)
        {
            return this.context.Persons.SingleOrDefault(p => p.Id.Equals(id));
        }
        public bool Exists(long id)
        {
            return this.context.Persons.Any(p => p.Id.Equals(id));
        }

        public List<Person> FindAll()
        {
            return this.context.Persons.ToList();
        }



        public Person Update(Person person)
        {
            bool exists = this.context.Persons.Any(p => p.Id.Equals(person.Id));
            if (!exists) return new Person();

            var result = this.context.Persons.SingleOrDefault(p => p.Id.Equals(person.Id));
            if (result != null)
            {
                try
                {
                    this.context.Entry(result).CurrentValues.SetValues(person);
                    this.context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return person;
        }

        public void Delete(long id)
        {
            var result = this.context.Persons.SingleOrDefault(p => p.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    this.context.Persons.Remove(result);
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
