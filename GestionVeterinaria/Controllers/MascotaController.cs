using AccesoDatos.Models;
using AccesoDatos.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionVeterinaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MascotaController : ControllerBase
    {
        private readonly MascotaService _service = new MascotaService();

        [HttpGet("lista")]
        public ActionResult<List<Mascota>> Get()
        {
            return _service.ObtenerTodas();
        }

        [HttpGet("buscar")]
        public ActionResult<Mascota> Get(int id)
        {
            var mascota = _service.ObtenerPorId(id);
            if (mascota == null)
                return NotFound("Mascota no encontrada.");
            return Ok(mascota);
        }

        [HttpPost("insertar")]
        public IActionResult Post([FromBody] Mascota mascota)
        {
            var ok = _service.Crear(mascota.id_cliente, mascota.nombre,
                                    mascota.fecha_nacimiento, mascota.sexo,
                                    mascota.especie, mascota.id_raza,
                                    mascota.color, mascota.peso);

            if (!ok)
                return BadRequest("Error al crear la mascota.");

            return Ok("Mascota registrada correctamente.");
        }

        [HttpPut("actualizar")]
        public IActionResult Put(int id, [FromBody] Mascota mascota)
        {
            var ok = _service.Actualizar(id, mascota.id_cliente, mascota.nombre,
                                         mascota.fecha_nacimiento, mascota.sexo,
                                         mascota.especie, mascota.id_raza,
                                         mascota.color, mascota.peso);

            if (!ok)
                return NotFound("Mascota no encontrada o error al actualizar.");

            return Ok("Mascota actualizada correctamente.");
        }

        [HttpDelete("eliminar")]
        public IActionResult Delete(int id)
        {
            var ok = _service.Eliminar(id);
            if (!ok)
                return NotFound("Mascota no encontrada o error al eliminar.");

            return Ok("Mascota eliminada correctamente.");
        }
    }
}
