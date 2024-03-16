using Servicios.Api.Productos.Persistence;
using Servicios.Api.Productos.App;
using MediatR;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json")
    .Build();

// Add services to the container.

builder.Services.AddControllers().AddFluentValidation(cfg =>
{

    cfg.RegisterValidatorsFromAssemblyContaining<AgregarProducto>();
    cfg.RegisterValidatorsFromAssemblyContaining<ActualizarProducto>();

});

builder.Services.AddAutoMapper(typeof(ConsultarProducto.Ejecuta));
builder.Services.AddControllers();

builder.Services.AddDbContext<ContextoProductos>(apt =>
{
    apt.UseSqlServer(configuration.GetConnectionString("ConexionDB"));
});

builder.Services.AddMediatR(typeof(AgregarProducto.Manejador).Assembly);
builder.Services.AddMediatR(typeof(ActualizarProducto.Manejador).Assembly);


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
