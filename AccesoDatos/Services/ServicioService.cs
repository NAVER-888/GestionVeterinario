using AccesoDatos.Models;
using AccesoDatos.operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Services
{
    public class ServicioService
    {
        private readonly ServicioDAO _dao = new ServicioDAO();

        public List<Servicio> ObtenerTodos()
        {
            return _dao.seleccionarTodo();
        }

        public Servicio ObtenerPorId(int id)
        {
            return _dao.seleccionarServicio(id);
        }

        public bool Crear(string nombre, string descripcion, float precio)
        {
            return _dao.insertarServicio(nombre, descripcion, precio);
        }

        public bool Actualizar(int id, string nombre, string descripcion, float precio)
        {
            return _dao.actualizar(id, nombre, descripcion, precio);
        }

        public bool Eliminar(int id)
        {
            return _dao.eliminar(id);
        }

        public List<ServicioRazaPrecio> ObtenerServicioRazaPrecios()
        {
            return _dao.ServicioRazaPrecios();
        }
    }
}
