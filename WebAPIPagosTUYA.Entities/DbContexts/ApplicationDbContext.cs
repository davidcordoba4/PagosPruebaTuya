using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebAPIPagosTUYA.Entities.Models;

namespace WebAPIPagosTUYA.Entities.DbContexts
{
    public class ApplicationDbContext : PagosPruebaTuyaContext<ApplicationDbContext>, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }
        public new async Task<int> SaveChanges()
        {
            return await base.SaveChangesAsync();
        }
    }
}
