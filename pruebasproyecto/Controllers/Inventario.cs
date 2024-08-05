using Microsoft.AspNetCore.Mvc;
using PROYECTO.Entidades;
using PROYECTO.Repositorio;

namespace pruebasproyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventarioController : Controller
    {
        private readonly IInventarioRepositorio _inventarioRepositorio;

        public InventarioController(IInventarioRepositorio inventarioRepositorio)
        {
            _inventarioRepositorio = inventarioRepositorio;
        }

        // GET: api/Inventario
        [HttpGet]
        public ActionResult<IEnumerable<Inventario>> GetInventarios()
        {
            var inventarios = _inventarioRepositorio.ObtenerTodoElInventario();
            return Ok(inventarios);
        }

        // GET: api/Inventario/{id}
        [HttpGet("{id}")]
        public ActionResult<Inventario> GetInventario(int id)
        {
            var inventario = _inventarioRepositorio.ObtenerInventarioPorId(id);

            if (inventario == null)
            {
                return NotFound();
            }

            return Ok(inventario);
        }
        // GET: api/Inventario/PorStock/{stock}
        [HttpGet("PorStock/{stock}")]
        public ActionResult<IEnumerable<Inventario>> GetInventariosPorStock(int stock)
        {
            var inventarios = _inventarioRepositorio.ObtenerInventarioPorStock(stock);
            return Ok(inventarios);
        }

        // GET: api/Inventario/PorProveedor/{nombreProveedor}
        [HttpGet("PorProveedor/{nombreProveedor}")]
        public ActionResult<IEnumerable<Inventario>> GetInventariosPorNombreProveedor(string nombreProveedor)
        {
            var inventarios = _inventarioRepositorio.ObtenerInventarioPorNombreProveedor(nombreProveedor);
            return Ok(inventarios);
        }

        // POST: api/Inventario
        [HttpPost]
        public ActionResult<Inventario> PostInventario([FromBody] Inventario inventario)
        {
            try
            {
                _inventarioRepositorio.AgregarInventario(inventario);
                return CreatedAtAction(nameof(GetInventario), new { id = inventario.InventarioId }, inventario);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // PUT: api/Inventario/{id}
        [HttpPut("{id}")]
        public IActionResult PutInventario(int id, [FromBody] Inventario inventario)
        {
            if (id != inventario.InventarioId)
            {
                return BadRequest();
            }

            var inventarioExistente = _inventarioRepositorio.ObtenerInventarioPorId(id);

            if (inventarioExistente == null)
            {
                return NotFound();
            }

            try
            {
                var producto = _inventarioRepositorio.ObtenerProductoPorId(inventario.ProductoId); // Añadir este método en el repositorio
                var proveedor = _inventarioRepositorio.ObtenerProveedorPorId(inventario.ProveedorId); // Añadir este método en el repositorio

                if (producto == null || proveedor == null)
                {
                    return BadRequest(new { message = "Producto o Proveedor no encontrado." });
                }

                // Actualizar los valores de stock y precio si se ha cambiado el ProductoId
                inventarioExistente.ProductoId = inventario.ProductoId;
                inventarioExistente.Stock = producto.Stock;
                inventarioExistente.Precio = producto.Precio;
                inventarioExistente.ProveedorId = inventario.ProveedorId;
                inventarioExistente.Producto = producto;
                inventarioExistente.Proveedor = proveedor;

                _inventarioRepositorio.ActualizarInventario(inventarioExistente);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }



        // DELETE: api/Inventario/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteInventario(int id)
        {
            try
            {
                _inventarioRepositorio.EliminarInventario(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
 

    }
}
