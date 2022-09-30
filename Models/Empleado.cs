using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplicationTest1Zoologico.Models
{
    [Table("TablaEmpleados")]
    public class Empleados
    {
        [Required]
        public int Id { get; set; }

        [MaxLength(200)]
        public string Nombre { get; set; }

        [MaxLength(200)]
        public string Direccion { get; set; }

        public int Telefono { get; set; }

        // indica que la llave migra
        public ICollection<Animales> animales { get; set; }
    }
}