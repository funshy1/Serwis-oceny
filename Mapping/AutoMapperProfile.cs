using AutoMapper;
using projekt.Controllers.Resources;
using projekt.Models;

namespace projekt.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Domain to API
            CreateMap<ProductQuery, ProductQueryResource>();
            CreateMap<Product, ProductResource>();

            //API to Domain
            CreateMap<ProductQueryResource, ProductQuery>();
            CreateMap<ProductResource, Product>();
        }
    }
}