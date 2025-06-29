using Domain.DTOs.SalaDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Queries
{
    public interface IQuerySala
    {
        ResponseGetSalaById GetSalaByIdQuery(int salaId);
    }
}
