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
    public class EstudianteController
    {
        public bool Guardar(Estudiante estudiante)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                if (estudiante.EstudianteId == 0)
                {
                    paso = Insertar(estudiante);
                }
                else
                {
                    paso = Modificar(estudiante);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        private bool Insertar(Estudiante estudiante)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                contexto.Estudiante.Add(estudiante);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public bool Modificar(Estudiante estudiante)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                contexto.Estudiante.Add(estudiante);
                contexto.Entry(estudiante).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public Estudiante Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Estudiante estudiante = new Estudiante();

            try
            {
                estudiante = contexto.Estudiante.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            return estudiante;
        }

        public bool Eliminar(int id)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            Estudiante estudiante = new Estudiante();

            try
            {
                estudiante = contexto.Estudiante.Find(id);
                contexto.Entry(estudiante).State = EntityState.Deleted;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public List<Estudiante> GetEstudiante(Expression<Func<Estudiante, bool>> expression)
        {
            List<Estudiante> lista;
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Estudiante.Where(expression).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return lista;
        }
    }
}
