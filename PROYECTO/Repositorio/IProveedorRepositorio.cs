using PROYECTO.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO.Repositorio
{
    public interface IProveedorRepositorio
    {
        void AgregarProveedor(Proveedor proveedor);
        void ActualizarProveedor(Proveedor proveedor);
        void EliminarProveedor(int id);
        Proveedor ObtenerProveedorPorId(int id);
        List<Proveedor> ObtenerTodosLosProveedores();
        List<Proveedor> ObtenerProveedoresPorNombre(string nombre);
        List<Proveedor> ObtenerProveedoresPorProducto(string producto);
        List<Proveedor> ObtenerProveedoresPorCalidad(int calidad);
        
    }
}
