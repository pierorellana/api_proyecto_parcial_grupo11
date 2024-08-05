using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO.Entidades
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        public string? Nombrecategoria { get; set; }
        public ICollection<Producto>? Productos { get; set; }
    }
}
