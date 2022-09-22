using System.ComponentModel.DataAnnotations;

#nullable disable

namespace WebAPIPagosTUYA.Entities.Models
{
    public partial class DetallesFactura
    {
        [Key]
        public int IDDetalleFactura { get; set; }
        public int Cantidad { get; set; }
        public int IDFactura { get; set; }
        public string NombreProducto { get; set; }
        public decimal Precio { get; set; }
        public decimal Total { get; set; }

        public virtual Factura IDFacturaNavigation { get; set; }
    }
}
