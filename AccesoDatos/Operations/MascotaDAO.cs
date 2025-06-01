using AccesoDatos.Context;
using AccesoDatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Operations
{
    public class MascotaDAO
    {
        private BD_GESTION_VETERINARIAContext context = new BD_GESTION_VETERINARIAContext();

        public List<Mascota> SeleccionarTodasLasMascotas()
        {
            return context.Mascota.ToList();
        }

        public Mascota SeleccionarMascotaPorId(int id_mascota)
        {
            return context.Mascota.FirstOrDefault(m => m.id_mascota == id_mascota);
        }

        public bool InsertarMascota(int id_cliente, string nombre, DateOnly? fecha_nacimiento, string sexo, string especie, int? id_raza, string color, decimal? peso)
        {
            try
            {
                Mascota mascota = new Mascota
                {
                    id_cliente = id_cliente,
                    nombre = nombre,
                    fecha_nacimiento = fecha_nacimiento,
                    sexo = sexo,
                    especie = especie,
                    id_raza = id_raza,
                    color = color,
                    peso = peso,
                    fecha_registro = DateTime.Now
                };

                context.Mascota.Add(mascota);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ActualizarMascota(int id_mascota, int id_cliente, string nombre, DateOnly? fecha_nacimiento, string sexo, string especie, int? id_raza, string color, decimal? peso)
        {
            try
            {
                var mascota = SeleccionarMascotaPorId(id_mascota);
                if (mascota == null)
                    return false;

                mascota.id_cliente = id_cliente;
                mascota.nombre = nombre;
                mascota.fecha_nacimiento = fecha_nacimiento;
                mascota.sexo = sexo;
                mascota.especie = especie;
                mascota.id_raza = id_raza;
                mascota.color = color;
                mascota.peso = peso;

                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool EliminarMascota(int id_mascota)
        {
            try
            {
                var mascota = SeleccionarMascotaPorId(id_mascota);
                if (mascota == null)
                    return false;

                context.Mascota.Remove(mascota);
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
