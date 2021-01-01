using System.Collections.Generic;
using WebApi.BUS.Interface;
using WebApi.Model;
using WebApi.Repository.Interface;

namespace WebApi.BUS
{
    public class PersonBus : IPersonBus
    {
        private readonly IPersonRepository _repository;

        public PersonBus(IPersonRepository repository)
        {
            _repository = repository;
        }

        public Person Save(Person person)
        {
            return _repository.Save(person);
        }

        public Person FindById(long id)
        {
            return _repository.FindById(id);
        }

        public List<Person> FindAll()
        {
            return _repository.FindAll();
        }

        public Person Update(Person person)
        {
            return _repository.Update(person);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<Person> FindByName(string name)
        {
            return _repository.FindByName(name);
        }
    }
}
