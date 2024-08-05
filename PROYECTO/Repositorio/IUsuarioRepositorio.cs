using PROYECTO.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO.Repositorio
{
    public interface IUsuarioRepositorio
    {
        Task<Usuario> ObtenerPorId(int id);
        Task<IEnumerable<Usuario>> ObtenerTodos();
        Task<IEnumerable<Usuario>> ObtenerPorNombreUsuario(string nombreUsuario);
        Task<IEnumerable<Usuario>> ObtenerPorApellido(string apellido);
        Task<IEnumerable<Usuario>> ObtenerPorCorreo(string correo);
        Task Crear(Usuario usuario);
        Task Actualizar(Usuario usuario);
        Task Eliminar(int id);
    }

}
