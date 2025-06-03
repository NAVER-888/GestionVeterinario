using AccesoDatos.Models;
using AccesoDatos.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace GestionVeterinaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _usuarioService = new UsuarioService();
        private readonly TokenService _tokenService;

        public UsuarioController(UsuarioService usuarioService, TokenService tokenService)
        {
            _usuarioService = usuarioService;
            _tokenService = tokenService;
        }

        [HttpGet]
        //[Authorize(Roles = "Administrador")]
        public IActionResult GetUsuarios()
        {
            var usuarios = _usuarioService.ObtenerTodos();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Administrador")]
        public IActionResult GetUsuario(int id)
        {
            var usuario = _usuarioService.ObtenerPorId(id);
            if (usuario == null)
                return NotFound();

            return Ok(usuario);
        }

        [HttpGet("buscar")]
        //[Authorize(Roles = "Administrador")]
        public IActionResult BuscarUsuarios([FromQuery] int? id_usuario, [FromQuery] string? nombre, [FromQuery] string? apellido, [FromQuery] string? email)
        {
            var usuarios = _usuarioService.BuscarUsuarios(id_usuario, nombre, apellido, email);

            if (usuarios == null || usuarios.Count == 0)
            {
                return NotFound("No se encontraron usuarios con los criterios dados.");
            }

            return Ok(usuarios);
        }

        [HttpPost("insertar")]
        //[Authorize(Roles = "Administrador")]
        public IActionResult CrearUsuario([FromBody] Usuario usuario)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            bool creado = _usuarioService.Crear(usuario);
            if (!creado)
                return StatusCode(500, "Error al crear el usuario.");

            return Ok(new { mensaje = "Usuario creado exitosamente." });
        }

        [HttpPut("actualizar")]
        //[Authorize(Roles = "Administrador")]
        public IActionResult ActualizarUsuario([FromBody] Usuario usuario)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            bool actualizado = _usuarioService.Actualizar(usuario);
            if (!actualizado)
                return NotFound(new { mensaje = "Usuario no encontrado o error al actualizar." });

            return Ok(new { mensaje = "Usuario actualizado exitosamente." });
        }

        [HttpDelete("eliminar")]
        [Authorize(Roles = "Administrador")]
        public IActionResult EliminarUsuario(int id)
        {
            bool eliminado = _usuarioService.Eliminar(id);
            if (!eliminado)
                return NotFound(new { mensaje = "Usuario no encontrado o error al eliminar." });

            return Ok(new { mensaje = "Usuario eliminado exitosamente." });
        }

        // Ruta: POST /login
        // Este método permite a un usuario iniciar sesión con su email y contraseña.
        // Si las credenciales son válidas, se genera un token JWT y se devuelve al cliente.
        [HttpPost("login")]
        public IActionResult Login([FromBody] Login request)
        {
            // Validación básica de los campos requeridos
            if (request == null || string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Contrasena))
                return BadRequest(new ResultadoLogin { Success = false, Message = "Email y contraseña son requeridos." });

            // Se intenta autenticar al usuario mediante el servicio
            var resultado = _usuarioService.Login(request.Email, request.Contrasena);

            // Si las credenciales son incorrectas, se retorna 401 Unauthorized
            if (!resultado.Success)
                return Unauthorized(resultado);

            // Si el login es exitoso, se genera un token JWT
            var token = _tokenService.GenerarToken(resultado.Data);
            resultado.Token = token;

            // Se establece un mensaje de éxito
            resultado.Message = "Login exitoso";

            // Se retorna el resultado con el token
            return Ok(resultado);
        }
    }
}
