using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO.Entidades
{
    public class Solicitud
    {
        public int SolicitudId { get; set; }
        public string? NombreCliente { get; set; }
        public string? CorreoCliente { get; set; }
        public string? TelefonoCliente { get; set; }
        public string? Ciudad { get; set; }
        public string? EstadoProvincia { get; set; }
        public string? DireccionCalle1 { get; set; }
        public string? CodigoPostal { get; set; }
        public string? Referencia { get; set; }

        // Campos de PayPal
        public string? CorreoPaypal { get; set; }

        // Campos de Tarjeta de Crédito
        public string? NombreTarjeta { get; set; }
        public string? NumeroTarjeta { get; set; }
        public string? ExpiracionTarjeta { get; set; }
        public string? CvcTarjeta { get; set; }

        // Relación con Producto
        public int ProductoId { get; set; }
        public Producto? Producto { get; set; }

        // Cantidad del producto
        public int Cantidad { get; set; }

        // Propiedades calculadas
        public decimal PrecioTotal => (Producto?.Precio ?? 0) * Cantidad;
        public decimal CostoEnvio { get; set; } = 5.00m; // Ejemplo de costo fijo de envío
        public decimal Total => PrecioTotal + CostoEnvio;
    }
}
