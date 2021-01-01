using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApi.Context;
using WebApi.Model;
using WebApi.Repository.BaseRepository;
using WebApi.Repository.Interface;

namespace WebApi.Repository
{
    public class PersonRepository : BaseRepository<Person> , IPersonRepository
    {

        private readonly MySQLContext _context;

        private DbSet<Person> dataset; 

        public PersonRepository(MySQLContext context) : base(context)
        {
            _context = context;
            dataset = _context.Set<Person>();
        }

        public List<Person> FindByName(string name)
        {
            return dataset.FromSqlRaw("SELECT * FROM person")
                          .Where(b => b.FirstName.Contains(name))
                          .ToList();
        }
    }
} 
