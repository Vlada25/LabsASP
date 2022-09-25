using Lab2.BLL.Interfaces.Services;
using Lab2.DTO.Fault;
using Lab2.DTO.RepairingModel;
using Lab2.DTO.SparePart;
using Lab2.DTO.UsedSparePart;

namespace Lab3.ASP.Extensions
{
    public static class Endpoints
    {
        private readonly static string _styles = "<style>" +
            "a {font-size: 130%;}" +
            "body {display: flex; flex-direction: column; align-items: center; background-color: #BBF4FF;}" +
            "h1 {text-align: center;}" +
            "</style>";

        public static string GetHtmlTemplate(string title, string body)
        {
            return "<html><head>" +
                $"<title>{title}</title>" +
                "<meta charset=\"utf-8\" />" +
                _styles +
                "</head><body>" +
                $"<h1>{title}</h1>{body}" +
                "</body></html>";
        }

        public static void FaultsTable(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                IFaultsService faultsService = context.RequestServices.GetService<IFaultsService>();
                IEnumerable<FaultDto> faults = await faultsService.Get(25, "Faults25");

                string htmlString = 
                    "<a href=\"/\">Back</a><br>" +
                    "<table border=1>" +
                    "<tr>" +
                    "<th>Id</th>" +
                    "<th>Name</th>" +
                    "<th>RepairingModelId</th>" +
                    "<th>RepairingMethods</th>" +
                    "</tr>";
                    
                foreach (var fault in faults)
                {
                    htmlString += "<tr>" +
                                $"<td>{fault.Id}</td>" +
                                $"<td>{fault.Name}</td>" +
                                $"<td>{fault.RepairingModelId}</td>" +
                                $"<td>{fault.RepairingMethods}</td>" +
                                "</tr>";
                }

                htmlString += "</table>";

                await context.Response.WriteAsync(GetHtmlTemplate("Faults", htmlString));
            });
        }

        public static void RepairingModelsTable(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                IRepairingModelsService repairingModelsService = context.RequestServices.GetService<IRepairingModelsService>();
                IEnumerable<RepairingModelDto> repairingModels = await repairingModelsService.Get(25, "RepairingModels25");

                string htmlString =
                    "<a href=\"/\">Back</a><br>" +
                    "<table border=1>" +
                    "<tr>" +
                    "<th>Id</th>" +
                    "<th>Name</th>" +
                    "<th>Type</th>" +
                    "<th>Manufacturer</th>" +
                    "<th>Specifications</th>" +
                    "<th>ParticularQualities</th>" +
                    "</tr>";

                foreach (var repairingModel in repairingModels)
                {
                    htmlString += "<tr>" +
                                $"<td>{repairingModel.Id}</td>" +
                                $"<td>{repairingModel.Name}</td>" +
                                $"<td>{repairingModel.Type}</td>" +
                                $"<td>{repairingModel.Manufacturer}</td>" +
                                $"<td>{repairingModel.Specifications}</td>" +
                                $"<td>{repairingModel.ParticularQualities}</td>" +
                                "</tr>";
                }

                htmlString += "</table>";

                await context.Response.WriteAsync(GetHtmlTemplate("RepairingModels", htmlString));
            });
        }

        public static void SparePartsTable(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                ISparePartsService sparePartsService = context.RequestServices.GetService<ISparePartsService>();
                IEnumerable<SparePartDto> spareParts = await sparePartsService.Get(25, "SpareParts25");

                string htmlString =
                    "<a href=\"/\">Back</a><br>" +
                    "<table border=1>" +
                    "<tr>" +
                    "<th>Id</th>" +
                    "<th>Name</th>" +
                    "<th>Functions</th>" +
                    "<th>Price</th>" +
                    "<th>EquipmentType</th>" +
                    "</tr>";

                foreach (var sparePart in spareParts)
                {
                    htmlString += "<tr>" +
                                $"<td>{sparePart.Id}</td>" +
                                $"<td>{sparePart.Name}</td>" +
                                $"<td>{sparePart.Functions}</td>" +
                                $"<td>{sparePart.Price}</td>" +
                                $"<td>{sparePart.EquipmentType}</td>" +
                                "</tr>";
                }

                htmlString += "</table>";

                await context.Response.WriteAsync(GetHtmlTemplate("SpareParts", htmlString));
            });
        }

        public static void UsedSparePartsTable(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                IUsedSparePartsService usedSparePartsService = context.RequestServices.GetService<IUsedSparePartsService>();
                IEnumerable<UsedSparePartDto> usedSpareParts = await usedSparePartsService.Get(25, "UsedSpareParts25");

                string htmlString =
                    "<a href=\"/\">Back</a><br>" +
                    "<table border=1>" +
                    "<tr>" +
                    "<th>Id</th>" +
                    "<th>FaultId</th>" +
                    "<th>FaultName</th>" +
                    "<th>SparePartId</th>" +
                    "<th>SparePartName</th>" +
                    "</tr>";

                foreach (var usedSparePart in usedSpareParts)
                {
                    htmlString += "<tr>" +
                                $"<td>{usedSparePart.Id}</td>" +
                                $"<td>{usedSparePart.FaultId}</td>" +
                                $"<td>{usedSparePart.FaultName}</td>" +
                                $"<td>{usedSparePart.SparePartId}</td>" +
                                $"<td>{usedSparePart.SparePartName}</td>" +
                                "</tr>";
                }

                htmlString += "</table>";

                await context.Response.WriteAsync(GetHtmlTemplate("UsedSpareParts", htmlString));
            });
        }
    }
}
