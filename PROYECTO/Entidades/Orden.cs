using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO.Entidades
{
    public class Orden
    {
        public int OrdenId { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public string? EstadoOrden { get; set; } // "Pendiente", "Completada", "Cancelada"
        // Relación con Solicitud
        public int SolicitudId { get; set; }
        public Solicitud? Solicitud { get; set; }
    }

}
