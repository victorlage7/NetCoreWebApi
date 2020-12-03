using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Context;
using WebApi.Model;
using WebApi.Repository.Interface;

namespace WebApi.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly MySQLContext _context;

        public BookRepository(MySQLContext context)
        {
            _context = context;
        }

        public Book Save(Book book)
        {
            try
            {
                _context.Add(book);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString(), ex);
                throw ex;
            }
            return book;
        }

        public Book FindById(long id)
        {
            return _context.Books.FirstOrDefault(p => p.Id.Equals(id));
        }

        public List<Book> FindAll()
        {
            return _context.Books.ToList();
        }

        public Book Update(Book book)
        {
            if (!Exists(book.Id)) return null;

            var result = _context.Books.SingleOrDefault(b => b.Id == book.Id);
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(book);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Log.Error(ex.ToString(), ex);
                    throw ex;
                }
            }
            return result;
        }

        public void Delete(long id)
        {
            var result = _context.Books.SingleOrDefault(i => i.Id.Equals(id));
            try
            {
                if (result != null) _context.Books.Remove(result);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString(), ex);
                throw ex;
            }
        }

        public bool Exists(long? id)
        {
            return _context.Books.Any(b => b.Id.Equals(id));
        }
    }
}
