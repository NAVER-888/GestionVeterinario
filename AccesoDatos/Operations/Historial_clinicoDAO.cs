using AccesoDatos.Context;
using AccesoDatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Operations
{
    public class Historial_clinicoDAO
    {
        private BD_GESTION_VETERINARIAContext context = new BD_GESTION_VETERINARIAContext();

        public List<Historial_clinico> SeleccionarTodo()
        {
            return context.Historial_clinico.ToList();
        }

        public Historial_clinico SeleccionarPorId(int id_historial)
        {
            return context.Historial_clinico.FirstOrDefault(h => h.id_historial == id_historial);
        }

        public bool InsertarHistorial(int id_cita, int id_mascota, string diagnostico, string tratamiento, string observaciones, int? id_veterinario, DateTime? fecha_hora = null)
        {
            try
            {
                Historial_clinico historial = new Historial_clinico
                {
                    id_cita = id_cita,
                    id_mascota = id_mascota,
                    diagnostico = diagnostico,
                    tratamiento = tratamiento,
                    observaciones = observaciones,
                    id_veterinario = id_veterinario,
                    fecha_hora = fecha_hora ?? DateTime.Now
                };

                context.Historial_clinico.Add(historial);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ActualizarHistorial(int id_historial, int id_cita, int id_mascota, string diagnostico, string tratamiento, string observaciones, int? id_veterinario, DateTime? fecha_hora = null)
        {
            try
            {
                var historial = SeleccionarPorId(id_historial);
                if (historial == null)
                    return false;

                historial.id_cita = id_cita;
                historial.id_mascota = id_mascota;
                historial.diagnostico = diagnostico;
                historial.tratamiento = tratamiento;
                historial.observaciones = observaciones;
                historial.id_veterinario = id_veterinario;
                historial.fecha_hora = fecha_hora ?? historial.fecha_hora;

                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool EliminarHistorial(int id_historial)
        {
            try
            {
                var historial = SeleccionarPorId(id_historial);
                if (historial == null)
                    return false;

                context.Historial_clinico.Remove(historial);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
