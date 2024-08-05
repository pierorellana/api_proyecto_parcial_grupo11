using PROYECTO.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO.Repositorio
{
    public class SolicitudRepositorio : ISolicitudRepositorio
    {
        private readonly ApplicationDbContext _context;

        public SolicitudRepositorio(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Solicitud?> ConsultarPorId(int id)
        {
            return await _context.SolicitudPedido
                                 .Include(s => s.Producto)
                                 .FirstOrDefaultAsync(s => s.SolicitudId == id);
        }

        public async Task<List<Solicitud>> ConsultarTodas()
        {
            return await _context.SolicitudPedido
                                 .Include(s => s.Producto)
                                 .ToListAsync();
        }

        public async Task<bool> Editar(Solicitud solicitud)
        {
            _context.SolicitudPedido.Update(solicitud);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Eliminar(int id)
        {
            var solicitud = await ConsultarPorId(id);
            if (solicitud == null) return false;

            _context.SolicitudPedido.Remove(solicitud);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<Solicitud>> ConsultarPorCliente(string nombreCliente)
        {
            return await _context.SolicitudPedido
                                 .Where(s => s.NombreCliente.Contains(nombreCliente))
                                 .Include(s => s.Producto)
                                 .ToListAsync();
        }

        public async Task<List<Solicitud>> ConsultarPorCiudad(string ciudad)
        {
            return await _context.SolicitudPedido
                                 .Where(s => s.Ciudad.Contains(ciudad))
                                 .Include(s => s.Producto)
                                 .ToListAsync();
        }

        public async Task<int> Agregar(Solicitud solicitud)
        {
            _context.SolicitudPedido.Add(solicitud);
            await _context.SaveChangesAsync();
            return solicitud.SolicitudId;
        }
    }
}
