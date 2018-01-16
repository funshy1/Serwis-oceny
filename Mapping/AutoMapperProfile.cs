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
            CreateMap<User, UserResource>()
                .ForMember(ur => ur.UserId, opt => opt.MapFrom(u => u.user_id))
                .ForMember(ur => ur.LastLogin, opt => opt.MapFrom(u => u.last_login))
                .ForMember(ur => ur.UpdatedAt, opt => opt.MapFrom(u => u.updated_at))
                .ForMember(ur => ur.UserMetadata, opt => opt.MapFrom(u => u.user_metadata));

            //API to Domain
            CreateMap<ProductQueryResource, ProductQuery>();
            CreateMap<ProductResource, Product>();
            CreateMap<UserResource, SaveUserResource>()
                .ForMember(sur => sur.user_metadata, opt => opt.MapFrom(ur => ur.UserMetadata));
            CreateMap<UserResource, User>()
                .ForMember(u => u.user_id, opt => opt.MapFrom(ur => ur.UserId))
                .ForMember(u => u.last_login, opt => opt.MapFrom(ur => ur.LastLogin))
                .ForMember(u => u.updated_at, opt => opt.MapFrom(ur => ur.UpdatedAt))
                .ForMember(u => u.user_metadata, opt => opt.MapFrom(ur => ur.UserMetadata));
            CreateMap<SaveProductResource, Product>()
                .ForMember(p => p.Id, opt => opt.Ignore())
                .ForMember(p => p.CategoryId, opt => opt.MapFrom(srp => srp.CategoryId));
            
        }
    }
}