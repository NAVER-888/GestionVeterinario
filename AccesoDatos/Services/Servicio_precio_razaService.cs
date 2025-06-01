using AccesoDatos.Models;
using AccesoDatos.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Services
{
    public class Servicio_precio_razaService
    {
        private readonly Servicio_precio_razaDAO _dao = new Servicio_precio_razaDAO();

        public List<Servicio_precio_raza> ObtenerTodos()
        {
            return _dao.SeleccionarTodo();
        }

        public Servicio_precio_raza ObtenerPorId(int id)
        {
            return _dao.SeleccionarPorId(id);
        }

        public bool Crear(int id_servicio, int? id_raza, string especie, decimal precio)
        {
            return _dao.Insertar(id_servicio, id_raza, especie, precio);
        }

        public bool Actualizar(int id_servicio_precio, int id_servicio, int? id_raza, string especie, decimal precio)
        {
            return _dao.Actualizar(id_servicio_precio, id_servicio, id_raza, especie, precio);
        }

        public bool Eliminar(int id_servicio_precio)
        {
            return _dao.Eliminar(id_servicio_precio);
        }
    }
}
