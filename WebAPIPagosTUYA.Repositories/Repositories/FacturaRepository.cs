using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIPagosTUYA.Entities.Models;
using WebAPIPagosTUYA.Entities.DbContexts;
using WebAPIPagosTUYA.Repositories.Interfaces;

namespace WebAPIPagosTUYA.Repositories.Repositories
{
    public class FacturaRepository: IFacturaRepository
    {
        private const string prefijoFact = "FACT";
        private readonly IApplicationDbContext _dbcontext;
        public FacturaRepository(IApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<bool> Create(Factura factura)
        {
            var maxNroFact = _dbcontext.Facturas.Max(fact => fact.NroFactura);
            maxNroFact = (maxNroFact ?? string.Empty).Replace(prefijoFact, string.Empty);
            int.TryParse(maxNroFact, out int intMaxNroFact);
            intMaxNroFact += 1;
            if (intMaxNroFact.ToString().Length < 2)
            {
                factura.NroFactura = prefijoFact + new string('0', 2 - intMaxNroFact.ToString().Length) + intMaxNroFact;
            }
            else
            {
                factura.NroFactura = prefijoFact + intMaxNroFact;
            }
            _dbcontext.Facturas.Add(factura);
            await _dbcontext.SaveChanges();
            return true;
        }
        public async Task<List<Factura>> GetAll()
        {
            var facturas = await _dbcontext.Facturas.ToListAsync<Factura>();
            return facturas;
        }
        public async Task<Factura> GetById(int idFact)
        {
            var factura = await _dbcontext.Facturas.Where(fact => fact.IDFactura == idFact).FirstOrDefaultAsync();
            return factura;
        }
        public async Task<Factura> GetByNroFact(string nroFact)
        {
            var factura = await _dbcontext.Facturas.Where(fact => fact.NroFactura == nroFact).FirstOrDefaultAsync();
            return factura;
        }
    }
}
