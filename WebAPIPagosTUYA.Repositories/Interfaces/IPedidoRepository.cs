using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAPIPagosTUYA.Entities.Models;

namespace WebAPIPagosTUYA.Repositories.Interfaces
{
    public interface IPedidoRepository
    {
        Task<bool> Create(Pedido pedido);
        Task<List<Pedido>> GetAll();
        Task<Pedido> GetByIdPedido(int idPedido);
        Task<Pedido> GetByNroPedido(string nroPedido);
    }
}
