using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configurations
{
    public class TicketConf
    {
        public TicketConf(EntityTypeBuilder<Ticket> entityBuilder)
        {
            entityBuilder.HasKey(x => new { x.TicketId, x.FuncionId });
            entityBuilder.Property(x => x.Usuario).HasMaxLength(50).IsRequired();
        }
    }
}
