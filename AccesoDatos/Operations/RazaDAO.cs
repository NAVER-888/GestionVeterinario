using AccesoDatos.Context;
using AccesoDatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Operations
{
    public class RazaDAO
    {
        private BD_GESTION_VETERINARIAContext context = new BD_GESTION_VETERINARIAContext();

        public List<Raza> SeleccionarTodasLasRazas()
        {
            return context.Raza.ToList();
        }

        public Raza SeleccionarRazaPorId(int id_raza)
        {
            return context.Raza.FirstOrDefault(r => r.id_raza == id_raza);
        }

        public bool InsertarRaza(string nombre_raza, string descripcion)
        {
            try
            {
                Raza raza = new Raza
                {
                    nombre_raza = nombre_raza,
                    descripcion = descripcion
                };

                context.Raza.Add(raza);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false; // Podrías mejorar el manejo de errores para detectar duplicados si el nombre es único.
            }
        }

        public bool ActualizarRaza(int id_raza, string nombre_raza, string descripcion)
        {
            try
            {
                var raza = SeleccionarRazaPorId(id_raza);
                if (raza == null)
                    return false;

                raza.nombre_raza = nombre_raza;
                raza.descripcion = descripcion;

                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool EliminarRaza(int id_raza)
        {
            try
            {
                var raza = SeleccionarRazaPorId(id_raza);
                if (raza == null)
                    return false;

                context.Raza.Remove(raza);
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
