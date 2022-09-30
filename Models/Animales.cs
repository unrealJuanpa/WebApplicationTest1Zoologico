using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplicationTest1Zoologico.Models
{
    [Table("TablaAnimales")]
    public class Animales
    {
        [Required]
        public int Id { get; set; }


        [MaxLength(200)]
        public string NombreCientifico { get; set; }


        [MaxLength(200)]
        public string Raza { get; set; }


        [MaxLength(200)]
        public string Color { get; set; }


        [MaxLength(200)]
        public string Tamaño { get; set; }


        [MaxLength(200)]
        public string CaracteristicasEspeciales { get; set; }


        [MaxLength(200)]
        public string LugarOrigen { get; set; }


        [MaxLength(200)]
        public string PaisOrigen { get; set; }



        [MaxLength(200)]
        public string RasgosDestacados { get; set; }


        public DateTime FechaLlegada { get; set; }

        public DateTime FechaTraslado { get; set; }

        public DateTime FechaDeceso { get; set; }

        public int HoraAlimentacion { get; set; }


        [MaxLength(200)]
        public string TipoAlimentacion { get; set; }



        // recibe las llaves foraneas
        public Empleados empleados { get; set; }
        public int EmpleadosId { get; set; }


        public SeccionesZoo seccionesZoo { get; set; }
        public int SeccionesZooId { get; set; }
    }
}