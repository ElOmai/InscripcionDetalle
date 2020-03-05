using InscripcionDetalle.Data;
using InscripcionDetalle.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace InscripcionDetalle.Controllers
{
    public class PagoController
    {
        public bool Guardar(Pago pago)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                if (pago.PagoId == 0)
                {
                    paso = Insertar(pago);
                }
                else
                {
                    paso = Modificar(pago);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return paso;
        }

        private bool Insertar(Pago pago)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.Estudiante.Find(pago.EstudianteId).Balance -= pago.Monto;

                contexto.Pago.Add(pago);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        private bool Modificar(Pago pago)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.Pago.Add(pago);
                contexto.Entry(pago).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public Pago Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Pago pago = new Pago();

            try
            {
                pago = contexto.Pago.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            return pago;
        }

        public bool Eliminar(int id)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            Pago pago = new Pago();

            try
            {
                pago = contexto.Pago.Find(id);
                contexto.Entry(pago).State = EntityState.Deleted;
                paso = contexto.SaveChanges() > 0;

            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public List<Pago> GetPago(Expression<Func<Pago, bool>> expression)
        {
            List<Pago> lista;
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Pago.Where(expression).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return lista;
        }
    }
}
