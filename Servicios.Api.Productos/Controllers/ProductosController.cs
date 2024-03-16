using Microsoft.AspNetCore.Mvc;
using Servicios.Api.Productos.App;
using MediatR;

namespace Servicios.Api.Productos.Controllers
{
    [Route("api/producto")]
    [ApiController]
    public class ProductosController : Controller
    {
        private readonly IMediator _mediator;

        public ProductosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Crear(AgregarProducto.Ejecuta data)
        {
            return await _mediator.Send(data);
        }

        [HttpPut]
        public async Task<ActionResult<Unit>> Actualizar(ActualizarProducto.Ejecuta data)
        {
            return await _mediator.Send(data);
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductosDto>>> Obtener()
        {
            return await _mediator.Send(new ConsultarProducto.Ejecuta());
        }

        [HttpGet("getXId/{id}")]
        public async Task<ActionResult<List<ProductosDto>>> ObtenerPorId(Guid id)
        {
            return await _mediator.Send(new ConsultarProductoId.Ejecuta { ID = id });
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<Unit>> Borrar(Guid id)
        {
            return await _mediator.Send(new BorrarProducto.Ejecuta { ID = id });
        }
    }
}
