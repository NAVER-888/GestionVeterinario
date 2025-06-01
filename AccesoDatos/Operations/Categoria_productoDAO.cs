using AccesoDatos.Context;
using AccesoDatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Operations
{
    public class Categoria_productoDAO
    {
        private BD_GESTION_VETERINARIAContext context = new BD_GESTION_VETERINARIAContext();

        public List<Categoria_producto> SeleccionarTodo()
        {
            return context.Categoria_producto.ToList();
        }

        public Categoria_producto SeleccionarPorId(int id_categoria)
        {
            return context.Categoria_producto.FirstOrDefault(c => c.id_categoria == id_categoria);
        }

        public bool Insertar(string nombre_categoria, string descripcion)
        {
            try
            {
                var categoria = new Categoria_producto
                {
                    nombre_categoria = nombre_categoria,
                    descripcion = descripcion
                };

                context.Categoria_producto.Add(categoria);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Actualizar(int id_categoria, string nombre_categoria, string descripcion)
        {
            try
            {
                var categoria = SeleccionarPorId(id_categoria);
                if (categoria == null)
                    return false;

                categoria.nombre_categoria = nombre_categoria;
                categoria.descripcion = descripcion;

                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Eliminar(int id_categoria)
        {
            try
            {
                var categoria = SeleccionarPorId(id_categoria);
                if (categoria == null)
                    return false;

                context.Categoria_producto.Remove(categoria);
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
