using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO.Entidades
{
    public class SolicitudSoporte
    {
        public int SolicitudSoporteId { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Direccion { get; set; }
        public DateTime Fecha { get; set; }
        public string? Genero { get; set; }
        public string? Comentario { get; set; }

    }
}
