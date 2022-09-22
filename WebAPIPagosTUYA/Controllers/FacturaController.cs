using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPIPagosTUYA.Core.Interfaces;
using WebAPIPagosTUYA.Entities.Models;

namespace WebAPIPagosTUYA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private readonly IFacturaService facturaService;
        public FacturaController(IFacturaService facturaService)
        {
            this.facturaService = facturaService;
        }
        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult> Create([FromBody] Factura factura)
        {
            await this.facturaService.Create(factura);
            return Ok(new { factura.NroFactura, factura.Total });
        }
    }
}