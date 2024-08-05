using PROYECTO.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO.Repositorio
{
    public class RolRepositorio : IRolRepositorio
    {
        private readonly ApplicationDbContext _context;

        public RolRepositorio(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Rol> ObtenerPorId(int id)
        {
            return await _context.Rol
                .Include(r => r.Usuarios)
                .FirstOrDefaultAsync(r => r.RolId == id);
        }

        public async Task<IEnumerable<Rol>> ObtenerTodos()
        {
            return await _context.Rol
                .Include(r => r.Usuarios)
                .ToListAsync();
        }

        public async Task Crear(Rol rol)
        {
            _context.Rol.Add(rol);
            await _context.SaveChangesAsync();
        }

        public async Task Actualizar(Rol rol)
        {
            var rolExistente = await ObtenerPorId(rol.RolId);
            if (rolExistente != null)
            {
                // Actualiza las propiedades del rol existente
                rolExistente.NombreRol = rol.NombreRol;
                rolExistente.Usuarios = rol.Usuarios;

                // Marca la entidad como modificada
                _context.Rol.Update(rolExistente);
                await _context.SaveChangesAsync();
            }
        }

        public async Task Eliminar(int id)
        {
            var rol = await ObtenerPorId(id);
            if (rol != null)
            {
                _context.Rol.Remove(rol);
                await _context.SaveChangesAsync();
            }
        }
    }
}
