using AccesoDatos.Models;
using AccesoDatos.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Services
{
    public class RazaService
    {
        private readonly RazaDAO _razaDAO = new RazaDAO();

        public List<Raza> ObtenerTodasLasRazas()
        {
            return _razaDAO.SeleccionarTodasLasRazas();
        }

        public Raza ObtenerRazaPorId(int id)
        {
            return _razaDAO.SeleccionarRazaPorId(id);
        }

        public bool CrearRaza(string nombre_raza, string descripcion)
        {
            return _razaDAO.InsertarRaza(nombre_raza, descripcion);
        }

        public bool ActualizarRaza(int id_raza, string nombre_raza, string descripcion)
        {
            return _razaDAO.ActualizarRaza(id_raza, nombre_raza, descripcion);
        }

        public bool EliminarRaza(int id_raza)
        {
            return _razaDAO.EliminarRaza(id_raza);
        }
    }
}
