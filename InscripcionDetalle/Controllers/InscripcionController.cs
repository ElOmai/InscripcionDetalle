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
    public class InscripncionController
    {
        public bool Guardar(Inscripcion inscripcion)
        {
            bool paso = false;
            try
            {
                if (inscripcion.InscripcionId == 0)
                {
                    paso = Insertar(inscripcion);
                }
                else
                {
                    paso = Modificar(inscripcion);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }
        private bool Insertar(Inscripcion inscripcion)
        {
            Contexto contexto = new Contexto();
            EstudianteController controllerEst = new EstudianteController();
            bool paso = false;
            try
            {
                var estudiante = controllerEst.Buscar(inscripcion.EstudianteId);
                estudiante.Balance += inscripcion.Monto;
                controllerEst.Guardar(estudiante);
                contexto.Inscripcion.Add(inscripcion);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        private bool Modificar(Inscripcion inscripcion)
        {
            Contexto contexto = new Contexto();
            InscripncionController ed = new InscripncionController();
            EstudianteController controllerEst = new EstudianteController();
            bool paso = false;

            try
            {
                var estudiante = controllerEst.Buscar(inscripcion.EstudianteId);
                var anterior = Buscar(inscripcion.InscripcionId);

                estudiante.Balance -= anterior.Monto;
                contexto.Inscripcion.Add(inscripcion);

                foreach (var item in anterior.Detalles)
                {
                    if (!inscripcion.Detalles.Any(p => p.InscripcionDetallesId == item.InscripcionDetallesId))
                    {
                        contexto.Entry(item).State = EntityState.Deleted;
                    }
                }

                foreach (var item in inscripcion.Detalles)
                {
                    if (item.InscripcionDetallesId == 0)
                    {
                        contexto.Entry(item).State = EntityState.Added;
                    }
                    else
                    {
                        contexto.Entry(item).State = EntityState.Modified;
                    }
                }

                estudiante.Balance += inscripcion.Monto;
                controllerEst.Modificar(estudiante);

                contexto.Entry(inscripcion).State = EntityState.Modified;

                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public Inscripcion Buscar(int id)
        {
            Contexto contexto = new Contexto();
            InscripcionDetallesController detallesController = new InscripcionDetallesController();
            Inscripcion inscripcion = new Inscripcion();
            try
            {
                inscripcion = contexto.Inscripcion.Find(id);
                if (inscripcion != null)
                {
                    inscripcion.Detalles = detallesController.GetInscripcion(A => A.InscripcionId == id);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return inscripcion;
        }
        public bool Eliminar(int id)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            Inscripcion inscripcion = new Inscripcion();
            EstudianteController controllerEst = new EstudianteController();
            try
            {
                inscripcion = contexto.Inscripcion.Find(id);
                contexto.Estudiante.Find(inscripcion.EstudianteId).Balance -= inscripcion.Monto;
                contexto.Inscripcion.Remove(inscripcion);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }
        public List<Inscripcion> GetInscripcion(Expression<Func<Inscripcion, bool>> expression)
        {
            Contexto contexto = new Contexto();
            List<Inscripcion> lista;

            try
            {
                lista = contexto.Inscripcion.Where(expression).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return lista;
        }
    }
}
