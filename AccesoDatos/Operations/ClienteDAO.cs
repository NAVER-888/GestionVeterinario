using AccesoDatos.Context;
using AccesoDatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Operations
{
    public class ClienteDAO
    {
        public BD_GESTION_VETERINARIAContext context = new BD_GESTION_VETERINARIAContext();

        public List<Cliente> seleccionarTodo()
        {
            return context.Cliente.ToList();
        }

        public Cliente seleccionarCliente(int id_cliente)
        {
            return context.Cliente.FirstOrDefault(c => c.id_cliente == id_cliente);
        }

        public bool insertarCliente(string nombre, string apellido, string direccion, string telefono, string email)
        {
            try
            {
                Cliente cliente = new Cliente
                {
                    nombre = nombre,
                    apellido = apellido,
                    direccion = direccion,
                    telefono = telefono,
                    email = email,
                    fecha_registro = DateTime.Now
                };

                context.Cliente.Add(cliente);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool actualizarCliente(int id_cliente, string nombre, string apellido, string direccion, string telefono, string email)
        {
            try
            {
                var cliente = seleccionarCliente(id_cliente);
                if (cliente == null)
                    return false;

                cliente.nombre = nombre;
                cliente.apellido = apellido;
                cliente.direccion = direccion;
                cliente.telefono = telefono;
                cliente.email = email;

                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool eliminarCliente(int id_cliente)
        {
            try
            {
                var cliente = seleccionarCliente(id_cliente);
                if (cliente == null)
                    return false;

                context.Cliente.Remove(cliente);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
