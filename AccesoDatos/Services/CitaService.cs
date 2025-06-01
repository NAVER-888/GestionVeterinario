using AccesoDatos.Models;
using AccesoDatos.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Services
{
    public class CitaService
    {
        private readonly CitaDAO _dao = new CitaDAO();

        public List<Cita> ObtenerTodas()
        {
            return _dao.SeleccionarTodasLasCitas();
        }

        public Cita ObtenerPorId(int id)
        {
            return _dao.SeleccionarCitaPorId(id);
        }

        public bool Crear(int id_mascota, DateTime fecha_hora, string motivo, int? id_veterinario, string estado, string notas)
        {
            return _dao.InsertarCita(id_mascota, fecha_hora, motivo, id_veterinario, estado, notas);
        }

        public bool Actualizar(int id_cita, int id_mascota, DateTime fecha_hora, string motivo, int? id_veterinario, string estado, string notas)
        {
            return _dao.ActualizarCita(id_cita, id_mascota, fecha_hora, motivo, id_veterinario, estado, notas);
        }

        public bool Eliminar(int id_cita)
        {
            return _dao.EliminarCita(id_cita);
        }
    }
}
