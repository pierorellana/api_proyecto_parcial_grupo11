using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PROYECTO.Entidades
{
    public class Proveedor
    {
        public int ProveedorId { get; set; }
        public string? Nombre { get; set; }
        public string? Email { get; set; }
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
        public string? Porductos { get; set; }
        public string? Tiempoentrega { get; set; }
        public int Calidad { get; set; }

        // Relación con Usuario o lo asigno con rol mejor?
        public int UsuarioId { get; set; }
        [JsonIgnore]
        public Usuario? Usuario { get; set; }
    }
}
