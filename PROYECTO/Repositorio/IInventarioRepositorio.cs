using PROYECTO.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO.Repositorio
{
    public interface IInventarioRepositorio
    {
        void AgregarInventario(Inventario inventario);
        void ActualizarInventario(Inventario inventario);
        void EliminarInventario(int id);
        Producto ObtenerProductoPorId(int productoId);
        Proveedor ObtenerProveedorPorId(int proveedorId);
        Inventario ObtenerInventarioPorId(int id);
        List<Inventario> ObtenerTodoElInventario();
        List<Inventario> ObtenerInventarioPorStock(int stock);
        List<Inventario> ObtenerInventarioPorNombreProveedor(string nombreProveedor);

    }
}
