using PROYECTO.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO.Repositorio
{
    public interface IRolRepositorio
    {
        Task<Rol> ObtenerPorId(int id);
        Task<IEnumerable<Rol>> ObtenerTodos();
        Task Crear(Rol rol);
        Task Actualizar(Rol rol);
        Task Eliminar(int id);
    }
}
