namespace Servicios.Api.Productos.App
{
    public class ProductosDto
    {
        public Guid? ID { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public int? Precio { get; set; }
        public string? Categoria { get; set; }
        public int? Existencia { get; set; }
    }
}
