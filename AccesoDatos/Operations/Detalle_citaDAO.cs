using AccesoDatos.Context;
using AccesoDatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Operations
{
    public class Detalle_citaDAO
    {
        private BD_GESTION_VETERINARIAContext context = new BD_GESTION_VETERINARIAContext();

        public List<Detalle_cita> SeleccionarTodo()
        {
            return context.Detalle_cita.ToList();
        }

        public Detalle_cita SeleccionarPorId(int id_cita_servicio)
        {
            return context.Detalle_cita.FirstOrDefault(d => d.id_cita_servicio == id_cita_servicio);
        }

        public bool Insertar(int id_cita, int id_servicio, int cantidad, decimal precio_unitario)
        {
            try
            {
                var nuevo = new Detalle_cita
                {
                    id_cita = id_cita,
                    id_servicio = id_servicio,
                    cantidad = cantidad,
                    precio_unitario = precio_unitario
                    // subtotal, igv y total son columnas calculadas → EF las ignora en la inserción
                };

                context.Detalle_cita.Add(nuevo);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Actualizar(int id_cita_servicio, int id_cita, int id_servicio, int cantidad, decimal precio_unitario)
        {
            try
            {
                var detalle = SeleccionarPorId(id_cita_servicio);
                if (detalle == null)
                    return false;

                detalle.id_cita = id_cita;
                detalle.id_servicio = id_servicio;
                detalle.cantidad = cantidad;
                detalle.precio_unitario = precio_unitario;
                // subtotal, igv y total se recalculan automáticamente en la BD

                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Eliminar(int id_cita_servicio)
        {
            try
            {
                var detalle = SeleccionarPorId(id_cita_servicio);
                if (detalle == null)
                    return false;

                context.Detalle_cita.Remove(detalle);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
