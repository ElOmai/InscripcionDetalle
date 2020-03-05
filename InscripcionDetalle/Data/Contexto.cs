using InscripcionDetalle.Models;
using Microsoft.EntityFrameworkCore;

namespace InscripcionDetalle.Data
{
    public class Contexto : DbContext
    {
        public DbSet<Inscripcion> Inscripcion { get; set; }
        public DbSet<Estudiante> Estudiante { get; set; }
        public DbSet<Pago> Pago { get; set; }
        public DbSet<Asignatura> Asignatura { get; set; }
        public DbSet<InscripcionDetalles> InscripcionDetalles { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source= Database/InscripcionDb.db");
        }
    }
}
