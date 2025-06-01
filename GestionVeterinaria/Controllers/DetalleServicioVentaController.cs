using AccesoDatos.Models;
using AccesoDatos.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionVeterinaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleServicioVentaController : ControllerBase
    {
        private readonly Detalle_servicio_ventaService _service = new Detalle_servicio_ventaService();

        [HttpGet("lista")]
        public ActionResult<List<Detalle_servicio_venta>> Get()
        {
            return _service.ObtenerTodos();
        }

        [HttpGet("buscar")]
        public ActionResult<Detalle_servicio_venta> Get(int id)
        {
            var detalle = _service.ObtenerPorId(id);
            if (detalle == null)
                return NotFound("Detalle de servicio no encontrado.");
            return Ok(detalle);
        }

        [HttpPost("insertar")]
        public IActionResult Post([FromBody] Detalle_servicio_venta data)
        {
            var ok = _service.Crear(data.id_venta, data.id_servicio, data.cantidad, data.precio_unitario, data.empleado_asignado, data.notas);
            if (!ok)
                return BadRequest("Error al registrar el detalle de servicio.");
            return Ok("Detalle de servicio registrado correctamente.");
        }

        [HttpPut("actualizar")]
        public IActionResult Put(int id, [FromBody] Detalle_servicio_venta data)
        {
            var ok = _service.Actualizar(id, data.id_venta, data.id_servicio, data.cantidad, data.precio_unitario, data.empleado_asignado, data.notas);
            if (!ok)
                return NotFound("Error al actualizar el detalle de servicio o no existe.");
            return Ok("Detalle de servicio actualizado correctamente.");
        }

        [HttpDelete("eliminar")]
        public IActionResult Delete(int id)
        {
            var ok = _service.Eliminar(id);
            if (!ok)
                return NotFound("Error al eliminar el detalle de servicio o no existe.");
            return Ok("Detalle de servicio eliminado correctamente.");
        }
    }
}
