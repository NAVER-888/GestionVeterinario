using AccesoDatos.Context;
using AccesoDatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Operations
{
    public class Detalle_ventaDAO
    {
        private BD_GESTION_VETERINARIAContext context = new BD_GESTION_VETERINARIAContext();

        public List<Detalle_venta> SeleccionarTodo()
        {
            return context.Detalle_venta.ToList();
        }

        public Detalle_venta SeleccionarPorId(int id_detalle_venta)
        {
            return context.Detalle_venta.FirstOrDefault(d => d.id_detalle_venta == id_detalle_venta);
        }

        public bool Insertar(int id_venta, int id_producto, int cantidad, decimal precio_unitario)
        {
            try
            {
                var detalle = new Detalle_venta
                {
                    id_venta = id_venta,
                    id_producto = id_producto,
                    cantidad = cantidad,
                    precio_unitario = precio_unitario
                };

                context.Detalle_venta.Add(detalle);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Actualizar(int id_detalle_venta, int id_venta, int id_producto, int cantidad, decimal precio_unitario)
        {
            try
            {
                var detalle = SeleccionarPorId(id_detalle_venta);
                if (detalle == null)
                    return false;

                detalle.id_venta = id_venta;
                detalle.id_producto = id_producto;
                detalle.cantidad = cantidad;
                detalle.precio_unitario = precio_unitario;

                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Eliminar(int id_detalle_venta)
        {
            try
            {
                var detalle = SeleccionarPorId(id_detalle_venta);
                if (detalle == null)
                    return false;

                context.Detalle_venta.Remove(detalle);
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
