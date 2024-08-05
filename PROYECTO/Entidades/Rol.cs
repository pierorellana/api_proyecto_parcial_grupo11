using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PROYECTO.Entidades
{
    public class Rol
    {
        public int RolId { get; set; }
        public string? NombreRol { get; set; } // "Cliente" o "Proveedor"
        [JsonIgnore]
        public List<Usuario> Usuarios { get; set; } = new List<Usuario>();
    }
}
