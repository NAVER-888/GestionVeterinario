using AccesoDatos.Context;
using AccesoDatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Operations
{
    public class CitaDAO
    {
        private BD_GESTION_VETERINARIAContext context = new BD_GESTION_VETERINARIAContext();

        public List<Cita> SeleccionarTodasLasCitas()
        {
            return context.Cita.ToList();
        }

        public Cita SeleccionarCitaPorId(int id_cita)
        {
            return context.Cita.FirstOrDefault(c => c.id_cita == id_cita);
        }

        public bool InsertarCita(int id_mascota, DateTime fecha_hora, string motivo, int? id_veterinario, string estado, string notas)
        {
            try
            {
                Cita cita = new Cita
                {
                    id_mascota = id_mascota,
                    fecha_hora = fecha_hora,
                    motivo = motivo,
                    id_veterinario = id_veterinario,
                    estado = estado,
                    notas = notas,
                    fecha_creacion = DateTime.Now
                };

                context.Cita.Add(cita);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ActualizarCita(int id_cita, int id_mascota, DateTime fecha_hora, string motivo, int? id_veterinario, string estado, string notas)
        {
            try
            {
                var cita = SeleccionarCitaPorId(id_cita);
                if (cita == null)
                    return false;

                cita.id_mascota = id_mascota;
                cita.fecha_hora = fecha_hora;
                cita.motivo = motivo;
                cita.id_veterinario = id_veterinario;
                cita.estado = estado;
                cita.notas = notas;

                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool EliminarCita(int id_cita)
        {
            try
            {
                var cita = SeleccionarCitaPorId(id_cita);
                if (cita == null)
                    return false;

                context.Cita.Remove(cita);
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
