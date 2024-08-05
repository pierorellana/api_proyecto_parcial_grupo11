using Microsoft.AspNetCore.Mvc;
using PROYECTO.Entidades;
using PROYECTO.Repositorio;

namespace pruebasproyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoRepositorio _productoRepositorio;

        public ProductoController(IProductoRepositorio productoRepositorio)
        {
            _productoRepositorio = productoRepositorio;
        }

        [HttpPost]
        public async Task<IActionResult> CrearProducto([FromBody] Producto producto)
        {
            if (producto == null)
            {
                return BadRequest("Datos del producto no válidos.");
            }

            if (!await _productoRepositorio.CategoriaExiste(producto.CategoriaId))
            {
                return BadRequest("Categoría no existe.");
            }

            var productoId = await _productoRepositorio.Agregar(producto);
            return Ok(new { ProductoId = productoId });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerProductoPorId(int id)
        {
            var producto = await _productoRepositorio.ConsultarPorId(id);
            if (producto == null)
            {
                return NotFound();
            }
            return Ok(producto);
        }
        [HttpGet("nombre/{nombre}")]
        public async Task<IActionResult> ObtenerProductosPorNombre(string nombre)
        {
            var productos = await _productoRepositorio.ConsultarPorNombre(nombre);
            if (productos == null || !productos.Any())
            {
                return NotFound();
            }
            return Ok(productos);
        }

        [HttpGet("categoria/nombre/{nombre}")]
        public async Task<IActionResult> ObtenerProductosPorCategoriaNombre(string nombre)
        {
            var productos = await _productoRepositorio.ConsultarPorCategoriaNombre(nombre);
            if (productos == null || !productos.Any())
            {
                return NotFound();
            }
            return Ok(productos);
        }

        [HttpGet("precio/{precio}")]
        public async Task<IActionResult> ObtenerProductosPorPrecio(decimal precio)
        {
            var productos = await _productoRepositorio.ConsultarPorPrecio(precio);
            if (productos == null || !productos.Any())
            {
                return NotFound();
            }
            return Ok(productos);
        }

        [HttpGet("stock/{stock}")]
        public async Task<IActionResult> ObtenerProductosPorStock(int stock)
        {
            var productos = await _productoRepositorio.ConsultarPorStock(stock);
            if (productos == null || !productos.Any())
            {
                return NotFound();
            }
            return Ok(productos);
        }

        [HttpGet]
        public async Task<IActionResult> ListarProductos()
        {
            var productos = await _productoRepositorio.ListarTodos();
            return Ok(productos);
        }

        [HttpPut]
        public async Task<IActionResult> EditarProducto([FromBody] Producto producto)
        {
            if (producto == null)
            {
                return BadRequest("Datos del producto no válidos.");
            }

            var resultado = await _productoRepositorio.Editar(producto);
            if (resultado)
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarProducto(int id)
        {
            var resultado = await _productoRepositorio.Eliminar(id);
            if (resultado)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
