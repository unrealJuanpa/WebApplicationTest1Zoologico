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
    }
}