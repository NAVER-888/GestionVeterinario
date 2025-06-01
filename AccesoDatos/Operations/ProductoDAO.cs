using AccesoDatos.Context;
using AccesoDatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Operations
{
    public class ProductoDAO
    {
        public BD_GESTION_VETERINARIAContext context = new BD_GESTION_VETERINARIAContext();

        public List<Producto> seleccionarTodo()
        {
            return context.Producto.ToList();
        }

        public Producto seleccionarProducto(int id_producto)
        {
            return context.Producto.Where(p => p.id_producto == id_producto).FirstOrDefault();
        }

        public bool insertarProducto(string nombre_producto, int id_categoria, string descripcion, decimal precio_unitario, int cantidad_en_stock)
        {
            try
            {
                Producto producto = new Producto
                {
                    nombre_producto = nombre_producto,
                    id_categoria = id_categoria,
                    descripcion = descripcion,
                    precio_unitario = precio_unitario,
                    cantidad_en_stock = cantidad_en_stock,
                    fecha_ultima_actualizacion = DateTime.Now
                };

                context.Producto.Add(producto);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool actualizarProducto(int id_producto, string nombre_producto, int id_categoria, string descripcion, decimal precio_unitario, int cantidad_en_stock)
        {
            try
            {
                var producto = seleccionarProducto(id_producto);

                if (producto == null)
                    return false;

                producto.nombre_producto = nombre_producto;
                producto.id_categoria = id_categoria;
                producto.descripcion = descripcion;
                producto.precio_unitario = precio_unitario;
                producto.cantidad_en_stock = cantidad_en_stock;
                producto.fecha_ultima_actualizacion = DateTime.Now;

                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool eliminarProducto(int id_producto)
        {
            try
            {
                var producto = seleccionarProducto(id_producto);
                if (producto == null)
                    return false;

                context.Producto.Remove(producto);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<ProductoCategoria> seleccionarProductosConCategoria()
        {
            var query = from p in context.Producto
                        join c in context.Categoria_producto
                        on p.id_categoria equals c.id_categoria
                        select new ProductoCategoria
                        {
                            NombreProducto = p.nombre_producto,
                            NombreCategoria = c.nombre_categoria                        };

            return query.ToList();
        }
    }
}
