using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPIPagosTUYA.Core.Interfaces;
using WebAPIPagosTUYA.Entities.Models;
using WebAPIPagosTUYA.Repositories.Interfaces;

namespace WebAPIPagosTUYA.Core.Services
{
    public class DetalleFacturaService : IDetalleFacturaService
    {
        private readonly IDetalleFacturaRepository detalleFacturaRepository;
        public DetalleFacturaService(IDetalleFacturaRepository detalleFacturaRepository)
        {
            this.detalleFacturaRepository = detalleFacturaRepository;
        }
        public async Task<bool> Create(List<DetallesFactura> detallesFacturas)
        {
            return await this.detalleFacturaRepository.Create(detallesFacturas);
        }
        public async Task<List<DetallesFactura>> GetByIdFactura(int idFactura)
        {
            return await this.detalleFacturaRepository.GetByIdFactura(idFactura);
        }
    }
}
