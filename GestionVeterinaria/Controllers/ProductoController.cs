using AccesoDatos.Models;
using AccesoDatos.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionVeterinaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly ProductoService _service = new ProductoService();

        [HttpGet]
        public ActionResult<List<Producto>> Get()
        {
            return _service.ObtenerTodos();
        }

        [HttpGet("{id}")]
        public ActionResult<Producto> Get(int id)
        {
            var producto = _service.ObtenerPorId(id);
            if (producto == null)
                return NotFound();

            return producto;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Producto producto)
        {
            var resultado = _service.Crear(
                producto.nombre_producto,
                producto.id_categoria,
                producto.descripcion,
                producto.precio_unitario,
                producto.cantidad_en_stock
            );

            if (!resultado)
                return BadRequest("Error al crear el producto.");

            return Ok("Producto creado correctamente.");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Producto producto)
        {
            var resultado = _service.Actualizar(
                id,
                producto.nombre_producto,
                producto.id_categoria,
                producto.descripcion,
                producto.precio_unitario,
                producto.cantidad_en_stock
            );

            if (!resultado)
                return NotFound("Producto no encontrado o error al actualizar.");

            return Ok("Producto actualizado correctamente.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var resultado = _service.Eliminar(id);
            if (!resultado)
                return NotFound("Producto no encontrado o error al eliminar.");

            return Ok("Producto eliminado correctamente.");
        }
    }
}
