using PROYECTO.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO.Repositorio
{
    public class ProductoRepositorio : IProductoRepositorio
    {
        private readonly ApplicationDbContext _context;

        public ProductoRepositorio(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Agregar(Producto producto)
        {
            _context.Producto.Add(producto);
            await _context.SaveChangesAsync();
            return producto.ProductoId;
        }

        public async Task<bool> Editar(Producto producto)
        {
            var existingProducto = await _context.Producto.FindAsync(producto.ProductoId);
            if (existingProducto != null)
            {
                existingProducto.Nombre = producto.Nombre;
                existingProducto.Descripcion = producto.Descripcion;
                existingProducto.Precio = producto.Precio;
                existingProducto.Imagen = producto.Imagen;
                existingProducto.Stock = producto.Stock;
                existingProducto.CategoriaId = producto.CategoriaId;

                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> Eliminar(int id)
        {
            var producto = await _context.Producto.FindAsync(id);
            if (producto != null)
            {
                _context.Producto.Remove(producto);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<Producto>> ListarTodos()
        {
            return await _context.Producto.ToListAsync();
        }

        public async Task<Producto> ConsultarPorId(int id)
        {
            return await _context.Producto.FindAsync(id);
        }

        public async Task<List<Producto>> ConsultarPorNombre(string nombre)
        {
            return await _context.Producto
                .Where(p => p.Nombre.Contains(nombre))
                .ToListAsync();
        }

        public async Task<List<Producto>> ConsultarPorCategoriaNombre(string categoriaNombre)
        {
            return await _context.Producto
                .Include(p => p.Categoria)
                .Where(p => p.Categoria.Nombrecategoria.Contains(categoriaNombre))
                .ToListAsync();
        }
        public async Task<List<Producto>> ConsultarPorPrecio(decimal precio)
        {
            return await _context.Producto
                .Where(p => p.Precio == precio)
                .ToListAsync();
        }

        public async Task<List<Producto>> ConsultarPorStock(int stock)
        {
            return await _context.Producto
                .Where(p => p.Stock == stock)
                .ToListAsync();
        }
        public async Task<bool> CategoriaExiste(int categoriaId)
        {
            return await _context.Categoria.AnyAsync(c => c.CategoriaId == categoriaId);
        }
    }
}
