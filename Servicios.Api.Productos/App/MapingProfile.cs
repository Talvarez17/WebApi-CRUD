using Servicios.Api.Productos.Models;
using AutoMapper;
namespace Servicios.Api.Productos.App
{
    public class MapingProfile: Profile
    {
        public MapingProfile() {

            CreateMap<ProductosModel, ProductosDto>();
        }
    }
}
