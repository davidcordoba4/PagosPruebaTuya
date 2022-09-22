using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebAPIPagosTUYA.Entities.Models;

namespace WebAPIPagosTUYA.Entities.DbContexts
{
    public interface IApplicationDbContext
    {
        DbSet<Factura> Facturas { get; set; }
        DbSet<DetallesFactura> DetallesFacturas { get; set; }
        DbSet<Pedido> Pedidos { get; set; }
        Task<int> SaveChanges();
    }
}
