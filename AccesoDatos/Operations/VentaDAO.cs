using AccesoDatos.Context;
using AccesoDatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Operations
{
    public class VentaDAO
    {
        private BD_GESTION_VETERINARIAContext context = new BD_GESTION_VETERINARIAContext();

        public List<Venta> SeleccionarTodasLasVentas()
        {
            return context.Venta.ToList();
        }

        public Venta SeleccionarVentaPorId(int id_venta)
        {
            return context.Venta.FirstOrDefault(v => v.id_venta == id_venta);
        }

        public bool InsertarVenta(DateTime? fechaHoraVenta, int? id_cliente, int id_usuario, decimal total_venta, string forma_pago, string notas)
        {
            try
            {
                Venta venta = new Venta
                {
                    fecha_hora_venta = fechaHoraVenta ?? DateTime.Now,
                    id_cliente = id_cliente,
                    id_usuario = id_usuario,
                    total_venta = total_venta,
                    forma_pago = forma_pago,
                    notas = notas
                };

                context.Venta.Add(venta);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ActualizarVenta(int id_venta, DateTime fechaHoraVenta, int? id_cliente, int id_usuario, decimal total_venta, string forma_pago, string notas)
        {
            try
            {
                var venta = SeleccionarVentaPorId(id_venta);
                if (venta == null)
                    return false;

                venta.fecha_hora_venta = fechaHoraVenta;
                venta.id_cliente = id_cliente;
                venta.id_usuario = id_usuario;
                venta.total_venta = total_venta;
                venta.forma_pago = forma_pago;
                venta.notas = notas;

                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool EliminarVenta(int id_venta)
        {
            try
            {
                var venta = SeleccionarVentaPorId(id_venta);
                if (venta == null)
                    return false;

                context.Venta.Remove(venta);
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
