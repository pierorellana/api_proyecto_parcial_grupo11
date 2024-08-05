using Microsoft.AspNetCore.Mvc;
using PROYECTO.Entidades;
using PROYECTO.Repositorio;

namespace pruebasproyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitudSoporteController : ControllerBase
    {
        private readonly ISolicitudSoporteRepositorio _solicitudSoporteRepositorio;

        public SolicitudSoporteController(ISolicitudSoporteRepositorio solicitudSoporteRepositorio)
        {
            _solicitudSoporteRepositorio = solicitudSoporteRepositorio;
        }
        // Post: api/SolicitudSoporte
        [HttpPost]
        public async Task<IActionResult> CrearSolicitudSoporte([FromBody] SolicitudSoporte solicitudSoporte)
        {
            if (solicitudSoporte == null)
            {
                return BadRequest("Datos de la solicitud de soporte no válidos.");
            }

            var solicitudId = await _solicitudSoporteRepositorio.Agregar(solicitudSoporte);
            return Ok(new { SolicitudSoporteId = solicitudId });
        }
        
        // Put: api/SolicitudSoporte

        [HttpPut]
        public async Task<IActionResult> EditarSolicitudSoporte([FromBody] SolicitudSoporte solicitudSoporte)
        {
            if (solicitudSoporte == null)
            {
                return BadRequest("Datos de la solicitud de soporte no válidos.");
            }

            var resultado = await _solicitudSoporteRepositorio.Editar(solicitudSoporte);
            if (resultado)
            {
                return Ok();
            }
            return NotFound();
        }
        // Delete: api/SolicitudSoporte

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarSolicitudSoporte(int id)
        {
            var resultado = await _solicitudSoporteRepositorio.Eliminar(id);
            if (resultado)
            {
                return Ok();
            }
            return NotFound();
        }
        // GET: api/SolicitudSoporte/listar id

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerSolicitudSoportePorId(int id)
        {
            var solicitudSoporte = await _solicitudSoporteRepositorio.ConsultarSoportePorId(id);
            if (solicitudSoporte == null)
            {
                return NotFound();
            }
            return Ok(solicitudSoporte);
        }
        // GET: api/SolicitudSoporte/listar todas
        [HttpGet]
        public async Task<IActionResult> ListarSolicitudesSoporte()
        {
            var solicitudesSoporte = await _solicitudSoporteRepositorio.ListarTodas();
            return Ok(solicitudesSoporte);
        }
        // GET: api/SolicitudSoporte/BuscarPorNombre
        [HttpGet("BuscarPorNombre")]
        public async Task<ActionResult<IEnumerable<SolicitudSoporte>>> ConsultarPorNombre(string nombre)
        {
            var solicitudes = await _solicitudSoporteRepositorio.ConsultarPorNombre(nombre);
            return Ok(solicitudes);
        }

        // GET: api/SolicitudSoporte/BuscarPorApellido
        [HttpGet("BuscarPorApellido")]
        public async Task<ActionResult<IEnumerable<SolicitudSoporte>>> ConsultarPorApellido(string apellido)
        {
            var solicitudes = await _solicitudSoporteRepositorio.ConsultarPorApellido(apellido);
            return Ok(solicitudes);
        }

        // GET: api/SolicitudSoporte/BuscarPorGenero
        [HttpGet("BuscarPorGenero")]
        public async Task<ActionResult<IEnumerable<SolicitudSoporte>>> ConsultarPorGenero(string genero)
        {
            var solicitudes = await _solicitudSoporteRepositorio.ConsultarPorGenero(genero);
            return Ok(solicitudes);
        }
    }
}
