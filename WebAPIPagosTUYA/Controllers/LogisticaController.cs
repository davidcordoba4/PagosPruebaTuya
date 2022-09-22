using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPIPagosTUYA.Core.Interfaces;
using WebAPIPagosTUYA.Entities.Models;

namespace WebAPIPagosTUYA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogisticaController : ControllerBase
    {
        private readonly IPedidoService pedidoService;
        public LogisticaController(IPedidoService pedidoService)
        {
            this.pedidoService = pedidoService;
        }
        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult> Create([FromBody] Pedido pedido)
        {
            await this.pedidoService.Create(pedido);
            return Ok(new { pedido.NroPedido, pedido.TotalFactura, Estado = pedido.Estado ? "OK": "NOK" });
        }
    }
}