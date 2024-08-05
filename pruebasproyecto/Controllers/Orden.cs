using Microsoft.AspNetCore.Mvc;
using PROYECTO.Entidades;
using PROYECTO.Repositorio;

namespace pruebasproyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenController : ControllerBase
    {
        private readonly IOrdenRepositorio _ordenRepositorio;

        public OrdenController(IOrdenRepositorio ordenRepositorio)
        {
            _ordenRepositorio = ordenRepositorio;
        }

        [HttpPost]
        public async Task<IActionResult> CrearOrden([FromBody] Orden orden)
        {
            if (orden == null)
            {
                return BadRequest("Datos de la orden no válidos.");
            }

            var ordenId = await _ordenRepositorio.Agregar(orden);
            return CreatedAtAction(nameof(ObtenerOrdenPorId), new { id = ordenId }, new { OrdenId = ordenId });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerOrdenPorId(int id)
        {
            var orden = await _ordenRepositorio.ConsultarPorId(id);
            if (orden == null)
            {
                return NotFound();
            }
            return Ok(orden);
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodasLasOrdenes()
        {
            var ordenes = await _ordenRepositorio.ConsultarTodas();
            return Ok(ordenes);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditarOrden(int id, [FromBody] Orden orden)
        {
            if (orden == null || orden.OrdenId != id)
            {
                return BadRequest("Datos de la orden no válidos.");
            }

            var resultado = await _ordenRepositorio.Editar(orden);
            if (resultado)
            {
                return NoContent();
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarOrden(int id)
        {
            var resultado = await _ordenRepositorio.Eliminar(id);
            if (resultado)
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}