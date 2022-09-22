using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPIPagosTUYA.Entities.Models;

namespace WebAPIPagosTUYA.Core.Interfaces
{
    public interface IDetalleFacturaService
    {
        Task<bool> Create(List<DetallesFactura> detallesFacturas);
        Task<List<DetallesFactura>> GetByIdFactura(int idFactura);
    }
}
