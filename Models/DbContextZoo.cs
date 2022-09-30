using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplicationTest1Zoologico.Models
{
    public class DbContextZoo:DbContext
    {
        public DbContextZoo():base("ConnZoo")
        {

        }

        public DbSet<Animales> Animales { get; set; }
        public DbSet<Empleados> Empleadoses { get; set; }
        public DbSet<SeccionesZoo> SeccionesZooes { get; set; }
    }
}