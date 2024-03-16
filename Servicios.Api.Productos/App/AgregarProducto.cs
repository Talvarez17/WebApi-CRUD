using MediatR;
using FluentValidation;
using Servicios.Api.Productos.Models;
using Servicios.Api.Productos.Persistence;

namespace Servicios.Api.Productos.App
{
    public class AgregarProducto
    {
        public class Ejecuta : IRequest
        {
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
                RuleFor(x => x.Nombre).NotEmpty();
                RuleFor(x => x.Descripcion).NotEmpty();
                RuleFor(x => x.Precio).NotEmpty();
                RuleFor(x => x.Categoria).NotEmpty();
                RuleFor(x => x.Existencia).NotEmpty();
            }
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly ContextoProductos _contexto;

            public Manejador(ContextoProductos contexto)
            {
                _contexto = contexto;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {

                var producto = new ProductosModel
                {
                    Nombre = request.Nombre,
                    Descripcion = request.Descripcion,
                    Precio = request.Precio,
                    Categoria = request.Categoria,
                    Existencia = request.Existencia
                };

                _contexto.ProductosModel.Add(producto);

                var value = await _contexto.SaveChangesAsync();

                if (value > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("No se puede guardar el producto");

            }
        }
    }
}
