using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InscripcionDetalle.Models
{
    public class Inscripcion
    {
        [Key]
        public int InscripcionId { get; set; }
        [Required]
        public int EstudianteId { get; set; }
        [Required]
        public string Semestre { get; set; }
        [Range(1,100)]
        public int Limite { get; set; }
        [Required]
        [Range(1,100)]
        public int Tomados { get; set; }
        public int Disponible { get; set; }
        public DateTime Fecha { get; set; }
        [Range(1,1000000)]
        public int Monto { get; set; }
        [ForeignKey("InscripcionId")]
        public List<InscripcionDetalles> Detalles { get; set; }


        public Inscripcion()
        {
            InscripcionId = 0;
            Semestre = string.Empty;
            Limite = 0;
            Tomados = 0;
            Disponible = 0;
            EstudianteId = 0;
            Fecha = DateTime.Now;
            Monto = 0;
            Detalles = new List<InscripcionDetalles>();
        }
    }
}
