using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configurations
{
    public class FuncionConf
    {
        public FuncionConf(EntityTypeBuilder<Funcion> entityBuilder)
        {
            entityBuilder.HasKey(x => x.FuncionId);
            entityBuilder.Property(x => x.Fecha).IsRequired();
            entityBuilder.Property(x => x.Horario).IsRequired();
            entityBuilder.Property(x => x.PeliculaId).IsRequired();
            entityBuilder.Property(x => x.SalaId).IsRequired();
        }
    }
}
