using AutoMapper;
using Lab2.BLL.Interfaces.Services;
using Lab2.BLL.Services;
using Lab2.DAL;
using Lab2.DTO.Fault;
using Lab3.ASP.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.ConfigureDbServices();

var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});

IMapper autoMapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(autoMapper);

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

var app = builder.Build();

app.UseSession();

app.Map("/Faults", Endpoints.FaultsTable);
app.Map("/RepairingModels", Endpoints.RepairingModelsTable);
app.Map("/SpareParts", Endpoints.SparePartsTable);
app.Map("/UsedSpareParts", Endpoints.UsedSparePartsTable);
app.Map("/Info", Endpoints.Info);
app.Map("/SearchFaults", Endpoints.FaultsTableSearch);
app.Map("/SearchRepairingModels", Endpoints.RepairingModelTableSearch);

app.MapGet("/", async context =>
{
    string htmlString = Endpoints.GetHtmlTemplate("Index", 
        "<a href=\"/Faults\">Faults</a>" +
        "<a href=\"/RepairingModels\">RepairingModels</a>" +
        "<a href=\"/SpareParts\">SpareParts</a>" +
        "<a href=\"/UsedSpareParts\">UsedSpareParts</a>" +
        "<a href=\"/Info\" class=\"bg-yellow\">Info</a>" +
        "<a href=\"/SearchFaults\" class=\"bg-green\">Search Faults</a>" +
        "<a href=\"/SearchRepairingModels\" class=\"bg-green\">Search Repairing Models</a>");

    await context.Response.WriteAsync(htmlString);
});

app.Run();


