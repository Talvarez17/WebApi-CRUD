using Servicios.Api.Productos.Persistence;
using MediatR;

namespace Servicios.Api.Productos.App
{
    public class BorrarProducto
    {
        public class Ejecuta : IRequest<Unit>
        {
            public Guid? ID{ get; set; }
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

                _contexto.ProductosModel.Remove(producto);
                await _contexto.SaveChangesAsync(cancellationToken);

                return Unit.Value;

            }
        }
    }
}
