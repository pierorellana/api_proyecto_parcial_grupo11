using PROYECTO.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO.Repositorio
{
    public interface IClienteRepositorio
    {
        Task<int> Agregar(Cliente cliente);
        Task<bool> Editar(Cliente cliente);
        Task<bool> Eliminar(int id);
        Task<List<Cliente>> ListarTodos();
        Task<Cliente> BuscarPorId(int id);
        Task<List<Cliente>> BuscarPorNombre(string nombre);
        Task<List<Cliente>> BuscarPorGenero(string genero);
        Task<List<Cliente>> BuscarPorApellido(string apellido);
    }
}
