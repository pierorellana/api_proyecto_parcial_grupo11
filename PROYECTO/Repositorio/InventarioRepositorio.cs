using PROYECTO.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO.Repositorio
{
    public class InventarioRepositorio : IInventarioRepositorio
    {
        private readonly ApplicationDbContext _context;

        public InventarioRepositorio(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AgregarInventario(Inventario inventario)
        {
            // Validar si el producto y proveedor existen antes de agregar
            var producto = _context.Producto.Find(inventario.ProductoId);
            var proveedor = _context.Proveedores.Find(inventario.ProveedorId);

            if (producto != null && proveedor != null)
            {
                // Asignar el stock y precio del producto al inventario
                inventario.Stock = producto.Stock;
                inventario.Precio = producto.Precio;
                inventario.Producto = producto;
                inventario.Proveedor = proveedor;

                _context.Inventario.Add(inventario);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Producto o Proveedor no encontrado.");
            }
        }

        public Inventario ObtenerInventarioPorId(int id)
        {
            return _context.Inventario
                .Include(i => i.Producto)
                .Include(i => i.Proveedor)
                .FirstOrDefault(i => i.InventarioId == id);
        }

        public List<Inventario> ObtenerTodoElInventario()
        {
            return _context.Inventario
                .Include(i => i.Producto)
                .Include(i => i.Proveedor)
                .ToList();
        }

        public void ActualizarInventario(Inventario inventario)
        {
            var inventarioExistente = _context.Inventario.Find(inventario.InventarioId);

            if (inventarioExistente != null)
            {
                var producto = _context.Producto.Find(inventario.ProductoId);
                var proveedor = _context.Proveedores.Find(inventario.ProveedorId);

                if (producto == null || proveedor == null)
                {
                    throw new Exception("Producto o Proveedor no encontrado.");
                }

                inventarioExistente.ProductoId = inventario.ProductoId;
                inventarioExistente.Stock = producto.Stock;
                inventarioExistente.Precio = producto.Precio;
                inventarioExistente.ProveedorId = inventario.ProveedorId;
                inventarioExistente.Producto = producto;
                inventarioExistente.Proveedor = proveedor;

                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Inventario no encontrado.");
            }
        }



        public void EliminarInventario(int id)
        {
            var inventario = _context.Inventario.Find(id);

            if (inventario != null)
            {
                _context.Inventario.Remove(inventario);
                _context.SaveChanges();
            }
        }
        public Producto ObtenerProductoPorId(int productoId)
        {
            return _context.Producto.Find(productoId);
        }

        public Proveedor ObtenerProveedorPorId(int proveedorId)
        {
            return _context.Proveedores.Find(proveedorId);
        }
        public List<Inventario> ObtenerInventarioPorStock(int stock)
        {
            return _context.Inventario
                .Include(i => i.Producto)
                .Include(i => i.Proveedor)
                .Where(i => i.Stock == stock)
                .ToList();
        }

        public List<Inventario> ObtenerInventarioPorNombreProveedor(string nombreProveedor)
        {
            return _context.Inventario
                .Include(i => i.Producto)
                .Include(i => i.Proveedor)
                .Where(i => i.Proveedor.Nombre.Contains(nombreProveedor))
                .ToList();
        }
    }
}
