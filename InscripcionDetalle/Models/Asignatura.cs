using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InscripcionDetalle.Models
{
    public class Asignatura
    {
        [Key]
        public int AsignaturaId { get; set; }
        [Required]
        public string Codigo { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public string PreRequisito { get; set; }
        [Required]
        [Range(1,5)]
        public int Creditos { get; set; }
        public Asignatura()
        {
            AsignaturaId = 0;
            Codigo = string.Empty;
            Descripcion = string.Empty;
            PreRequisito = string.Empty;
            Creditos = 0;
        }
    }
}
