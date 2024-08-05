using PROYECTO.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO.Repositorio
{
    public interface IProductoRepositorio
    {
        Task<int> Agregar(Producto producto);
        Task<bool> Editar(Producto producto);
        Task<bool> Eliminar(int id);
        Task<List<Producto>> ListarTodos();
        Task<Producto> ConsultarPorId(int id);
        Task<List<Producto>> ConsultarPorNombre(string nombre);
        Task<List<Producto>> ConsultarPorCategoriaNombre(string categoriaNombre);
        Task<List<Producto>> ConsultarPorPrecio(decimal precio);
        Task<List<Producto>> ConsultarPorStock(int stock);
        Task<bool> CategoriaExiste(int categoriaId);
    }

}
