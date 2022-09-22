using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAPIPagosTUYA.Entities.Models;

namespace WebAPIPagosTUYA.Repositories.Interfaces
{
    public interface IFacturaRepository
    {
        Task<bool> Create(Factura factura);
        Task<List<Factura>> GetAll();
        Task<Factura> GetById(int id);
        Task<Factura> GetByNroFact(string nroFact);
    }
}
