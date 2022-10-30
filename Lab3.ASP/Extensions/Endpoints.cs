using Lab2.BLL.Interfaces.Services;
using Lab2.DAL;
using Lab2.DAL.Models;
using Lab2.DTO.Fault;
using Lab2.DTO.RepairingModel;
using Lab2.DTO.SparePart;
using Lab2.DTO.UsedSparePart;

namespace Lab3.ASP.Extensions
{
    public static class Endpoints
    {
        public static void FillTables(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                IRepairingModelsService repairingModelsService = context.RequestServices.GetService<IRepairingModelsService>();
                IEnumerable<RepairingModelDto> repairingModels = await repairingModelsService.Get(25, "RepairingModels25");

                IFaultsService faultsService = context.RequestServices.GetService<IFaultsService>();
                ISparePartsService sparePartsService = context.RequestServices.GetService<ISparePartsService>();
                IUsedSparePartsService usedSparePartsService = context.RequestServices.GetService<IUsedSparePartsService>();

                if (repairingModels.Count() == 0)
                {
                    DbInitializer.Initialize();

                    repairingModelsService.Create(DbInitializer.RepairingModels);
                    sparePartsService.Create(DbInitializer.SpareParts);
                    faultsService.Create(DbInitializer.Faults);
                    usedSparePartsService.Create(DbInitializer.UsedSpareParts);
                    
                    await context.Response.WriteAsync("All Done!");
                }
                else
                {
                    await context.Response.WriteAsync("Tables are already filled!");
                }
            });
        }
    }
}
