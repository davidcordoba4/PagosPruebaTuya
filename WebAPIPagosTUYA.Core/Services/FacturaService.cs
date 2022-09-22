using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIPagosTUYA.Core.Interfaces;
using WebAPIPagosTUYA.Entities.Models;
using WebAPIPagosTUYA.Repositories.Interfaces;

namespace WebAPIPagosTUYA.Core.Services
{
    public class FacturaService: IFacturaService
    {
        private readonly IFacturaRepository facturaRepository;
        private readonly IDetalleFacturaRepository detalleFacturaRepository;
        public FacturaService(IFacturaRepository facturaRepository, IDetalleFacturaRepository detalleFacturaRepository)
        {
            this.facturaRepository = facturaRepository;
            this.detalleFacturaRepository = detalleFacturaRepository;
        }
        public async Task<bool> Create(Factura factura)
        {
            factura.DetallesFactura.ForEach(detalleFact => detalleFact.Total = detalleFact.Precio * detalleFact.Cantidad);
            factura.Total = factura.DetallesFactura.Sum(detallefact => detallefact.Total);
            await this.facturaRepository.Create(factura);
            factura.DetallesFactura.ForEach(detFact => detFact.IDFactura = factura.IDFactura);
            return await this.detalleFacturaRepository.Create(factura.DetallesFactura);
        }
        public async Task<List<Factura>> GetAll()
        {
            return await this.facturaRepository.GetAll();
        }
        public async Task<Factura> GetById(int idFact)
        {
            return await this.facturaRepository.GetById(idFact);
        }
        public async Task<Factura> GetByNroFact(string nroFact)
        {
            return await this.facturaRepository.GetByNroFact(nroFact);
        }
    }
}
