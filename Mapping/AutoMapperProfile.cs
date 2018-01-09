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
            CreateMap<Product, SaveProductResource>();

            //API to Domain
            CreateMap<ProductQueryResource, ProductQuery>();
            CreateMap<ProductResource, Product>();
            CreateMap<SaveProductResource, Product>()
                .ForMember(p => p.Id, opt => opt.Ignore())
                .ForMember(p => p.CategoryId, opt => opt.MapFrom(srp => srp.CategoryId));
            
        }
    }
}