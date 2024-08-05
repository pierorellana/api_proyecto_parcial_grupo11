using PROYECTO.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO.Repositorio
{
    public interface ICategoriaRepositorio
    {
        Task<int> Agregar(Categoria categoria);
        Task<bool> Editar(Categoria categoria);
        Task<bool> Eliminar(int id);
        Task<List<Categoria>> ListarTodas();
        Task<List<Categoria>> ConsultarPorCategoriaId(int categoriaId);
        Task<List<Categoria>> ConsultarPorNombrecategoria(string nombreCategoria);

        // Método para consultar productos por categoría
        Task<List<Categoria>> ConsultarCategoriasPorNombreProducto(string nombreProducto);

    }
}
