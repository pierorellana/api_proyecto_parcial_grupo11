using PROYECTO.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO.Repositorio
{
    public class OrdenRepositorio : IOrdenRepositorio
    {
        private readonly ApplicationDbContext _context;

        public OrdenRepositorio(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Agregar(Orden orden)
        {
            _context.Orden.Add(orden);
            await _context.SaveChangesAsync();
            return orden.OrdenId;
        }

        public async Task<Orden?> ConsultarPorId(int id)
        {
            return await _context.Orden
                .Include(o => o.Solicitud)
                .ThenInclude(od => od.Producto)
                .FirstOrDefaultAsync(o => o.OrdenId == id);
        }

        public async Task<List<Orden>> ConsultarTodas()
        {
            return await _context.Orden
                .Include(o => o.Solicitud)
                .ThenInclude(od => od.Producto)
                .ToListAsync();
        }

        public async Task<bool> Editar(Orden orden)
        {
            var existingOrden = await _context.Orden.FindAsync(orden.OrdenId);
            if (existingOrden == null) return false;

            _context.Entry(existingOrden).CurrentValues.SetValues(orden);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var orden = await _context.Orden.FindAsync(id);
            if (orden == null) return false;

            _context.Orden.Remove(orden);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Orden>> ConsultarPorCliente(string nombreCliente)
        {
            return await _context.Orden
                .Include(o => o.Solicitud)
                .Where(o => o.Solicitud.NombreCliente.Contains(nombreCliente))
                .ToListAsync();
        }
    }
}