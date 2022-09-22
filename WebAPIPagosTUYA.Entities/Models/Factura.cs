using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace WebAPIPagosTUYA.Entities.Models
{
    public partial class Factura
    {
        public Factura()
        {
            DetallesFacturas = new HashSet<DetallesFactura>();
            Pedidos = new HashSet<Pedido>();
        }
        [Key]
        public int IDFactura { get; set; }
        public string NombreUsuario { get; set; }
        public string TipoDocumento { get; set; }
        public string NroDocumento { get; set; }
        public string NroFactura { get; set; }
        public decimal Total { get; set; }

        public virtual ICollection<DetallesFactura> DetallesFacturas { get; set; }
        public virtual ICollection<Pedido> Pedidos { get; set; }
        [NotMapped]
        public List<DetallesFactura> DetallesFactura { get; set; }
    }
}
