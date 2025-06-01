using AccesoDatos.Models;
using AccesoDatos.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionVeterinaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RazaController : ControllerBase
    {
        private readonly RazaService _razaService = new RazaService();

        [HttpGet("lista")]
        public ActionResult<List<Raza>> Get()
        {
            return _razaService.ObtenerTodasLasRazas();
        }

        [HttpGet("buscar")]
        public ActionResult<Raza> Get(int id)
        {
            var raza = _razaService.ObtenerRazaPorId(id);
            if (raza == null)
                return NotFound("Raza no encontrada.");

            return Ok(raza);
        }

        [HttpPost("insertar")]
        public IActionResult Post([FromBody] Raza raza)
        {
            var resultado = _razaService.CrearRaza(raza.nombre_raza, raza.descripcion);
            if (!resultado)
                return BadRequest("Error al crear la raza.");

            return Ok("Raza creada correctamente.");
        }

        [HttpPut("actualizar")]
        public IActionResult Put(int id, [FromBody] Raza raza)
        {
            var resultado = _razaService.ActualizarRaza(id, raza.nombre_raza, raza.descripcion);
            if (!resultado)
                return NotFound("Raza no encontrada o error al actualizar.");

            return Ok("Raza actualizada correctamente.");
        }

        [HttpDelete("eliminar")]
        public IActionResult Delete(int id)
        {
            var resultado = _razaService.EliminarRaza(id);
            if (!resultado)
                return NotFound("Raza no encontrada o error al eliminar.");

            return Ok("Raza eliminada correctamente.");
        }
    }
}
