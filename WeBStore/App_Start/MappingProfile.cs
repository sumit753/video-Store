using AutoMapper;
using WeBStore.Dto;
using WeBStore.Models;

namespace WeBStore.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Domain to DTO
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<Genre, GenresDto>();

            //Dto To Domain
            Mapper.CreateMap<CustomerDto, Customer>().ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<MovieDto, Movie>().ForMember(m => m.Id, opt => opt.Ignore());
        }
    }
}