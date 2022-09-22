using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace WebAPIPagosTUYA.Entities.Models
{
    public partial class Pedido
    {
        [Key]
        public int IDPedido { get; set; }
        public int IDFactura { get; set; }
        public string NroPedido { get; set; }
        public string Pais { get; set; }
        public string Barrio { get; set; }
        public string Ciudad { get; set; }
        public string Direccion { get; set; }
        public bool Estado { get; set; }

        public virtual Factura IDFacturaNavigation { get; set; }
        [NotMapped]
        public string NroFactura { get; set; }
        [NotMapped]
        public decimal TotalFactura { get; set; }
    }
}
