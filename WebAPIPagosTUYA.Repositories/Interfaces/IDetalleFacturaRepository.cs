using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAPIPagosTUYA.Entities.Models;

namespace WebAPIPagosTUYA.Repositories.Interfaces
{
    public interface IDetalleFacturaRepository
    {
        Task<bool> Create(List<DetallesFactura> detallesFacturas);
        Task<List<DetallesFactura>> GetByIdFactura(int idFactura);
    }
}
