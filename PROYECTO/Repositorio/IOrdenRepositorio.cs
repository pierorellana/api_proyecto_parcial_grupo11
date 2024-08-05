using PROYECTO.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO.Repositorio
{
    public interface IOrdenRepositorio
    {
        Task<int> Agregar(Orden orden);
        Task<bool> Editar(Orden orden);
        Task<bool> Eliminar(int id);
        Task<Orden?> ConsultarPorId(int id);
        Task<List<Orden>> ConsultarTodas();
        Task<List<Orden>> ConsultarPorCliente(string nombreCliente);


    }
}
