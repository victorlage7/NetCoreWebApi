using System.Collections.Generic;
using WebApi.Model;

namespace WebApi.Repository.Interface
{
    public interface IPersonRepository
    {
        Person Save(Person person);

        Person FindById(long id);

        List<Person> FindAll();

        Person Update(Person person);

        void Delete(long id);

        bool Exists(long? id);
    }
}
