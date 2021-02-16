using Microsoft.EntityFrameworkCore;
using OtroRegistroCompleto.DAL;
using OtroRegistroCompleto.Entidades;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;


namespace OtroRegistroCompleto.BLL
{
    class PermisosBLL
    {
        public static bool Guardar(Permisos permisos)
        {
            if (!Existe(permisos.PermisoId))
                return Insertar(permisos);
            else
                return Modificar(permisos);
        }

        private static bool Insertar(Permisos permisos)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Permisos.Add(permisos);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static bool Modificar(Permisos permisos)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(permisos).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Permisos.Any(e => e.PermisoId == id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return encontrado;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                var permisos = contexto.Permisos.Find(id);
                if (permisos != null)
                {
                    contexto.Permisos.Remove(permisos);
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static Permisos Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Permisos permisos;

            try
            {
                permisos = contexto.Permisos.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return permisos;
        }
    }
}
