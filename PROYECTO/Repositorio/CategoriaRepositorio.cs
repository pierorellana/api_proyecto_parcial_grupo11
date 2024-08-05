using PROYECTO.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO.Repositorio
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        private readonly ApplicationDbContext _context;

        public CategoriaRepositorio(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Agregar(Categoria categoria)
        {
            _context.Categoria.Add(categoria);
            await _context.SaveChangesAsync();
            return categoria.CategoriaId;
        }

        public async Task<bool> Editar(Categoria categoria)
        {
            var existingCategoria = await _context.Categoria.FindAsync(categoria.CategoriaId);
            if (existingCategoria != null)
            {
                existingCategoria.Nombrecategoria = categoria.Nombrecategoria;
                existingCategoria.Productos = categoria.Productos;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> Eliminar(int id)
        {
            var categoria = await _context.Categoria.FindAsync(id);
            if (categoria != null)
            {
                _context.Categoria.Remove(categoria);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<Categoria>> ListarTodas()
        {
            return await _context.Categoria.Include(c => c.Productos).ToListAsync();
        }

        public async Task<List<Categoria>> ConsultarPorCategoriaId(int categoriaId)
        {
            return await _context.Categoria
                .Include(c => c.Productos)
                .Where(c => c.CategoriaId == categoriaId)
                .ToListAsync();
        }

        public async Task<List<Categoria>> ConsultarPorNombrecategoria(string nombreCategoria)
        {
            return await _context.Categoria
                .Include(c => c.Productos)
                .Where(c => c.Nombrecategoria == nombreCategoria)
                .ToListAsync();
        }
        public async Task<List<Categoria>> ConsultarCategoriasPorNombreProducto(string nombreProducto)
        {
            return await _context.Categoria
                .Include(c => c.Productos)
                .Where(c => c.Productos.Any(p => p.Nombre.Contains(nombreProducto)))
                .ToListAsync();
        }


    }
}
