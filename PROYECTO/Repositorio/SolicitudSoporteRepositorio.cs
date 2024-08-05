using PROYECTO.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO.Repositorio
{
    public class SolicitudSoporteRepositorio : ISolicitudSoporteRepositorio
    {
        private readonly ApplicationDbContext _context;

        public SolicitudSoporteRepositorio(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Agregar(SolicitudSoporte solicitudSoporte)
        {
            _context.SolicitudSoportes.Add(solicitudSoporte);
            await _context.SaveChangesAsync();
            return solicitudSoporte.SolicitudSoporteId;
        }

        public async Task<bool> Editar(SolicitudSoporte solicitudSoporte)
        {
            _context.SolicitudSoportes.Update(solicitudSoporte);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Eliminar(int id)
        {
            var solicitud = await _context.SolicitudSoportes.FindAsync(id);
            if (solicitud != null)
            {
                _context.SolicitudSoportes.Remove(solicitud);
                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<List<SolicitudSoporte>> ListarTodas()
        {
            return await _context.SolicitudSoportes.ToListAsync();
        }

        public async Task<SolicitudSoporte> ConsultarSoportePorId(int solicitudSoporteId)
        {
            return await _context.SolicitudSoportes.FindAsync(solicitudSoporteId);
        }
        public async Task<List<SolicitudSoporte>> ConsultarPorNombre(string nombre)
        {
            return await _context.SolicitudSoportes
                .Where(s => s.Nombre.Contains(nombre))
                .ToListAsync();
        }

        public async Task<List<SolicitudSoporte>> ConsultarPorApellido(string apellido)
        {
            return await _context.SolicitudSoportes
                .Where(s => s.Apellido.Contains(apellido))
                .ToListAsync();
        }

        public async Task<List<SolicitudSoporte>> ConsultarPorGenero(string genero)
        {
            return await _context.SolicitudSoportes
                .Where(s => s.Genero.Contains(genero))
                .ToListAsync();
        }

    }
}