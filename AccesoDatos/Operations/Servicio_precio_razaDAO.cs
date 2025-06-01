using AccesoDatos.Context;
using AccesoDatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Operations
{
    public class Servicio_precio_razaDAO
    {
        private BD_GESTION_VETERINARIAContext context = new BD_GESTION_VETERINARIAContext();

        public List<Servicio_precio_raza> SeleccionarTodo()
        {
            return context.Servicio_precio_raza.ToList();
        }

        public Servicio_precio_raza SeleccionarPorId(int id_servicio_precio)
        {
            return context.Servicio_precio_raza.FirstOrDefault(s => s.id_servicio_precio == id_servicio_precio);
        }

        public bool Insertar(int id_servicio, int? id_raza, string especie, decimal precio)
        {
            try
            {
                var nuevo = new Servicio_precio_raza
                {
                    id_servicio = id_servicio,
                    id_raza = id_raza,
                    especie = especie,
                    precio = precio
                };

                context.Servicio_precio_raza.Add(nuevo);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Actualizar(int id_servicio_precio, int id_servicio, int? id_raza, string especie, decimal precio)
        {
            try
            {
                var existente = SeleccionarPorId(id_servicio_precio);
                if (existente == null)
                    return false;

                existente.id_servicio = id_servicio;
                existente.id_raza = id_raza;
                existente.especie = especie;
                existente.precio = precio;

                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Eliminar(int id_servicio_precio)
        {
            try
            {
                var registro = SeleccionarPorId(id_servicio_precio);
                if (registro == null)
                    return false;

                context.Servicio_precio_raza.Remove(registro);
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
