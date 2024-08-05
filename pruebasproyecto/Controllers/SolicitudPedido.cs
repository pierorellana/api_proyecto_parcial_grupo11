using Microsoft.AspNetCore.Mvc;
using PROYECTO.Entidades;
using PROYECTO.Repositorio;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace pruebasproyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitudPedidoController : ControllerBase
    {
        private readonly ISolicitudRepositorio _solicitudRepositorio;

        public SolicitudPedidoController(ISolicitudRepositorio solicitudRepositorio)
        {
            _solicitudRepositorio = solicitudRepositorio;
        }

        [HttpPost]
        public async Task<IActionResult> CrearSolicitud([FromBody] Solicitud solicitud)
        {
            if (solicitud == null)
            {
                return BadRequest("Datos de la solicitud no válidos.");
            }

            bool camposPaypalLlenos = !string.IsNullOrEmpty(solicitud.CorreoPaypal);
            bool camposTarjetaLlenos = !string.IsNullOrEmpty(solicitud.NombreTarjeta) ||
                                       !string.IsNullOrEmpty(solicitud.NumeroTarjeta) ||
                                       !string.IsNullOrEmpty(solicitud.ExpiracionTarjeta) ||
                                       !string.IsNullOrEmpty(solicitud.CvcTarjeta);

            if (camposPaypalLlenos && camposTarjetaLlenos)
            {
                return BadRequest("No se pueden llenar los campos de PayPal y tarjeta de crédito simultáneamente.");
            }

            if (!camposPaypalLlenos && !camposTarjetaLlenos)
            {
                return BadRequest("Debe llenar los campos de PayPal o los de tarjeta de crédito.");
            }

            var solicitudId = await _solicitudRepositorio.Agregar(solicitud);
            return CreatedAtAction(nameof(ObtenerSolicitudPorId), new { id = solicitudId }, new { SolicitudId = solicitudId });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerSolicitudPorId(int id)
        {
            var solicitud = await _solicitudRepositorio.ConsultarPorId(id);
            if (solicitud == null)
            {
                return NotFound();
            }
            return Ok(solicitud);
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodasLasSolicitudes()
        {
            var solicitudes = await _solicitudRepositorio.ConsultarTodas();
            return Ok(solicitudes);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditarSolicitud(int id, [FromBody] Solicitud solicitud)
        {
            if (solicitud == null || solicitud.SolicitudId != id)
            {
                return BadRequest("Datos de la solicitud no válidos.");
            }

            var resultado = await _solicitudRepositorio.Editar(solicitud);
            if (resultado)
            {
                return NoContent();
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarSolicitud(int id)
        {
            var resultado = await _solicitudRepositorio.Eliminar(id);
            if (resultado)
            {
                return NoContent();
            }
            return NotFound();
        }

        [HttpGet("cliente/{nombreCliente}")]
        public async Task<IActionResult> ConsultarPorCliente(string nombreCliente)
        {
            var solicitudes = await _solicitudRepositorio.ConsultarPorCliente(nombreCliente);
            return Ok(solicitudes);
        }

        [HttpGet("ciudad/{ciudad}")]
        public async Task<IActionResult> ConsultarPorCiudad(string ciudad)
        {
            var solicitudes = await _solicitudRepositorio.ConsultarPorCiudad(ciudad);
            return Ok(solicitudes);
        }
    }
}
