using Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Queries
{
    public class QueryGeneric : IQueryGeneric
    {
        private readonly ApplicationDbContext context;
        public QueryGeneric(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }
        public List<T> GetAll<T>() where T : class
        {
            return (context.Set<T>()).ToList();
        }
    }
}
