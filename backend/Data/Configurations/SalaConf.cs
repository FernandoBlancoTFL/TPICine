using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configurations
{
    public class SalaConf
    {
        EntityTypeBuilder<Sala> salaBuilder;

        public SalaConf(EntityTypeBuilder<Sala> entityBuilder)
        {
            salaBuilder = entityBuilder;
            salaBuilder.HasKey(x => x.SalaId);

            entityBuilder.HasKey(x => x.SalaId);
            entityBuilder.Property(x => x.Capacidad).IsRequired();

            CrearSala.LlenarSala(salaBuilder, 1, 5);
            CrearSala.LlenarSala(salaBuilder, 2, 15);
            CrearSala.LlenarSala(salaBuilder, 3, 35);
        }
    }

    public class CrearSala
    {
        public static void LlenarSala(EntityTypeBuilder<Sala> builder, int salaId, int capacidad)
        {
            builder.HasData(new Sala
            {
                SalaId = salaId,
                Capacidad = capacidad
            });
        }
    }
}
