using Lab2.BLL.Interfaces.Services;
using Lab2.BLL.Services;
using Lab2.DAL;
using Lab2.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lab3.ASP.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureSqlContext(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(opts =>
                opts.UseSqlServer(configuration.GetConnectionString("sqlConnection"), b =>
                    b.MigrationsAssembly("Lab2.DAL")));
        }

        public static void ConfigureDbServices(this IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddScoped<IRepositoryManager, RepositoryManager>();

            services.AddScoped<IFaultsService, FaultsService>();
            services.AddScoped<IRepairingModelsService, RepairingModelsService>();
            services.AddScoped<ISparePartsService, SparePartsService>();
            services.AddScoped<IUsedSparePartsService, UsedSparePartsService>();
        }
    }
}
