using AccesoDatos.Models;
using AccesoDatos.Operations;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Services
{
    public class UsuarioService
    {
        private readonly UsuarioDAO usuarioDAO = new UsuarioDAO();
        private PasswordHasher<Usuario> _hasher = new PasswordHasher<Usuario>();

        public List<Usuario> ObtenerTodos()
        {
            return usuarioDAO.seleccionarTodo();
        }

        public Usuario ObtenerPorId(int id)
        {
            return usuarioDAO.seleccionarUsuario(id);
        }

        public List<Usuario> BuscarUsuarios(int? id_usuario, string? nombre, string? apellido, string? email)
        {
            return usuarioDAO.BuscarUsuarios(id_usuario, nombre, apellido, email);
        }

        public bool Crear(Usuario nuevoUsuario)
        {
            return usuarioDAO.insertarUsuario(
                nuevoUsuario.nombre,
                nuevoUsuario.apellido,
                nuevoUsuario.email,
                nuevoUsuario.contrasena,
                nuevoUsuario.rol
            );
        }

        public bool Actualizar(Usuario usuarioActualizado)
        {
            return usuarioDAO.actualizarUsuario(
                usuarioActualizado.id_usuario,
                usuarioActualizado.nombre,
                usuarioActualizado.apellido,
                usuarioActualizado.email,
                usuarioActualizado.contrasena,
                usuarioActualizado.rol
            );
        }

        public ResultadoLogin Login(string email, string contrasenaIngresada)
        {
            var usuario = usuarioDAO.seleccionarUsuarioPorEmail(email);
            if (usuario == null)
            {
                return new ResultadoLogin { Success = false, Message = "Usuario no encontrado" };
            }

            bool passwordValida = usuarioDAO.VerificarContrasena(email, contrasenaIngresada);
            if (!passwordValida)
            {
                return new ResultadoLogin { Success = false, Message = "Contraseña incorrecta" };
            }

            // Generar token o devolver datos necesarios
            return new ResultadoLogin { Success = true, Data = usuario };
        }

        public bool Eliminar(int id)
        {
            return usuarioDAO.eliminarUsuario(id);
        }
    }
}
