using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebAPIPagosTUYA.Core.Interfaces;
using WebAPIPagosTUYA.Core.Services;
using WebAPIPagosTUYA.Entities.Models;
using WebAPIPagosTUYA.Entities.DbContexts;
using WebAPIPagosTUYA.Repositories.Interfaces;
using WebAPIPagosTUYA.Repositories.Repositories;

namespace WebAPIPagosTUYA
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(
                Configuration.GetConnectionString("DefaultConnection"),
                ef => ef.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());
            services.AddTransient<IFacturaRepository, FacturaRepository>();
            services.AddTransient<IDetalleFacturaRepository, DetalleFacturaRepository>();
            services.AddTransient<IPedidoRepository, PedidoRepository>();
            services.AddTransient<IFacturaService, FacturaService>();
            services.AddTransient<IDetalleFacturaService, DetalleFacturaService>();
            services.AddTransient<IPedidoService, PedidoService>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
