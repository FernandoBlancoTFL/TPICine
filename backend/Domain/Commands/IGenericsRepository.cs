using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Commands
{
    public interface IGenericsRepository
    {
        void Add<T>(T entity) where T : class;
        public void Update<T>(T entity) where T : class;
        public void Delete<T>(int _id) where T : class;
    }
}
