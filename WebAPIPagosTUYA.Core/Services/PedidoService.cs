using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPIPagosTUYA.Core.Interfaces;
using WebAPIPagosTUYA.Entities.Models;
using WebAPIPagosTUYA.Repositories.Interfaces;

namespace WebAPIPagosTUYA.Core.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository pedidoRepository;
        private readonly IFacturaRepository facturaRepository;
        public PedidoService(IPedidoRepository pedidoRepository, IFacturaRepository facturaRepository)
        {
            this.pedidoRepository = pedidoRepository;
            this.facturaRepository = facturaRepository;
        }
        public async Task<bool> Create(Pedido pedido)
        {
            var factura = await this.facturaRepository.GetByNroFact(pedido.NroFactura);
            pedido.IDFactura = factura.IDFactura;
            pedido.TotalFactura = factura.Total;
            return await this.pedidoRepository.Create(pedido);
        }
        public async Task<List<Pedido>> GetAll()
        {
            return await this.pedidoRepository.GetAll();
        }
        public async Task<Pedido> GetByIdPedido(int idPedido)
        {
            return await this.pedidoRepository.GetByIdPedido(idPedido);
        }
        public async Task<Pedido> GetByNroPedido(string nroPedido)
        {
            return await this.pedidoRepository.GetByNroPedido(nroPedido);
        }
    }
}
