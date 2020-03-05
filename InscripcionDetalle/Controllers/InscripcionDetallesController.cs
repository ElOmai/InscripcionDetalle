using InscripcionDetalle.Data;
using InscripcionDetalle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace InscripcionDetalle.Controllers
{
    public class InscripcionDetallesController
    {
        public List<InscripcionDetalles> GetInscripcions(Expression<Func<InscripcionDetalles, bool>> expression)
        {
            Contexto contexto = new Contexto();
            List<InscripcionDetalles> lista;
            try
            {
                lista = contexto.InscripcionDetalles.Where(expression).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return lista;
        }
        public InscripcionDetalles Buscar(int id)
        {
            Contexto contexto = new Contexto();
            InscripcionDetalles inscripcion = new InscripcionDetalles();
            try
            {
                inscripcion = contexto.InscripcionDetalles.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            return inscripcion;
        }
    }
}
