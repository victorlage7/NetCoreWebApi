using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Context;
using WebApi.Model;
using WebApi.Repository.Interface;

namespace WebApi.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly MySQLContext _context;

        public PersonRepository(MySQLContext context)
        {
            _context = context;
        }

        public Person Save(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return person;
        }

        public Person FindById(long id)
        {
            return _context.Persons.FirstOrDefault(p => p.Id.Equals(id));
        }

        public List<Person> FindAll()
        {
            return _context.Persons.ToList();
        }

        public Person Update(Person person)
        {
            if (!Exists(person.Id)) return null;

            var result = _context.Persons.SingleOrDefault(b => b.Id == person.Id);
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(person);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return result;
        }

        public void Delete(long id)
        {
            var result = _context.Persons.SingleOrDefault(i => i.Id.Equals(id));
            try
            {
                if (result != null) _context.Persons.Remove(result);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Exists(long? id)
        {
            return _context.Persons.Any(b => b.Id.Equals(id));
        }
    }
}