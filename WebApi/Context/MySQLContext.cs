using Microsoft.EntityFrameworkCore;
using WebApi.Model;

namespace WebApi.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext() { }

        public MySQLContext(DbContextOptions<MySQLContext> options)   : base (options)
        { }

        public DbSet<Book> Books { get; set; }

        public DbSet<Person> Persons { get; set; }

    }
}
