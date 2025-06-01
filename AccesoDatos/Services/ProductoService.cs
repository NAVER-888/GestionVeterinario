using AccesoDatos.Models;
using AccesoDatos.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Services
{
    public class ProductoService
    {
        private readonly ProductoDAO _dao = new ProductoDAO();

        public List<Producto> ObtenerTodos()
        {
            return _dao.seleccionarTodo();
        }

        public Producto ObtenerPorId(int id)
        {
            return _dao.seleccionarProducto(id);
        }

        public bool Crear(string nombre, int idCategoria, string descripcion, decimal precio, int stock)
        {
            return _dao.insertarProducto(nombre, idCategoria, descripcion, precio, stock);
        }

        public bool Actualizar(int id, string nombre, int idCategoria, string descripcion, decimal precio, int stock)
        {
            return _dao.actualizarProducto(id, nombre, idCategoria, descripcion, precio, stock);
        }

        public bool Eliminar(int id)
        {
            return _dao.eliminarProducto(id);
        }
    }
}
