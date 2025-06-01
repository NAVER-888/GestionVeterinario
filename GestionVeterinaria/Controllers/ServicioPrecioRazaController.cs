using AccesoDatos.Models;
using AccesoDatos.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionVeterinaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicioPrecioRazaController : ControllerBase
    {
        private readonly Servicio_precio_razaService _service = new Servicio_precio_razaService();

        [HttpGet("lista")]
        public ActionResult<List<Servicio_precio_raza>> Get()
        {
            return _service.ObtenerTodos();
        }

        [HttpGet("buscar")]
        public ActionResult<Servicio_precio_raza> Get(int id)
        {
            var registro = _service.ObtenerPorId(id);
            if (registro == null)
                return NotFound("Registro no encontrado.");
            return Ok(registro);
        }

        [HttpPost("insertar")]
        public IActionResult Post([FromBody] Servicio_precio_raza data)
        {
            var ok = _service.Crear(data.id_servicio, data.id_raza, data.especie, data.precio);
            if (!ok)
                return BadRequest("Error al insertar el registro.");
            return Ok("Registro creado correctamente.");
        }

        [HttpPut("actualizar")]
        public IActionResult Put(int id, [FromBody] Servicio_precio_raza data)
        {
            var ok = _service.Actualizar(id, data.id_servicio, data.id_raza, data.especie, data.precio);
            if (!ok)
                return NotFound("Registro no encontrado o error al actualizar.");
            return Ok("Registro actualizado correctamente.");
        }

        [HttpDelete("eliminar")]
        public IActionResult Delete(int id)
        {
            var ok = _service.Eliminar(id);
            if (!ok)
                return NotFound("Registro no encontrado o error al eliminar.");
            return Ok("Registro eliminado correctamente.");
        }
    }
}
