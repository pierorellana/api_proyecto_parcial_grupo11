using Microsoft.AspNetCore.Mvc;
using PROYECTO.Repositorio;
using PROYECTO.Entidades;

namespace pruebasproyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly IRolRepositorio _rolRepositorio;

        public RolController(IRolRepositorio rolRepositorio)
        {
            _rolRepositorio = rolRepositorio;
        }

        // GET: api/Rol
        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var roles = await _rolRepositorio.ObtenerTodos();
            return Ok(roles);
        }

        // GET: api/Rol/5
        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var rol = await _rolRepositorio.ObtenerPorId(id);
            if (rol == null)
            {
                return NotFound();
            }
            return Ok(rol);
        }

        // POST: api/Rol
        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] Rol rol)
        {
            if (rol == null)
            {
                return BadRequest();
            }

            await _rolRepositorio.Crear(rol);
            return CreatedAtAction(nameof(ObtenerPorId), new { id = rol.RolId }, rol);
        }

        // PUT: api/Rol/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] Rol rol)
        {
            if (rol == null || rol.RolId != id)
            {
                return BadRequest();
            }

            var rolExistente = await _rolRepositorio.ObtenerPorId(id);
            if (rolExistente == null)
            {
                return NotFound();
            }

            // Asigna los nuevos valores al rol existente
            rolExistente.NombreRol = rol.NombreRol;
            rolExistente.Usuarios = rol.Usuarios;

            await _rolRepositorio.Actualizar(rolExistente);
            return NoContent();
        }


        // DELETE: api/Rol/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var rolExistente = await _rolRepositorio.ObtenerPorId(id);
            if (rolExistente == null)
            {
                return NotFound();
            }

            await _rolRepositorio.Eliminar(id);
            return NoContent();
        }
    }
}