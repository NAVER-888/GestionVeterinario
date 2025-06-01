using AccesoDatos.Models;
using AccesoDatos.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionVeterinaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteService _service = new ClienteService();

        [HttpGet("lista")]
        public ActionResult<List<Cliente>> Get()
        {
            return _service.ObtenerTodos();
        }

        [HttpGet("buscar")]
        public ActionResult<Cliente> Get(int id)
        {
            var cliente = _service.ObtenerPorId(id);
            if (cliente == null)
                return NotFound("Cliente no encontrado.");
            return Ok(cliente);
        }

        [HttpPost("insertar")]
        public IActionResult Post([FromBody] Cliente data)
        {
            var ok = _service.Crear(data.nombre, data.apellido, data.direccion, data.telefono, data.email);
            if (!ok)
                return BadRequest("No se pudo registrar el cliente.");
            return Ok("Cliente registrado correctamente.");
        }

        [HttpPut("actualizar")]
        public IActionResult Put(int id, [FromBody] Cliente data)
        {
            var ok = _service.Actualizar(id, data.nombre, data.apellido, data.direccion, data.telefono, data.email);
            if (!ok)
                return NotFound("No se pudo actualizar el cliente.");
            return Ok("Cliente actualizado correctamente.");
        }

        [HttpDelete("eliminar")]
        public IActionResult Delete(int id)
        {
            var ok = _service.Eliminar(id);
            if (!ok)
                return NotFound("No se pudo eliminar el cliente.");
            return Ok("Cliente eliminado correctamente.");
        }
    }
}
