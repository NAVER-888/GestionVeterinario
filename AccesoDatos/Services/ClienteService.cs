using AccesoDatos.Models;
using AccesoDatos.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Services
{
    public class ClienteService
    {
        private readonly ClienteDAO _dao = new ClienteDAO();

        public List<Cliente> ObtenerTodos()
        {
            return _dao.seleccionarTodo();
        }

        public Cliente ObtenerPorId(int id)
        {
            return _dao.seleccionarCliente(id);
        }

        public bool Crear(string nombre, string apellido, string direccion, string telefono, string email)
        {
            return _dao.insertarCliente(nombre, apellido, direccion, telefono, email);
        }

        public bool Actualizar(int id, string nombre, string apellido, string direccion, string telefono, string email)
        {
            return _dao.actualizarCliente(id, nombre, apellido, direccion, telefono, email);
        }

        public bool Eliminar(int id)
        {
            return _dao.eliminarCliente(id);
        }
    }
}
