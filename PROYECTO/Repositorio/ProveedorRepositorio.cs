using Microsoft.EntityFrameworkCore;
using PROYECTO.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO.Repositorio
{
    public class ProveedorRepositorio : IProveedorRepositorio
    {
        private readonly ApplicationDbContext _context;

        public ProveedorRepositorio(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AgregarProveedor(Proveedor proveedor)
        {
            // Verificar que el UsuarioId exista en la base de datos
            var usuario = _context.Usuarios.Find(proveedor.UsuarioId);
            if (usuario == null)
            {
                throw new Exception("Usuario no encontrado");
            }

            // Asignar el usuario al proveedor
            proveedor.Usuario = usuario;

            // Agregar el proveedor
            _context.Proveedores.Add(proveedor);
            _context.SaveChanges();
        }



        public Proveedor ObtenerProveedorPorId(int id)
        {
            return _context.Proveedores.FirstOrDefault(p => p.ProveedorId == id);
        }

        public List<Proveedor> ObtenerTodosLosProveedores()
        {
            return _context.Proveedores.ToList();
        }

        public List<Proveedor> ObtenerProveedoresPorNombre(string nombre)
        {
            return _context.Proveedores
                           .AsEnumerable() // Cargar los datos en memoria
                           .Where(p => p.Nombre.Contains(nombre, StringComparison.OrdinalIgnoreCase))
                           .ToList();
        }


        public List<Proveedor> ObtenerProveedoresPorProducto(string producto)
        {
            {
                // Usa '%' para los comodines del operador LIKE
                string searchPattern = $"%{producto}%";

                return _context.Proveedores
                               .Where(p => EF.Functions.Like(p.Porductos, searchPattern))
                               .ToList();
            }

        }

        public List<Proveedor> ObtenerProveedoresPorCalidad(int calidad)
        {
            return _context.Proveedores
                           .Where(p => p.Calidad == calidad)
                           .ToList();
        }

        public void ActualizarProveedor(Proveedor proveedor)
        {
            var proveedorExistente = _context.Proveedores.FirstOrDefault(p => p.ProveedorId == proveedor.ProveedorId);
            if (proveedorExistente != null)
            {
                proveedorExistente.Nombre = proveedor.Nombre;
                proveedorExistente.Email = proveedor.Email;
                proveedorExistente.Telefono = proveedor.Telefono;
                proveedorExistente.Direccion = proveedor.Direccion;
                proveedorExistente.Porductos = proveedor.Porductos;
                proveedorExistente.Tiempoentrega = proveedor.Tiempoentrega;
                proveedorExistente.Calidad = proveedor.Calidad;
                proveedorExistente.UsuarioId = proveedor.UsuarioId;

                _context.SaveChanges();
            }
        }

        public void EliminarProveedor(int id)
        {
            var proveedor = _context.Proveedores.FirstOrDefault(p => p.ProveedorId == id);
            if (proveedor != null)
            {
                _context.Proveedores.Remove(proveedor);
                _context.SaveChanges();
            }
        }
    }
}
