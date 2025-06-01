using AccesoDatos.Models;
using AccesoDatos.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AccesoDatos.operation
{
    public class ServicioDAO
    {
        public BD_GESTION_VETERINARIAContext context = new BD_GESTION_VETERINARIAContext();

        public List<Servicio> seleccionarTodo()
        {
            var servicios = context.Servicio.ToList<Servicio>();
            return servicios;
        }


        public Servicio seleccionarServicio(int id_servicio)
        {
            var servicio = context.Servicio.Where(a => a.id_servicio == id_servicio).FirstOrDefault(); /*consultar y recorrer 1 a 1 */
            return servicio;
        }


        public bool insertarServicio(string nombre_servicio, string descripcion, float precio)
        {
            try
            {
                Servicio servicio = new Servicio();

                servicio.nombre_servicio = nombre_servicio;
                servicio.descripcion = descripcion;
                servicio.precio = (decimal)precio;
                context.Servicio.Add(servicio);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }


        public bool actualizar(int id_servicio, string nombre_servicio, string descripcion, float precio)
        {
            try
            {
                var servicio = seleccionarServicio(id_servicio);

                if (servicio == null)
                {
                    return false;
                }
                else
                {
                    servicio.nombre_servicio = nombre_servicio;
                    servicio.descripcion = descripcion;
                    servicio.precio = (decimal)precio;
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool eliminar(int id)
        {
            try
            {
                var alumno = seleccionarServicio(id);

                if (alumno == null)
                {
                    return false;
                }
                else
                {
                    context.Servicio.Remove(alumno);
                    context.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public List<ServicioRazaPrecio> ServicioRazaPrecios()
        {
            var query = from s in context.Servicio
                        join sr in context.Servicio_precio_raza on s.id_servicio equals sr.id_servicio
                        join r in context.Raza on sr.id_raza equals r.id_raza
                        select new ServicioRazaPrecio
                        {
                            NombreServicio = s.nombre_servicio,
                            DescripcionServicio = s.descripcion,
                            NombreRaza = r.nombre_raza,
                            DescripcionRaza = r.descripcion,
                            Especie = sr.especie,
                            PrecioPersonalizado = (decimal)sr.precio
                        };
            return query.ToList();
        }





    }
}
