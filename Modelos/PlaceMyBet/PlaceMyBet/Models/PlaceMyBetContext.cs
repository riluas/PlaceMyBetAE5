using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class PlaceMyBetContext : DbContext
    {
        public DbSet<Apuesta> Apuestas { get; set; } //Taula
        public DbSet<Cuenta> Cuentas { get; set; } //Taula
        public DbSet<Evento> Eventos { get; set; } //Taula
        public DbSet<Mercado> Mercados { get; set; } //Taula
        public DbSet<Usuario> Usuarios { get; set; } //Taula


        public PlaceMyBetContext()
        {
        }

        public PlaceMyBetContext(DbContextOptions options)
        : base(options)
        {
        }

        //Mètode de configuració
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("Server =127.0.0.1;Port=3306;Database=placemybet1;Uid=root;password=;SslMode=none");//màquina retos

            }
        }

        //Inserció inicial de dades
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Evento>().HasData(new Evento(1, "2020-04-08", "Valencia", "Barcelona", 5));
            modelBuilder.Entity<Evento>().HasData(new Evento(2, "2020-04-08", "Valencia", "Madrid", 7));
            modelBuilder.Entity<Mercado>().HasData(new Mercado(1, 1.5, 1.9, 1.9, 700, 700, 1));
            modelBuilder.Entity<Mercado>().HasData(new Mercado(2, 1.5, 1.9, 1.4, 100, 100, 2));
            modelBuilder.Entity<Mercado>().HasData(new Mercado(3, 1, 1.9, 1.9, 100, 200, 1));
            modelBuilder.Entity<Usuario>().HasData(new Usuario("ejemplo@ejemplo.es", "Ricardo", "Lucas", 21));
            modelBuilder.Entity<Usuario>().HasData(new Usuario("ejemplo2@ejemplo2.es", "Ricardo2", "Lucas", 22));
            modelBuilder.Entity<Apuesta>().HasData(new Apuesta(1, "2020-11-05 14:57:16", 1.9, "Over", 200, 1, "ejemplo@ejemplo.es"));
            modelBuilder.Entity<Apuesta>().HasData(new Apuesta(2, "2020-11-05 14:57:16", 1.5, "under", 100, 1, "ejemplo@ejemplo.es"));
            modelBuilder.Entity<Apuesta>().HasData(new Apuesta(3, "2020-11-05 14:57:16", 1.78, "Over", 50, 1, "ejemplo@ejemplo.es"));
            modelBuilder.Entity<Cuenta>().HasData(new Cuenta(1, "Mibanco", 55555555, 800, "ejemplo@ejemplo.es"));

        }
    }
}