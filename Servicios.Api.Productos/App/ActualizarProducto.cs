using Servicios.Api.Productos.Persistence;
using FluentValidation;
using MediatR;

namespace Servicios.Api.Productos.App
{
    public class ActualizarProducto
    {
        public class Ejecuta : IRequest
        {
            public Guid? ID { get; set; }
            public string? Nombre { get; set; }
            public string? Descripcion { get; set; }
            public int? Precio { get; set; }
            public string? Categoria { get; set; }
            public int? Existencia { get; set; }
        }

        public class EjecutaValidacion : AbstractValidator<Ejecuta>
        {
            public EjecutaValidacion()
            {
                RuleFor(x => x.ID).NotEmpty();
                RuleFor(x => x.Nombre).NotEmpty();
                RuleFor(x => x.Descripcion).NotEmpty();
                RuleFor(x => x.Precio).NotEmpty();
                RuleFor(x => x.Categoria).NotEmpty();
                RuleFor(x => x.Existencia).NotEmpty();
            }
        }

        public class Manejador : IRequestHandler<Ejecuta, Unit>
        {
            private readonly ContextoProductos _contexto;

            public Manejador(ContextoProductos contexto)
            {
                _contexto = contexto;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var producto = await _contexto.ProductosModel.FindAsync(request.ID);

                if (producto == null)
                {
                    throw new Exception("Producto no encontrado");
                }

                producto.Nombre = request.Nombre;
                producto.Descripcion = request.Descripcion;
                producto.Precio = request.Precio;
                producto.Categoria = request.Categoria;
                producto.Existencia = request.Existencia;


                var value = await _contexto.SaveChangesAsync();

                if (value > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("No se puede actualizar el producto");

            }
        }
    }
}
