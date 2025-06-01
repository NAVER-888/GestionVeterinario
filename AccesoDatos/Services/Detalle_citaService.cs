using AccesoDatos.Models;
using AccesoDatos.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Services
{
    public class Detalle_citaService
    {
        private readonly Detalle_citaDAO _dao = new Detalle_citaDAO();

        public List<Detalle_cita> ObtenerTodos()
        {
            return _dao.SeleccionarTodo();
        }

        public Detalle_cita ObtenerPorId(int id)
        {
            return _dao.SeleccionarPorId(id);
        }

        public bool CrearDetalle(int id_cita, int id_servicio, int cantidad, decimal precio_unitario)
        {
            return _dao.Insertar(id_cita, id_servicio, cantidad, precio_unitario);
        }

        public bool ActualizarDetalle(int id_cita_servicio, int id_cita, int id_servicio, int cantidad, decimal precio_unitario)
        {
            return _dao.Actualizar(id_cita_servicio, id_cita, id_servicio, cantidad, precio_unitario);
        }

        public bool EliminarDetalle(int id_cita_servicio)
        {
            return _dao.Eliminar(id_cita_servicio);
        }
    }
}
