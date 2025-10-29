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

            // Update Barber + Person Info.
            CreateMap<updateBarberPersonDto, Barbers>()
               .ForMember(x => x.ShopName, opt => opt.MapFrom(x => x.ShopName))
               .ForMember(x => x.Location, opt => opt.MapFrom(x => x.Location))
               .ForMember(x=>x.people,opt=>opt.MapFrom(x=>x.peopleDtos))
               ;

            // update barber Service
            CreateMap<updateBarberServiceDto, BarberServices>()
                .ForMember(x => x.BarberServiceID, opt => opt.MapFrom(x => x.BarberServiceID))
                  .ForMember(x => x.Price, opt => opt.MapFrom(x => x.Price))
                  .ForMember(x => x.Duration, opt => opt.MapFrom(x => x.Duration));

            // find Barber Service
            CreateMap<BarberServices, findBarberServiceDto>()
             .ForMember(x => x.BarberServiceID, opt => opt.MapFrom(x => x.BarberServiceID))
            ;

            // add Barber Service.

            CreateMap<addBarberServiceDto, BarberServices>()
                         .ForMember(x => x.BarberServiceID, opt => opt.Ignore())
                         .ForMember(x => x.barbers, opt => opt.Ignore())
                         .ForMember(x => x.ServicesDetials, opt => opt.Ignore())
                        ;


        }
    }
}
