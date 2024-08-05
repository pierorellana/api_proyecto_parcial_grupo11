using PROYECTO.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO.Repositorio
{
    public interface ISolicitudSoporteRepositorio
    {
        Task<int> Agregar(SolicitudSoporte solicitudSoporte);
        Task<bool> Editar(SolicitudSoporte solicitudSoporte);
        Task<bool> Eliminar(int id);
        Task<List<SolicitudSoporte>> ListarTodas();
        Task<SolicitudSoporte> ConsultarSoportePorId(int solicitudSoporteId);
        Task<List<SolicitudSoporte>> ConsultarPorNombre(string nombre); 
        Task<List<SolicitudSoporte>> ConsultarPorApellido(string apellido); 
        Task<List<SolicitudSoporte>> ConsultarPorGenero(string genero);

    }
}
