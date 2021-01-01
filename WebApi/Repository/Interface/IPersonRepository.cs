using System.Collections.Generic;
using WebApi.Model;

namespace WebApi.Repository.Interface
{
    public interface IPersonRepository : IBaseRepository<Person>
    {
        List<Person> FindByName(string name);
    }
}
