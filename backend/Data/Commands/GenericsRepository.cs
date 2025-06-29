using System;
using System.Collections.Generic;
using System.Text;
using Domain.Commands;

namespace Data.Commands
{
    public class GenericsRepository : IGenericsRepository
    {
        private readonly ApplicationDbContext _context;

        public GenericsRepository (ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
            _context.SaveChanges();
        }

        public void Delete<T>(int _id) where T : class
        {
            _context.Remove(_context.Find<T>(_id));
            _context.SaveChanges();
        }
    }
}
