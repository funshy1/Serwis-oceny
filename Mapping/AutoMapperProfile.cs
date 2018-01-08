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
            CreateMap<Filter, FilterResource>();

            //API to Domain
            CreateMap<FilterResource, Filter>();
        }
    }
}