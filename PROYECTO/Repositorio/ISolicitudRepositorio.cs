using PROYECTO.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO.Repositorio
{
    public interface ISolicitudRepositorio
    {
        Task<int> Agregar(Solicitud solicitud);
        Task<bool> Editar(Solicitud solicitud);
        Task<bool> Eliminar(int id);
        Task<Solicitud?> ConsultarPorId(int id);
        Task<List<Solicitud>> ConsultarTodas();
        Task<List<Solicitud>> ConsultarPorCliente(string nombreCliente);
        Task<List<Solicitud>> ConsultarPorCiudad(string ciudad);
    }
}
