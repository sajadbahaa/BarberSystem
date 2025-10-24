using AutoMapper;
using DataLayer.Entities;
using Dtos.BarbersDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Mapper
{
    public class BarberProfile : Profile
    {
        public BarberProfile()
        {
            CreateMap<Barbers, findBarberDtos>()
                .ForMember(x => x.FullName, opt => opt.MapFrom(x => x.people.FirstName + ' ' + x.people.SecondName + ' ' + x.people.LastName));

            CreateMap<updateBarberPersonDto, Barbers>()
               .ForMember(x => x.BarberID, opt => opt.MapFrom(x => x.BarberID))
               .ForMember(x => x.ShopName, opt => opt.MapFrom(x => x.BarberID))
               .ForMember(x => x.Location, opt => opt.MapFrom(x => x.Location))
               .ForMember(x=>x.people,opt=>opt.MapFrom(x=>x.peopleDtos))
               ;

            CreateMap<updateBarberServiceDto, BarberServices>()
                .ForMember(x => x.BarberServiceID, opt => opt.MapFrom(x => x.BarberServiceID))
                  .ForMember(x => x.Price, opt => opt.MapFrom(x => x.Price))
                  .ForMember(x => x.Duration, opt => opt.MapFrom(x => x.Duration));

            CreateMap<BarberServices, findBarberServiceDto>()
             .ForMember(x => x.BarberServiceID, opt => opt.MapFrom(x => x.BarberServiceID))
            ;



        }
    }
}
