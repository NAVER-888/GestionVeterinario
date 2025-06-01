using AccesoDatos.Context;
using AccesoDatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Operations
{
    public class Detalle_servicio_ventaDAO
    {
        private BD_GESTION_VETERINARIAContext context = new BD_GESTION_VETERINARIAContext();

        public List<Detalle_servicio_venta> SeleccionarTodo()
        {
            return context.Detalle_servicio_venta.ToList();
        }

        public Detalle_servicio_venta SeleccionarPorId(int id_detalle_servicio)
        {
            return context.Detalle_servicio_venta.FirstOrDefault(d => d.id_detalle_servicio == id_detalle_servicio);
        }

        public bool Insertar(int id_venta, int id_servicio, int cantidad, decimal precio_unitario, int? empleado_asignado, string notas)
        {
            try
            {
                var detalle = new Detalle_servicio_venta
                {
                    id_venta = id_venta,
                    id_servicio = id_servicio,
                    cantidad = cantidad,
                    precio_unitario = precio_unitario,
                    empleado_asignado = empleado_asignado,
                    notas = notas
                };

                context.Detalle_servicio_venta.Add(detalle);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Actualizar(int id_detalle_servicio, int id_venta, int id_servicio, int cantidad, decimal precio_unitario, int? empleado_asignado, string notas)
        {
            try
            {
                var detalle = SeleccionarPorId(id_detalle_servicio);
                if (detalle == null)
                    return false;

                detalle.id_venta = id_venta;
                detalle.id_servicio = id_servicio;
                detalle.cantidad = cantidad;
                detalle.precio_unitario = precio_unitario;
                detalle.empleado_asignado = empleado_asignado;
                detalle.notas = notas;

                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Eliminar(int id_detalle_servicio)
        {
            try
            {
                var detalle = SeleccionarPorId(id_detalle_servicio);
                if (detalle == null)
                    return false;

                context.Detalle_servicio_venta.Remove(detalle);
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
