using Microsoft.EntityFrameworkCore;
using Servicios.Api.Productos.Models;
using Servicios.Api.Productos.Persistence;
using MediatR;
using AutoMapper;

namespace Servicios.Api.Productos.App
{
    public class ConsultarProducto
    {

        public class Ejecuta : IRequest<List<ProductosDto>> { }

        public class Manejador : IRequestHandler<Ejecuta, List<ProductosDto>>
        {

            private readonly ContextoProductos _contexto;
            private readonly IMapper _mapper;

            public Manejador(ContextoProductos contexto, IMapper mapper)
            {
                _contexto = contexto;
                _mapper = mapper;
            }

            public async Task<List<ProductosDto>> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var productos = await _contexto.ProductosModel.ToListAsync(cancellationToken);
                var productosDto = _mapper.Map<List<ProductosModel>, List<ProductosDto>>(productos);
                return productosDto;
            }
        }
    }
}
