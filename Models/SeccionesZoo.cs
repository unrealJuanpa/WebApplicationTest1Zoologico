using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplicationTest1Zoologico.Models
{
    [Table("TablaSeccionesZoo")]
    public class SeccionesZoo
    {
        [Required]
        public int Id { get; set; }


        [MaxLength(200)]
        public string NombreSeccion { get; set; }


        [MaxLength(1000)]
        public string Detalles { get; set; }


        // indica que la llave migra
        public ICollection<Animales> animales { get; set; }

    }
}