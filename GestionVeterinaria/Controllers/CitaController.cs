using AccesoDatos.Models;
using AccesoDatos.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionVeterinaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitaController : ControllerBase
    {
        private readonly CitaService _service = new CitaService();

        // GET: api/Cita
        [HttpGet]
        public ActionResult<List<Cita>> Get()
        {
            return _service.ObtenerTodas();
        }

        // GET: api/Cita/5
        [HttpGet("{id}")]
        public ActionResult<Cita> Get(int id)
        {
            var cita = _service.ObtenerPorId(id);
            if (cita == null)
                return NotFound("Cita no encontrada.");
            return Ok(cita);
        }

        // POST: api/Cita
        [HttpPost]
        public IActionResult Post([FromBody] Cita data)
        {
            var ok = _service.Crear(data.id_mascota, data.fecha_hora, data.motivo, data.id_veterinario, data.estado, data.notas);
            if (!ok)
                return BadRequest("Error al crear la cita.");
            return Ok("Cita creada correctamente.");
        }

        // PUT: api/Cita/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Cita data)
        {
            var ok = _service.Actualizar(id, data.id_mascota, data.fecha_hora, data.motivo, data.id_veterinario, data.estado, data.notas);
            if (!ok)
                return NotFound("Error al actualizar la cita o no existe.");
            return Ok("Cita actualizada correctamente.");
        }

        // DELETE: api/Cita/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var ok = _service.Eliminar(id);
            if (!ok)
                return NotFound("Error al eliminar la cita o no existe.");
            return Ok("Cita eliminada correctamente.");
        }
    }
}
