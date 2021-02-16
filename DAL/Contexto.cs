using Microsoft.EntityFrameworkCore;
using OtroRegistroCompleto.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace OtroRegistroCompleto.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Roles> Roles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = GestionUsuarios.Db");
        }
    }
}
