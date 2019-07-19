using Core.Models;
using Domain.Interfaces;
using Infrastructure.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseModel
    {
        private readonly ConfigurationContext _context;

        public Repository(ConfigurationContext context)
        {
            _context = context;
        }

        public void Add(T t)
        {
            _context.Set<T>().Add(t);
            _context.SaveChanges();
        }

        public T Find(Guid id)
        {
            return _context.Set<T>().FirstOrDefault(t => t.Id == id);
        }

        public IEnumerable<T> Get()
        {
            return _context.Set<T>().Where(t => !t.Deleted).ToList();
        }

        public void Remove(Guid id)
        {
            var t = Find(id);
            _context.Set<T>().Remove(t);
            _context.SaveChanges();
        }

        public void Update(T t)
        {
            _context.Set<T>().Update(t);
            _context.SaveChanges();
        }
    }
}