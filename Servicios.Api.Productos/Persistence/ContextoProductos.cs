using Microsoft.EntityFrameworkCore;
using Servicios.Api.Productos.Models;

namespace Servicios.Api.Productos.Persistence
{
    public class ContextoProductos: DbContext
    {
        public ContextoProductos(DbContextOptions<ContextoProductos> options) : base(options) { }
        public DbSet<ProductosModel> ProductosModel { get; set; }
    }
}
