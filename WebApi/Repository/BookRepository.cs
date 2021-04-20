using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebApi.Context;
using WebApi.Model;
using WebApi.Repository.BaseRepository;
using WebApi.Repository.Interface;

namespace WebApi.Repository
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        private readonly MySQLContext _context;

        private DbSet<Book> dataset; 
        
        public BookRepository(MySQLContext context) : base(context)
        {
            _context = context;
            dataset = _context.Set<Book>();
        }
    }
}