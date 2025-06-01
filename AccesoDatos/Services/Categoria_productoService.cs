using AccesoDatos.Models;
using AccesoDatos.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Services
{
    public class Categoria_productoService
    {
        private readonly Categoria_productoDAO _dao = new Categoria_productoDAO();

        public List<Categoria_producto> ObtenerTodas()
        {
            return _dao.SeleccionarTodo();
        }

        public Categoria_producto ObtenerPorId(int id)
        {
            return _dao.SeleccionarPorId(id);
        }

        public bool Crear(string nombre, string descripcion)
        {
            return _dao.Insertar(nombre, descripcion);
        }

        public bool Actualizar(int id, string nombre, string descripcion)
        {
            return _dao.Actualizar(id, nombre, descripcion);
        }

        public bool Eliminar(int id)
        {
            return _dao.Eliminar(id);
        }
    }
}
