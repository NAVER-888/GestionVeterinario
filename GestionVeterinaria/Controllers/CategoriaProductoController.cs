using AccesoDatos.Models;
using AccesoDatos.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionVeterinaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaProductoController : ControllerBase
    {
        private readonly Categoria_productoService _service = new Categoria_productoService();

        [HttpGet]
        public ActionResult<List<Categoria_producto>> Get()
        {
            return _service.ObtenerTodas();
        }

        [HttpGet("{id}")]
        public ActionResult<Categoria_producto> Get(int id)
        {
            var categoria = _service.ObtenerPorId(id);
            if (categoria == null)
                return NotFound();

            return categoria;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Categoria_producto categoria)
        {
            var resultado = _service.Crear(categoria.nombre_categoria, categoria.descripcion);
            if (!resultado)
                return BadRequest("Error al crear la categoría.");

            return Ok("Categoría creada correctamente.");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Categoria_producto categoria)
        {
            var resultado = _service.Actualizar(id, categoria.nombre_categoria, categoria.descripcion);
            if (!resultado)
                return NotFound("Categoría no encontrada o error al actualizar.");

            return Ok("Categoría actualizada correctamente.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var resultado = _service.Eliminar(id);
            if (!resultado)
                return NotFound("Categoría no encontrada o error al eliminar.");

            return Ok("Categoría eliminada correctamente.");
        }
    }
}
