using AccesoDatos.Models;
using AccesoDatos.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionVeterinaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly VentaService _service = new VentaService();

        [HttpGet("lista")]
        public ActionResult<List<Venta>> Get()
        {
            return _service.ObtenerTodas();
        }

        [HttpGet("buscar")]
        public ActionResult<Venta> Get(int id)
        {
            var venta = _service.ObtenerPorId(id);
            if (venta == null)
                return NotFound("Venta no encontrada.");
            return Ok(venta);
        }

        [HttpPost("insertar")]
        public IActionResult Post([FromBody] Venta data)
        {
            var ok = _service.Crear(data.fecha_hora_venta, data.id_cliente, data.id_usuario, data.total_venta, data.forma_pago, data.notas);
            if (!ok)
                return BadRequest("Error al registrar la venta.");
            return Ok("Venta registrada correctamente.");
        }

        [HttpPut("actualizar")]
        public IActionResult Put(int id, [FromBody] Venta data)
        {
            var ok = _service.Actualizar(id, data.fecha_hora_venta ?? DateTime.Now, data.id_cliente, data.id_usuario, data.total_venta, data.forma_pago, data.notas);
            if (!ok)
                return NotFound("Error al actualizar la venta o no existe.");
            return Ok("Venta actualizada correctamente.");
        }

        [HttpDelete("eliminar")]
        public IActionResult Delete(int id)
        {
            var ok = _service.Eliminar(id);
            if (!ok)
                return NotFound("Error al eliminar la venta o no existe.");
            return Ok("Venta eliminada correctamente.");
        }
    }
}
