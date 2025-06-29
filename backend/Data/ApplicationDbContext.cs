using Data.Configurations;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new PeliculaConf(modelBuilder.Entity<Pelicula>());
            new SalaConf(modelBuilder.Entity<Sala>());
            new FuncionConf(modelBuilder.Entity<Funcion>());
            new TicketConf(modelBuilder.Entity<Ticket>());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<Sala> Salas { get; set; }
        public DbSet<Funcion> Funciones { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
    }

}
