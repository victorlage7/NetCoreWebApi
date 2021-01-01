using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Context;
using WebApi.Model.Base;
using WebApi.Repository.Interface;

namespace WebApi.Repository.BaseRepository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly MySQLContext _context;

        private DbSet<T> dataset;
        public BaseRepository(MySQLContext context)
        {
            _context = context;
            dataset = _context.Set<T>();

        }

        public List<T> FindAll()
        {
            return dataset.ToList();
        }

        public T FindById(long id)
        {
            return dataset.SingleOrDefault(i => i.Id.Equals(id));
        }

        public T Save(T item)
        {
            try
            {
                dataset.Add(item);
                _context.SaveChanges();
                return item;
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString(), ex);
                throw ex;
            }
        }

        public T Update(T item)
        {
            var result = dataset.SingleOrDefault(i => i.Id.Equals(item.Id));
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(item);
                    _context.SaveChanges();
                    return result;
                }
                catch (Exception ex)
                {
                    Log.Error(ex.ToString(), ex);
                    throw ex;
                }
            }
            else
            {
                return null;
            }
        }

        public void Delete(long id)
        {
            var result = dataset.SingleOrDefault(i => i.Id.Equals(id));
            if (result != null)
            { 
                try
                {
                    dataset.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Log.Error(ex.ToString(), ex);
                    throw ex;
                }
            }
        }

        

        public bool Exists(long? id)
        {
            return dataset.Any(b => b.Id.Equals(id));
        }
    }
}
