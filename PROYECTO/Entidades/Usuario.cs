using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PROYECTO.Entidades
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string? NombreUsuario { get; set; }
        public string? Apellido { get; set; }
        public string? Correo { get; set; }
        public string? Contraseña { get; set; }
        public int RolId { get; set; }
        [JsonIgnore]
        public Rol? Rol { get; set; }

    }
}
