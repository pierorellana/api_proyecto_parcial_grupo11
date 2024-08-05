using Microsoft.AspNetCore.Mvc;
using PROYECTO.Entidades;
using PROYECTO.Repositorio;

namespace pruebasproyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepositorio _categoriaRepositorio;

        public CategoriaController(ICategoriaRepositorio categoriaRepositorio)
        {
            _categoriaRepositorio = categoriaRepositorio;
        }

        [HttpPost]
        public async Task<IActionResult> CrearCategoria([FromBody] Categoria categoria)
        {
            if (categoria == null)
            {
                return BadRequest("Datos de la categoría no válidos.");
            }

            var categoriaId = await _categoriaRepositorio.Agregar(categoria);
            return Ok(new { CategoriaId = categoriaId });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerCategoriaPorId(int id)
        {
            var categoria = await _categoriaRepositorio.ConsultarPorCategoriaId(id);
            if (categoria == null || !categoria.Any())
            {
                return NotFound();
            }
            return Ok(categoria);
        }

        [HttpGet("nombre/{nombreCategoria}")]
        public async Task<IActionResult> ObtenerCategoriaPorNombre(string nombreCategoria)
        {
            var categorias = await _categoriaRepositorio.ConsultarPorNombrecategoria(nombreCategoria);
            if (categorias == null || !categorias.Any())
            {
                return NotFound();
            }
            return Ok(categorias);
        }


        [HttpGet("productos/nombre-producto/{nombreProducto}")]
        public async Task<IActionResult> ObtenerCategoriasPorNombreProducto(string nombreProducto)
        {
            var categorias = await _categoriaRepositorio.ConsultarCategoriasPorNombreProducto(nombreProducto);
            if (categorias == null || !categorias.Any())
            {
                return NotFound();
            }
            return Ok(categorias);
        }

        [HttpGet]
        public async Task<IActionResult> ListarCategorias()
        {
            var categorias = await _categoriaRepositorio.ListarTodas();
            return Ok(categorias);
        }

        [HttpPut]
        public async Task<IActionResult> EditarCategoria([FromBody] Categoria categoria)
        {
            if (categoria == null)
            {
                return BadRequest("Datos de la categoría no válidos.");
            }

            var resultado = await _categoriaRepositorio.Editar(categoria);
            if (resultado)
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarCategoria(int id)
        {
            var resultado = await _categoriaRepositorio.Eliminar(id);
            if (resultado)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
