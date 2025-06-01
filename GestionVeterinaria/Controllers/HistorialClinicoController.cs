using AccesoDatos.Models;
using AccesoDatos.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionVeterinaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistorialClinicoController : ControllerBase
    {
        private readonly Historial_clinicoService _service = new Historial_clinicoService();

        [HttpGet("lista")]
        public ActionResult<List<Historial_clinico>> Get()
        {
            return _service.ObtenerTodos();
        }

        [HttpGet("buscar")]
        public ActionResult<Historial_clinico> Get(int id)
        {
            var historial = _service.ObtenerPorId(id);
            if (historial == null)
                return NotFound("Historial clínico no encontrado.");

            return Ok(historial);
        }

        [HttpPost("insertar")]
        public IActionResult Post([FromBody] Historial_clinico dto)
        {
            var ok = _service.Crear(dto.id_cita, dto.id_mascota,
                                     dto.diagnostico, dto.tratamiento,
                                     dto.observaciones, dto.id_veterinario);

            if (!ok)
                return BadRequest("Error al crear el historial clínico.");

            return Ok("Historial clínico creado correctamente.");
        }

        [HttpPut("actualizar")]
        public IActionResult Put(int id, [FromBody] Historial_clinico dto)
        {
            var ok = _service.Actualizar(id, dto.id_cita, dto.id_mascota,
                                         dto.diagnostico, dto.tratamiento,
                                         dto.observaciones, dto.id_veterinario);

            if (!ok)
                return NotFound("Historial clínico no encontrado o error al actualizar.");

            return Ok("Historial clínico actualizado correctamente.");
        }

        [HttpDelete("eliminar")]
        public IActionResult Delete(int id)
        {
            var ok = _service.Eliminar(id);
            if (!ok)
                return NotFound("Historial clínico no encontrado o error al eliminar.");

            return Ok("Historial clínico eliminado correctamente.");
        }
    }
}
