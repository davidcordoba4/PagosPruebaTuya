using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIPagosTUYA.Entities.Models;
using WebAPIPagosTUYA.Entities.DbContexts;
using WebAPIPagosTUYA.Repositories.Interfaces;

namespace WebAPIPagosTUYA.Repositories.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private const string prefijoPedido = "PEDIDO";
        private readonly IApplicationDbContext _dbcontext;
        public PedidoRepository(IApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<bool> Create(Pedido pedido)
        {
            var maxNroPedido = _dbcontext.Pedidos.Max(pedido => pedido.NroPedido);
            maxNroPedido = (maxNroPedido ?? string.Empty).Replace(prefijoPedido, string.Empty);
            int.TryParse(maxNroPedido, out int intMaxNroPedido);
            intMaxNroPedido += 1;
            if (intMaxNroPedido.ToString().Length < 2)
            {
                pedido.NroPedido = prefijoPedido + new string('0', 2 - intMaxNroPedido.ToString().Length) + intMaxNroPedido;
            }
            else
            {
                pedido.NroPedido = prefijoPedido + intMaxNroPedido;
            }
            pedido.Estado = true;
            _dbcontext.Pedidos.Add(pedido);
            await _dbcontext.SaveChanges();
            return true;
        }
        public async Task<List<Pedido>> GetAll()
        {
            var pedidos = await _dbcontext.Pedidos.ToListAsync<Pedido>();
            return pedidos;
        }
        public async Task<Pedido> GetByIdPedido(int idPedido)
        {
            var pedido = await _dbcontext.Pedidos.Where(pedido => pedido.IDPedido == idPedido).FirstOrDefaultAsync();
            return pedido;
        }
        public async Task<Pedido> GetByNroPedido(string nroPedido)
        {
            var pedido = await _dbcontext.Pedidos.Where(pedido => pedido.NroPedido == nroPedido).FirstOrDefaultAsync();
            return pedido;
        }
    }
}
