using Lab2.BLL.Interfaces.Services;
using Lab2.DAL.Models;
using Lab2.DTO.Fault;
using Lab2.DTO.RepairingModel;
using Lab2.DTO.SparePart;
using Lab2.DTO.UsedSparePart;

namespace Lab3.ASP.Extensions
{
    public static class Endpoints
    {
        private readonly static string _styles = "<style>" +
            "a {display: block; padding: 5px 10px 5px 10px; font-size: 130%; " +
            "background-color: #BBF4FF; text-decoration: none; color: black;" +
            "margin-top: 10px; border-radius: 5px;}" +
            "body {display: flex; flex-direction: column; align-items: center;}" +
            "h1 {text-align: center;}" +
            ".bg-yellow {background-color: #FFF86E;}" +
            ".bg-green {background-color: #49F883;}" +
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

        public static void Info(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync(GetHtmlTemplate("Info",
                    "<script type = \"text/javascript\"> " +
                    "var code = navigator.appCodeName;" +
                    "var name = navigator.appName;" +
                    "var vers = navigator.appVersion; " +
                    "var platform = navigator.platform;" +
                    "var cook = navigator.cookieEnabled;" +
                    "var je = navigator.javaEnabled();" +
                    "var ua = navigator.userAgent;" +
                    "document.write('Браузер: ' + name + " +
                    "'<br />Версия браузера: ' + vers +" +
                    "'<br />Кодовое название браузера: ' + code +" +
                    "'<br />Платформа: ' + platform +" +
                    "'<br />Поддержка cookie: ' + cook +" +
                    "'<br />Поддержка JavaScript: ' + je +" +
                    "'<br />userAgent: ' + ua);" +
                    "</script>" +
                    "<a href=\"/\">Back</a><br>"));
            });
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

        // запоминание в куки
        public static void FaultsTableSearch(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                IFaultsService faultsService = context.RequestServices.GetService<IFaultsService>();
                IEnumerable<FaultDto> faults = await faultsService.Get(10, "Faults10");

                string keyName = "FaultName";
                string keySelect = "FaultSelect";
                string keyMultiselect = "FaultMultiselect";

                string htmlString =
                    "<a href=\"/\">Back</a><br>" +
                    "<form>" +
                    $"<input id=\"name-input\" type=\"text\" name=\"FaultName\" placeholder=\"Name\" " +
                    $"value=\"{context.Request.Cookies[keyName]}\"/><br><br>" +
                    $"<select name=\"{keySelect}\"><option>Default</option>";
                    

                foreach (var fault in faults)
                {
                    if ($"{fault.Name} ({fault.Id})" == context.Request.Cookies[keySelect])
                        htmlString += $"<option selected>{fault.Name} ({fault.Id})</option>";
                    else
                        htmlString += $"<option>{fault.Name} ({fault.Id})</option>";
                }

                htmlString += $"</select><br><br><select multiple name=\"{keyMultiselect}\" size=\"10\">";

                string[] selectedItemsArr = { };
                if (context.Request.Cookies[keyMultiselect] is not null)
                    selectedItemsArr = context.Request.Cookies[keyMultiselect].Split(',');

                foreach (var fault in faults)
                {
                    bool isContains = false;
                    foreach (var item in selectedItemsArr)
                    {
                        if ($"{fault.Name} ({fault.Id})" == item)
                        {
                            isContains = true;
                            break;
                        }
                    }

                    if (isContains)
                        htmlString += $"<option selected>{fault.Name} ({fault.Id})</option>";
                    else
                        htmlString += $"<option>{fault.Name} ({fault.Id})</option>";
                }

                htmlString += "</select><br><br>" +
                    "<button type=\"submit\">Search</button>" +
                    "</form>";

                string faultName = context.Request.Query[keyName];
                string faultSelected = context.Request.Query[keySelect];
                string faultMultiselected = context.Request.Query[keyMultiselect];

                if (faultName is not null)
                    context.Response.Cookies.Append(keyName, faultName);

                if (faultSelected is not null)
                    context.Response.Cookies.Append(keySelect, faultSelected);

                if (faultMultiselected is not null)
                    context.Response.Cookies.Append(keyMultiselect, faultMultiselected);

                await context.Response.WriteAsync(GetHtmlTemplate("Faults", htmlString));
            });
        }


        // запоминание в сессию
        public static void RepairingModelTableSearch(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                IRepairingModelsService repairingModelsService = context.RequestServices.GetService<IRepairingModelsService>();
                IEnumerable<RepairingModelDto> repairingModels = await repairingModelsService.Get(10, "RepairingModels10");

                string keyName = "RepairingModelName";
                string keySelect = "FaultSelect";
                string keyMultiselect = "FaultMultiselect";

                string htmlString =
                    "<a href=\"/\">Back</a><br>" +
                    "<form>" +
                    $"<input id=\"name-input\" type=\"text\" name=\"{keyName}\" placeholder=\"Name\" " +
                    $"value=\"{context.Session.GetString(keyName)}\"/><br><br>" +
                    $"<select name=\"{keySelect}\"><option>Default</option>";

                foreach (var rm in repairingModels)
                {
                    if ($"{rm.Name} ({rm.Id})" == context.Session.GetString(keySelect))
                        htmlString += $"<option selected>{rm.Name} ({rm.Id})</option>";
                    else
                        htmlString += $"<option>{rm.Name} ({rm.Id})</option>";
                }

                htmlString += $"</select><br><br><select multiple name=\"{keyMultiselect}\" size=\"10\">";

                string[] selectedItemsArr = { };
                if (context.Session.GetString(keyMultiselect) is not null)
                    selectedItemsArr = context.Session.GetString(keyMultiselect).Split(',');

                foreach (var rm in repairingModels)
                {
                    bool isContains = false;
                    foreach (var item in selectedItemsArr)
                    {
                        if ($"{rm.Name} ({rm.Id})" == item)
                        {
                            isContains = true;
                            break;
                        }
                    }

                    if (isContains)
                        htmlString += $"<option selected>{rm.Name} ({rm.Id})</option>";
                    else
                        htmlString += $"<option>{rm.Name} ({rm.Id})</option>";
                }

                htmlString += "</select><br><br>" +
                    "<button type=\"submit\">Search</button>" +
                    "</form>";

                string repairingModelName = context.Request.Query[keyName];
                string repairingModelSelected = context.Request.Query[keySelect];
                string repairingModelMultiselected = context.Request.Query[keyMultiselect];

                if (repairingModelName is not null)
                    context.Session.SetString(keyName, repairingModelName);

                if (repairingModelSelected is not null)
                    context.Session.SetString(keySelect, repairingModelSelected);

                if (repairingModelMultiselected is not null)
                    context.Session.SetString(keyMultiselect, repairingModelMultiselected);

                await context.Response.WriteAsync(GetHtmlTemplate("RepairingModels", htmlString));
            });
        }
    }
}
