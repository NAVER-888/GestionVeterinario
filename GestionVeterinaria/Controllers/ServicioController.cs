using AccesoDatos.Models;
using AccesoDatos.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionVeterinaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicioController : ControllerBase
    {
        private readonly ServicioService _service = new ServicioService();

        [HttpGet("listar")]
        public ActionResult<List<Servicio>> Get()
        {
            return _service.ObtenerTodos();
        }

        [HttpGet("buscar")]
        public ActionResult<Servicio> Get(int id)
        {
            var servicio = _service.ObtenerPorId(id);
            if (servicio == null)
                return NotFound("Servicio no encontrado.");
            return Ok(servicio);
        }

        [HttpPost("insertar")]
        public IActionResult Post([FromBody] Servicio servicio)
        {
            var ok = _service.Crear(servicio.nombre_servicio, servicio.descripcion, (float)servicio.precio);

            if (!ok)
                return BadRequest("Error al crear el servicio.");

            return Ok("Servicio registrado correctamente.");
        }

        [HttpPut("actualizar")]
        public IActionResult Put(int id, [FromBody] Servicio servicio)
        {
            var ok = _service.Actualizar(id, servicio.nombre_servicio, servicio.descripcion, (float)servicio.precio);

            if (!ok)
                return NotFound("Servicio no encontrado o error al actualizar.");

            return Ok("Servicio actualizado correctamente.");
        }

        [HttpDelete("eliminar")]
        public IActionResult Delete(int id)
        {
            var ok = _service.Eliminar(id);
            if (!ok)
                return NotFound("Servicio no encontrado o error al eliminar.");

            return Ok("Servicio eliminado correctamente.");
        }

        [HttpGet("ServicioRazaPrecio")]
        public ActionResult<List<ServicioRazaPrecio>> GetServicioRazaPrecio()
        {
            var resultados = _service.ObtenerServicioRazaPrecios();
            return Ok(resultados);
        }
    }
}
