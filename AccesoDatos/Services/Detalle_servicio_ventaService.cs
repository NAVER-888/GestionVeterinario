using AccesoDatos.Models;
using AccesoDatos.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Services
{
    public class Detalle_servicio_ventaService
    {
        private readonly Detalle_servicio_ventaDAO _dao = new Detalle_servicio_ventaDAO();

        public List<Detalle_servicio_venta> ObtenerTodos()
        {
            return _dao.SeleccionarTodo();
        }

        public Detalle_servicio_venta ObtenerPorId(int id)
        {
            return _dao.SeleccionarPorId(id);
        }

        public bool Crear(int id_venta, int id_servicio, int cantidad, decimal precio_unitario, int? empleado_asignado, string notas)
        {
            return _dao.Insertar(id_venta, id_servicio, cantidad, precio_unitario, empleado_asignado, notas);
        }

        public bool Actualizar(int id_detalle_servicio, int id_venta, int id_servicio, int cantidad, decimal precio_unitario, int? empleado_asignado, string notas)
        {
            return _dao.Actualizar(id_detalle_servicio, id_venta, id_servicio, cantidad, precio_unitario, empleado_asignado, notas);
        }

        public bool Eliminar(int id)
        {
            return _dao.Eliminar(id);
        }
    }
}
