using System.Collections.Generic;
using UdemyCurso.Model;
using UdemyCurso.Repository;

namespace UdemyCurso.Services.Implementations
{
    public class PersonServiceImplementations : IPersonService
    {
        private readonly IRepository<Person> repository;
        public PersonServiceImplementations(IRepository<Person> repository)
        {
            this.repository = repository;
        }

        public List<Person> FindAll()
        {
            return this.repository.FindAll();
        }

        public Person FindById(long id)
        {
            return this.repository.FindById(id);
        }

        public Person Create(Person person)
        {
            return this.repository.Create(person);
        }

        public Person Update(Person person)
        {
            this.repository.Update(person);
            return person;
        }

        public void Delete(long id)
        {
            this.repository.Delete(id);

        }
    }
}
