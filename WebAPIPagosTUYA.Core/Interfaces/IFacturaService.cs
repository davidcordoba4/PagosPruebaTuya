using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPIPagosTUYA.Entities.Models;

namespace WebAPIPagosTUYA.Core.Interfaces
{
    public interface IFacturaService
    {
        Task<bool> Create(Factura factura);
        Task<List<Factura>> GetAll();
        Task<Factura> GetById(int id);
        Task<Factura> GetByNroFact(string nroFact);
    }
}
