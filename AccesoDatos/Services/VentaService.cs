using AccesoDatos.Models;
using AccesoDatos.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Services
{
    public class VentaService
    {
        private readonly VentaDAO _dao = new VentaDAO();

        public List<Venta> ObtenerTodas()
        {
            return _dao.SeleccionarTodasLasVentas();
        }

        public Venta ObtenerPorId(int id)
        {
            return _dao.SeleccionarVentaPorId(id);
        }

        public bool Crear(DateTime? fechaHoraVenta, int? id_cliente, int id_usuario, decimal total_venta, string forma_pago, string notas)
        {
            return _dao.InsertarVenta(fechaHoraVenta, id_cliente, id_usuario, total_venta, forma_pago, notas);
        }

        public bool Actualizar(int id_venta, DateTime fechaHoraVenta, int? id_cliente, int id_usuario, decimal total_venta, string forma_pago, string notas)
        {
            return _dao.ActualizarVenta(id_venta, fechaHoraVenta, id_cliente, id_usuario, total_venta, forma_pago, notas);
        }

        public bool Eliminar(int id)
        {
            return _dao.EliminarVenta(id);
        }
    }
}
