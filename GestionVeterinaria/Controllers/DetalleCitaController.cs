using AccesoDatos.Models;
using AccesoDatos.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionVeterinaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleCitaController : ControllerBase
    {
        private readonly Detalle_citaService _service = new Detalle_citaService();

        [HttpGet("lista")]
        public ActionResult<List<Detalle_cita>> Get()
        {
            return _service.ObtenerTodos();
        }

        [HttpGet("buscar")]
        public ActionResult<Detalle_cita> Get(int id)
        {
            var detalle = _service.ObtenerPorId(id);
            if (detalle == null)
                return NotFound("Detalle de cita no encontrado.");

            return Ok(detalle);
        }

        [HttpPost("insertar")]
        public IActionResult Post([FromBody] Detalle_cita detalle)
        {
            var resultado = _service.CrearDetalle(
                detalle.id_cita,
                detalle.id_servicio,
                detalle.cantidad,
                detalle.precio_unitario
            );

            if (!resultado)
                return BadRequest("Error al crear el detalle.");

            return Ok("Detalle de cita creado correctamente.");
        }

        [HttpPut("actualizar")]
        public IActionResult Put(int id, [FromBody] Detalle_cita detalle)
        {
            var resultado = _service.ActualizarDetalle(
                id,
                detalle.id_cita,
                detalle.id_servicio,
                detalle.cantidad,
                detalle.precio_unitario
            );

            if (!resultado)
                return NotFound("No se pudo actualizar el detalle de cita.");

            return Ok("Detalle de cita actualizado correctamente.");
        }

        [HttpDelete("eliminar")]
        public IActionResult Delete(int id)
        {
            var resultado = _service.EliminarDetalle(id);

            if (!resultado)
                return NotFound("No se pudo eliminar el detalle de cita.");

            return Ok("Detalle de cita eliminado correctamente.");
        }
    }
}
