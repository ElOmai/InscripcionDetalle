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
    public class AsignaturaController
    {
        public bool Guardar(Asignatura asignatura)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                if (asignatura.AsignaturaId == 0)
                {
                    paso = Insertar(asignatura);
                }
                else
                {
                    paso = Modificar(asignatura);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return paso;
        }

        private bool Insertar(Asignatura asignatura)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.Asignatura.Add(asignatura);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        private bool Modificar(Asignatura asignatura)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.Asignatura.Add(asignatura);
                contexto.Entry(asignatura).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public Asignatura Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Asignatura asignatura = new Asignatura();

            try
            {
                asignatura = contexto.Asignatura.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            return asignatura;
        }

        public bool Eliminar(int id)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            Asignatura asignatura = new Asignatura();

            try
            {
                asignatura = contexto.Asignatura.Find(id);
                contexto.Entry(asignatura).State = EntityState.Deleted;
                paso = contexto.SaveChanges() > 0;

            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public List<Asignatura> GetAsignatura(Expression<Func<Asignatura, bool>> expression)
        {
            List<Asignatura> lista;
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Asignatura.Where(expression).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return lista;
        }
    }
}
