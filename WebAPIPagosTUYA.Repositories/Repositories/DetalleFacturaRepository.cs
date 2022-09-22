using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIPagosTUYA.Entities.Models;
using WebAPIPagosTUYA.Entities.DbContexts;
using WebAPIPagosTUYA.Repositories.Interfaces;

namespace WebAPIPagosTUYA.Repositories.Repositories
{
    public class DetalleFacturaRepository : IDetalleFacturaRepository
    {
        private readonly IApplicationDbContext _dbcontext;
        public DetalleFacturaRepository(IApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<bool> Create(List<DetallesFactura> detallesFacturas)
        {
            _dbcontext.DetallesFacturas.AddRange(detallesFacturas);
            await _dbcontext.SaveChanges();
            return true;
        }
        public async Task<List<DetallesFactura>> GetByIdFactura(int idFactura)
        {
            var detallesFacturas = await _dbcontext.DetallesFacturas.Where(detalleFact => detalleFact.IDFactura == idFactura).ToListAsync();
            return detallesFacturas;
        }
    }
}
