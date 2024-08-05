using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO.Entidades
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Email { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string? Genero { get; set; }
        public string? MetodoPago { get; set; }
        public string? Domicilio { get; set; }
        public int ItemsAgregados { get; set; }
        public decimal Total { get; set; }
    }
}
