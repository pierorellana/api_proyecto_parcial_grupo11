using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PROYECTO.Entidades
{
    public class Inventario
    {
         public int InventarioId { get; set; }
         public int ProductoId { get; set; }
         public int Stock { get; set; }
         public decimal Precio { get; set; }
         public Producto? Producto { get; set; }
         public int ProveedorId { get; set; }
         public Proveedor? Proveedor { get; set; }
    }
}
