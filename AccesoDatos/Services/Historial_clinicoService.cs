using AccesoDatos.Models;
using AccesoDatos.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Services
{
    public class Historial_clinicoService
    {
        private readonly Historial_clinicoDAO _dao = new Historial_clinicoDAO();

        public List<Historial_clinico> ObtenerTodos()
        {
            return _dao.SeleccionarTodo();
        }

        public Historial_clinico ObtenerPorId(int id)
        {
            return _dao.SeleccionarPorId(id);
        }

        public bool Crear(int idCita, int idMascota, string diagnostico,
                          string tratamiento, string observaciones, int? idVeterinario)
        {
            return _dao.InsertarHistorial(idCita, idMascota, diagnostico,
                                          tratamiento, observaciones, idVeterinario);
        }

        public bool Actualizar(int idHistorial, int idCita, int idMascota, string diagnostico,
                               string tratamiento, string observaciones, int? idVeterinario)
        {
            return _dao.ActualizarHistorial(idHistorial, idCita, idMascota, diagnostico,
                                            tratamiento, observaciones, idVeterinario);
        }

        public bool Eliminar(int idHistorial)
        {
            return _dao.EliminarHistorial(idHistorial);
        }
    }
}
