using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Queries
{
    public interface IQueryGeneric
    {
        List<T> GetAll<T>() where T : class;
    }
}
