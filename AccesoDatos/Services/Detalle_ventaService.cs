using AccesoDatos.Models;
using AccesoDatos.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Services
{
    public class Detalle_ventaService
    {
        private readonly Detalle_ventaDAO _dao = new Detalle_ventaDAO();

        public List<Detalle_venta> ObtenerTodos()
        {
            return _dao.SeleccionarTodo();
        }

        public Detalle_venta ObtenerPorId(int id)
        {
            return _dao.SeleccionarPorId(id);
        }

        public bool Crear(int id_venta, int id_producto, int cantidad, decimal precio_unitario)
        {
            return _dao.Insertar(id_venta, id_producto, cantidad, precio_unitario);
        }

        public bool Actualizar(int id_detalle_venta, int id_venta, int id_producto, int cantidad, decimal precio_unitario)
        {
            return _dao.Actualizar(id_detalle_venta, id_venta, id_producto, cantidad, precio_unitario);
        }

        public bool Eliminar(int id)
        {
            return _dao.Eliminar(id);
        }
    }
}
