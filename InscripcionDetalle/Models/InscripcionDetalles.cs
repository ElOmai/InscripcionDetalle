using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InscripcionDetalle.Models
{
    public class InscripcionDetalles
    {
        [Key]
        public int InscripcionDetallesId { get; set; }
        [Required]
        public int InscripcionId { get; set; }
        [Required]
        public int AsignaturaId { get; set; }
        [Required]
        public string DescripcionAsignatura { get; set; }
        [Required]
        public int Creditos { get; set; }
        [Required]
        public int Subtotal { get; set; }
        public InscripcionDetalles()
        {
            InscripcionDetallesId = 0;
            InscripcionId = 0;
            AsignaturaId = 0;
            Subtotal = 0;
            Creditos = 0;
        }
        public InscripcionDetalles(int inscripcionDetallesId, int inscripcionId, int asignaturaId, int subTotal)
        {
            InscripcionDetallesId = inscripcionDetallesId;
            InscripcionId = inscripcionId;
            AsignaturaId = asignaturaId;
            Subtotal = subTotal;
        }
    }
}
