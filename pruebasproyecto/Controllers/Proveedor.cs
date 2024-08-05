using Microsoft.AspNetCore.Mvc;
using PROYECTO.Entidades;
using PROYECTO.Repositorio;

namespace pruebasproyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedorController : Controller
    {
        private readonly IProveedorRepositorio _proveedorRepositorio;

        public ProveedorController(IProveedorRepositorio proveedorRepositorio)
        {
            _proveedorRepositorio = proveedorRepositorio;
        }

        [HttpPost]
        public IActionResult AgregarProveedor([FromBody] Proveedor proveedor)
        {
            try
            {
                // Asegúrate de que el proveedor tenga un UsuarioId válido
                if (proveedor.UsuarioId <= 0)
                {
                    return BadRequest("El campo UsuarioId es requerido y debe ser un valor válido.");
                }

                _proveedorRepositorio.AgregarProveedor(proveedor);
                return CreatedAtAction(nameof(ObtenerProveedorPorId), new { id = proveedor.ProveedorId }, proveedor);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }



        [HttpGet("{id}")]
        public IActionResult ObtenerProveedorPorId(int id)
        {
            var proveedor = _proveedorRepositorio.ObtenerProveedorPorId(id);
            if (proveedor == null)
            {
                return NotFound();
            }
            return Ok(proveedor);
        }

        [HttpGet]
        public IActionResult ObtenerTodosLosProveedores()
        {
            var proveedores = _proveedorRepositorio.ObtenerTodosLosProveedores();
            return Ok(proveedores);
        }

        [HttpGet("nombre/{nombre}")]
        public IActionResult ObtenerProveedoresPorNombre(string nombre)
        {
            var proveedores = _proveedorRepositorio.ObtenerProveedoresPorNombre(nombre);
            return Ok(proveedores);
        }

        [HttpGet("producto/{producto}")]
        public IActionResult ObtenerProveedoresPorProducto(string producto)
        {
            var proveedores = _proveedorRepositorio.ObtenerProveedoresPorProducto(producto);
            return Ok(proveedores);
        }

        [HttpGet("calidad/{calidad}")]
        public IActionResult ObtenerProveedoresPorCalidad(int calidad)
        {
            var proveedores = _proveedorRepositorio.ObtenerProveedoresPorCalidad(calidad);
            return Ok(proveedores);
        }

        [HttpPut("{id}")]
        public IActionResult ActualizarProveedor(int id, [FromBody] Proveedor proveedor)
        {
            var proveedorExistente = _proveedorRepositorio.ObtenerProveedorPorId(id);
            if (proveedorExistente == null)
            {
                return NotFound();
            }

            proveedor.ProveedorId = id;
            _proveedorRepositorio.ActualizarProveedor(proveedor);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarProveedor(int id)
        {
            var proveedorExistente = _proveedorRepositorio.ObtenerProveedorPorId(id);
            if (proveedorExistente == null)
            {
                return NotFound();
            }

            _proveedorRepositorio.EliminarProveedor(id);
            return NoContent();
        }
    }
}

