using PROYECTO.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO.Repositorio
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly ApplicationDbContext _context;

        public ClienteRepositorio(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Agregar(Cliente cliente)
        {
            _context.Cliente.Add(cliente);
            await _context.SaveChangesAsync();
            return cliente.ClienteId;
        }

        public async Task<bool> Editar(Cliente cliente)
        {
            _context.Cliente.Update(cliente);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Eliminar(int id)
        {
            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente != null)
            {
                _context.Cliente.Remove(cliente);
                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<List<Cliente>> ListarTodos()
        {
            return await _context.Cliente.ToListAsync();
        }

        public async Task<Cliente> BuscarPorId(int id)
        {
            return await _context.Cliente.FindAsync(id);
        }

        public async Task<List<Cliente>> BuscarPorNombre(string nombre)
        {
            return await _context.Cliente
                .Where(c => c.Nombre.Contains(nombre))
                .ToListAsync();
        }

        public async Task<List<Cliente>> BuscarPorGenero(string genero)
        {
            return await _context.Cliente
                .Where(c => c.Genero == genero)
                .ToListAsync();
        }
        public async Task<List<Cliente>> BuscarPorApellido(string apellido)
        {
            return await _context.Cliente
                .Where(c => c.Apellido.Contains(apellido))
                .ToListAsync();
        }
    }
}