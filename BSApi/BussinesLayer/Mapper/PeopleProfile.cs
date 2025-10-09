using AutoMapper;
using DataLayer.Entities;
using Dtos.PeopleDtos;



namespace BsLayer.maaper
{
    public  class PeopleProfile : Profile
    {

        public PeopleProfile() 
        {
            CreateMap<People, FindPeopleDtos>()
                .ForMember(x => x.Enabled, opt => opt.MapFrom(x => x.Enabled ? "Yes" : "No"))
                            .ForMember(x => x.FullName, opt => opt.MapFrom(x => x.FirstName + ' ' + x.SecondName + ' ' + x.LastName))
.ForMember(x => x.PersonID, opt => opt.MapFrom(x => x.PersonID))
    .ForMember(dest => dest.Phone,
                       opt => opt.MapFrom(src => src.Phone ?? string.Empty))
            
            ;


            CreateMap<AddPeopleDtos, People>()
           
    .ForMember(dest => dest.Phone,
                       opt => opt.MapFrom(src => string.IsNullOrEmpty(src.Phone) ? null : src.Phone))

            .ForMember(dest => dest.Enabled, opt => opt.Ignore());
            ;



            CreateMap<UpdatePeopleDtos, People>()
           .ForMember(x => x.PersonID, opt => opt.MapFrom(x=>x.PersonID))
    .ForMember(dest => dest.Phone,
                       opt => opt.MapFrom(src => string.IsNullOrEmpty(src.Phone) ? null : src.Phone))
                        
            ;




        }

    }
}
