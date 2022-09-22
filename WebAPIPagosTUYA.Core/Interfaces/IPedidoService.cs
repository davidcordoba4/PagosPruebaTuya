using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPIPagosTUYA.Entities.Models;

namespace WebAPIPagosTUYA.Core.Interfaces
{
    public interface IPedidoService
    {
        Task<bool> Create(Pedido pedido);
        Task<List<Pedido>> GetAll();
        Task<Pedido> GetByIdPedido(int idPedido);
        Task<Pedido> GetByNroPedido(string nroPedido);
    }
}
