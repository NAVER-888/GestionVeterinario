using AccesoDatos.Models;
using AccesoDatos.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Services
{
    public class MascotaService
    {
        private readonly MascotaDAO _dao = new MascotaDAO();

        public List<Mascota> ObtenerTodas()
        {
            return _dao.SeleccionarTodasLasMascotas();
        }

        public Mascota ObtenerPorId(int id)
        {
            return _dao.SeleccionarMascotaPorId(id);
        }

        public bool Crear(int idCliente, string nombre, DateOnly? fechaNacimiento,
                          string sexo, string especie, int? idRaza, string color, decimal? peso)
        {
            return _dao.InsertarMascota(idCliente, nombre, fechaNacimiento, sexo, especie, idRaza, color, peso);
        }

        public bool Actualizar(int idMascota, int idCliente, string nombre, DateOnly? fechaNacimiento,
                               string sexo, string especie, int? idRaza, string color, decimal? peso)
        {
            return _dao.ActualizarMascota(idMascota, idCliente, nombre, fechaNacimiento, sexo, especie, idRaza, color, peso);
        }

        public bool Eliminar(int idMascota)
        {
            return _dao.EliminarMascota(idMascota);
        }
    }
}
