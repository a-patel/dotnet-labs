#region Imports
using AutoMapper;
using AutoMapperExamples.Api.Domain;
using AutoMapperExamples.Api.Model;
#endregion

namespace AutoMapperExamples.Api.Infrastructure
{
    public class CustomerAutoMapperProfile : Profile
    {
        public CustomerAutoMapperProfile()
        {
            CreateMap<CustomerModel, Customer>()
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.PhoneNumber));

            CreateMap<Customer, CustomerModel>()
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.Phone))
                .ForMember(dest => dest.IsAdult, opt => opt.MapFrom(src => src.Age > 18));

            CreateMap<AddressModel, Address>().ReverseMap();
        }
    }
}



// https://github.com/AutoMapper/AutoMapper/blob/master/docs/Configuration.md
