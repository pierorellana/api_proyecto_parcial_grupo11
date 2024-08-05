using PROYECTO.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly ApplicationDbContext _context;

        public UsuarioRepositorio(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> ObtenerPorId(int id)
        {
            return await _context.Usuarios
                .Include(u => u.Rol)
                .FirstOrDefaultAsync(u => u.UsuarioId == id);
        }

        public async Task<IEnumerable<Usuario>> ObtenerTodos()
        {
            return await _context.Usuarios
                .Include(u => u.Rol)
                .Select(u => new Usuario
                {
                    UsuarioId = u.UsuarioId,
                    NombreUsuario = u.NombreUsuario,
                    Apellido = u.Apellido,
                    Correo = u.Correo,
                    RolId = u.RolId,
                    Rol = new Rol
                    {
                        RolId = u.Rol.RolId,
                        NombreRol = u.Rol.NombreRol
                    }
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<Usuario>> ObtenerPorNombreUsuario(string nombreUsuario)
        {
            return await _context.Usuarios
                .Where(u => u.NombreUsuario.Contains(nombreUsuario))
                .Include(u => u.Rol)
                .ToListAsync();
        }
        public async Task<IEnumerable<Usuario>> ObtenerPorApellido(string apellido)
        {
            return await _context.Usuarios
                .Where(u => u.Apellido.Contains(apellido))
                .Include(u => u.Rol)
                .ToListAsync();
        }

        public async Task<IEnumerable<Usuario>> ObtenerPorCorreo(string correo)
        {
            return await _context.Usuarios
                .Where(u => u.Correo.Contains(correo))
                .Include(u => u.Rol)
                .ToListAsync();
        }

        public async Task Crear(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task Actualizar(Usuario usuario)
        {
            var usuarioExistente = await ObtenerPorId(usuario.UsuarioId);
            if (usuarioExistente != null)
            {
                // Actualiza las propiedades del usuario existente
                usuarioExistente.NombreUsuario = usuario.NombreUsuario;
                usuarioExistente.Apellido = usuario.Apellido;
                usuarioExistente.Correo = usuario.Correo;
                usuarioExistente.Contraseña = usuario.Contraseña;
                usuarioExistente.RolId = usuario.RolId;

                // Marca la entidad como modificada
                _context.Usuarios.Update(usuarioExistente);
                await _context.SaveChangesAsync();
            }
        }

        public async Task Eliminar(int id)
        {
            var usuario = await ObtenerPorId(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();
            }
        }
    }
}