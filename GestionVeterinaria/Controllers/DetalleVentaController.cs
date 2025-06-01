using AccesoDatos.Models;
using AccesoDatos.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionVeterinaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleVentaController : ControllerBase
    {
        private readonly Detalle_ventaService _service = new Detalle_ventaService();

        [HttpGet("lista")]
        public ActionResult<List<Detalle_venta>> Get()
        {
            return _service.ObtenerTodos();
        }

        [HttpGet("buscar")]
        public ActionResult<Detalle_venta> Get(int id)
        {
            var detalle = _service.ObtenerPorId(id);
            if (detalle == null)
                return NotFound("Detalle de venta no encontrado.");
            return Ok(detalle);
        }

        [HttpPost("insertar")]
        public IActionResult Post([FromBody] Detalle_venta data)
        {
            var ok = _service.Crear(data.id_venta, data.id_producto, data.cantidad, data.precio_unitario);
            if (!ok)
                return BadRequest("Error al registrar el detalle de venta.");
            return Ok("Detalle de venta registrado correctamente.");
        }

        [HttpPut("actualizar")]
        public IActionResult Put(int id, [FromBody] Detalle_venta data)
        {
            var ok = _service.Actualizar(id, data.id_venta, data.id_producto, data.cantidad, data.precio_unitario);
            if (!ok)
                return NotFound("Error al actualizar el detalle de venta o no existe.");
            return Ok("Detalle de venta actualizado correctamente.");
        }

        [HttpDelete("eliminar")]
        public IActionResult Delete(int id)
        {
            var ok = _service.Eliminar(id);
            if (!ok)
                return NotFound("Error al eliminar el detalle de venta o no existe.");
            return Ok("Detalle de venta eliminado correctamente.");
        }
    }
}
