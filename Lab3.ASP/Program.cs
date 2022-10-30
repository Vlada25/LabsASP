using AutoMapper;
using Lab2.BLL.Interfaces.Services;
using Lab2.BLL.Services;
using Lab2.DAL;
using Lab2.DTO.Fault;
using Lab3.ASP.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(config =>
{
    config.RespectBrowserAcceptHeader = true;
    config.ReturnHttpNotAcceptable = true;
}).AddNewtonsoftJson();

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

builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.UseSession();

app.Map("/FillTables", Endpoints.FillTables);

app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}");

app.Run();


