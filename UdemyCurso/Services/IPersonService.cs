using System.Collections.Generic;
using UdemyCurso.Model;

namespace UdemyCurso.Services
{
    public interface IPersonService
    {
        Person Create(Person person);
        List<Person> FindAll();
        Person FindById(long id);
        Person Update(Person person);
        void Delete(long id);
    }
}
