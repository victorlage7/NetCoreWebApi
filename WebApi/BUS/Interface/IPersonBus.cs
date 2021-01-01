using System.Collections.Generic;
using WebApi.Model;

namespace WebApi.BUS.Interface
{
    public interface IPersonBus
    {
        Person Save(Person person);

        Person FindById(long id);

        List<Person> FindAll();

        Person Update(Person person);

        void Delete(long id);

        public List<Person> FindByName(string name);
    }
}
