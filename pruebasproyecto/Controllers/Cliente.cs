using Microsoft.AspNetCore.Mvc;
using PROYECTO.Entidades;
using PROYECTO.Repositorio;

namespace pruebasproyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepositorio _clienteRepositorio;

        public ClienteController(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }

        // Post: api/Cliente
        [HttpPost]
        public async Task<IActionResult> CrearCliente([FromBody] Cliente cliente)
        {
            if (cliente == null)
            {
                return BadRequest("Datos del cliente no válidos.");
            }

            var clienteId = await _clienteRepositorio.Agregar(cliente);
            return Ok(new { ClienteId = clienteId });
        }

        // Put: api/Cliente
        [HttpPut]
        public async Task<IActionResult> EditarCliente([FromBody] Cliente cliente)
        {
            if (cliente == null)
            {
                return BadRequest("Datos del cliente no válidos.");
            }

            var resultado = await _clienteRepositorio.Editar(cliente);
            if (resultado)
            {
                return Ok();
            }
            return NotFound();
        }

        // Delete: api/Cliente
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarCliente(int id)
        {
            var resultado = await _clienteRepositorio.Eliminar(id);
            if (resultado)
            {
                return Ok();
            }
            return NotFound();
        }

        // GET: api/Cliente/id
        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerClientePorId(int id)
        {
            var cliente = await _clienteRepositorio.BuscarPorId(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }

        // GET: api/Cliente/listastodas
        [HttpGet]
        public async Task<IActionResult> ListarClientes()
        {
            var clientes = await _clienteRepositorio.ListarTodos();
            return Ok(clientes);
        }

        // GET: api/Cliente/nombre
        [HttpGet("nombre/{nombre}")]
        public async Task<IActionResult> BuscarClientesPorNombre(string nombre)
        {
            var clientes = await _clienteRepositorio.BuscarPorNombre(nombre);
            if (clientes == null || !clientes.Any())
            {
                return NotFound();
            }
            return Ok(clientes);
        }

        // GET: api/Cliente/genero
        [HttpGet("genero/{genero}")]
        public async Task<IActionResult> BuscarClientesPorGenero(string genero)
        {
            var clientes = await _clienteRepositorio.BuscarPorGenero(genero);
            if (clientes == null || !clientes.Any())
            {
                return NotFound();
            }
            return Ok(clientes);
        }

        // GET: api/Cliente/apellido
        [HttpGet("apellido/{apellido}")]
        public async Task<IActionResult> BuscarClientesPorApellido(string apellido)
        {
            var clientes = await _clienteRepositorio.BuscarPorApellido(apellido);
            if (clientes == null || !clientes.Any())
            {
                return NotFound();
            }
            return Ok(clientes);
        }
    }
}
