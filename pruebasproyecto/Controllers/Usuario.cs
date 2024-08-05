using Microsoft.AspNetCore.Mvc;
using PROYECTO.Entidades;
using PROYECTO.Repositorio;

namespace pruebasproyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        // GET: api/Usuario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> ObtenerTodos()
        {
            var usuarios = await _usuarioRepositorio.ObtenerTodos();
            return Ok(usuarios);
        }

        // GET: api/Usuario/id
        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var usuario = await _usuarioRepositorio.ObtenerPorId(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        // GET: api/Usuario/BuscarPorNombreUsuario
        [HttpGet("BuscarPorNombreUsuario")]
        public async Task<ActionResult<IEnumerable<Usuario>>> ObtenerPorNombreUsuario(string nombreUsuario)
        {
            var usuarios = await _usuarioRepositorio.ObtenerPorNombreUsuario(nombreUsuario);
            return Ok(usuarios);
        }

        // GET: api/Usuario/BuscarPorCorreo
        [HttpGet("BuscarPorCorreo")]
        public async Task<ActionResult<IEnumerable<Usuario>>> ObtenerPorCorreo(string correo)
        {
            var usuarios = await _usuarioRepositorio.ObtenerPorCorreo(correo);
            return Ok(usuarios);
        }
        
        // GET: api/Usuario/BuscarPorApellido
        [HttpGet("BuscarPorApellido")]
        public async Task<ActionResult<IEnumerable<Usuario>>> ObtenerPorApellido(string apellido)
        {
            var usuarios = await _usuarioRepositorio.ObtenerPorApellido(apellido);
            return Ok(usuarios);
        }

        // POST: api/Usuario
        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] Usuario usuario)
        {
            if (usuario == null)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _usuarioRepositorio.Crear(usuario);
                return CreatedAtAction(nameof(ObtenerPorId), new { id = usuario.UsuarioId }, usuario);
            }

            return BadRequest(ModelState);
        }

        // PUT: api/Usuario/
        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] Usuario usuario)
        {
            if (usuario == null || usuario.UsuarioId != id)
            {
                return BadRequest();
            }

            var usuarioExistente = await _usuarioRepositorio.ObtenerPorId(id);
            if (usuarioExistente == null)
            {
                return NotFound();
            }

            usuarioExistente.NombreUsuario = usuario.NombreUsuario;
            usuarioExistente.Apellido = usuario.Apellido;
            usuarioExistente.Correo = usuario.Correo;
            usuarioExistente.Contraseña = usuario.Contraseña;
            usuarioExistente.RolId = usuario.RolId;

            await _usuarioRepositorio.Actualizar(usuarioExistente);
            return NoContent();
        }

        // DELETE: api/Usuario/
        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var usuarioExistente = await _usuarioRepositorio.ObtenerPorId(id);
            if (usuarioExistente == null)
            {
                return NotFound();
            }

            await _usuarioRepositorio.Eliminar(id);
            return NoContent();
        }
    }
}
