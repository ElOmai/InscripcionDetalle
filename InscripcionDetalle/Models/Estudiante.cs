using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InscripcionDetalle.Models
{
    public class Estudiante
    {
        [Key]
        public int EstudianteId { get; set; }
        [Required]
        public string Matricula { get; set; }
        [Required]
        public string Nombres { get; set; }
        public int Balance { get; set; }
        public Estudiante()
        {
            EstudianteId = 0;
            Matricula = string.Empty;
            Nombres = string.Empty;
            Balance = 0;
        }
    }
}
