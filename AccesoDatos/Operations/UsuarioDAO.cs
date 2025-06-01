using Microsoft.AspNetCore.Identity;
using AccesoDatos.Context;
using AccesoDatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Operations
{
    public class UsuarioDAO
    {
        private BD_GESTION_VETERINARIAContext context = new BD_GESTION_VETERINARIAContext();

        private PasswordHasher<Usuario> passwordHasher = new PasswordHasher<Usuario>();

        public List<Usuario> seleccionarTodo()
        {
            return context.Usuario.ToList();
        }

        public Usuario seleccionarUsuario(int id_usuario)
        {
            return context.Usuario.FirstOrDefault(u => u.id_usuario == id_usuario);
        }

        public Usuario seleccionarUsuarioPorEmail(string email)
        {
            return context.Usuario.FirstOrDefault(u => u.email == email);
        }

        public List<Usuario> BuscarUsuarios(int? id_usuario, string? nombre, string? apellido, string? email)
        {
            return context.Usuario
                .Where(u =>
                    (!id_usuario.HasValue || u.id_usuario == id_usuario.Value) &&
                    (string.IsNullOrEmpty(nombre) || u.nombre.Contains(nombre)) &&
                    (string.IsNullOrEmpty(apellido) || u.apellido.Contains(apellido)) &&
                    (string.IsNullOrEmpty(email) || u.email.Contains(email))
                )
                .ToList();
        }

        public bool insertarUsuario(string nombre, string apellido, string email, string contrasena, string rol)
        {
            try
            {
                Usuario usuario = new Usuario
                {
                    nombre = nombre,
                    apellido = apellido,
                    email = email,
                    contrasena = contrasena,
                    rol = rol,
                    estado = "Activo", // Opcional, porque ya tiene DEFAULT en la BD
                    fecha_creacion = DateTime.Now // Opcional también
                };

                usuario.contrasena = passwordHasher.HashPassword(usuario, contrasena);

                context.Usuario.Add(usuario);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool actualizarUsuario(int id_usuario, string nombre, string apellido, string email, string contrasena, string rol)
        {
            try
            {
                var usuario = seleccionarUsuario(id_usuario);
                if (usuario == null)
                    return false;

                usuario.nombre = nombre;
                usuario.apellido = apellido;
                usuario.email = email;
                usuario.contrasena = contrasena;
                usuario.rol = rol;

                if (!string.IsNullOrEmpty(contrasena))
                {
                    usuario.contrasena = passwordHasher.HashPassword(usuario, contrasena);
                }

                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Método para verificar contraseña al login
        public bool VerificarContrasena(string email, string contrasenaIngresada)
        {
            var usuario = seleccionarUsuarioPorEmail(email);
            if (usuario == null)
                return false;

            var resultado = passwordHasher.VerifyHashedPassword(usuario, usuario.contrasena, contrasenaIngresada);
            return resultado == PasswordVerificationResult.Success || resultado == PasswordVerificationResult.SuccessRehashNeeded;
        }

        public bool eliminarUsuario(int id_usuario)
        {
            try
            {
                var usuario = seleccionarUsuario(id_usuario);
                if (usuario == null)
                    return false;

                context.Usuario.Remove(usuario);
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
