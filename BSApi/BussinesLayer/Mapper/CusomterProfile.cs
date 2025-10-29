using AutoMapper;
using DataLayer.Entities;
using Dtos.BarbersDtos;
using Dtos.CustomerDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Mapper
{
    public  class CusomterProfile:Profile
    {
        public CusomterProfile() 
        {
            // find
            CreateMap<Customers,findCustomerDtos>()
             .ForMember(x=>x.userID,opt=>opt.MapFrom(x=>x.UserID))
.ForMember(x => x.FullName, opt => opt.MapFrom(x => x.person.FirstName + ' ' + x.person.SecondName + ' ' + x.person.LastName))
             .ForMember(x=>x.userID,opt=>opt.MapFrom(x=>x.UserID))
.ForMember(x => x.personID, opt => opt.MapFrom(x => x.PersonID))

             ;


            // update
            // Update Barber + Person Info.
            CreateMap<updateCustomerPersonDto, Customers>()
               .ForMember(x => x.UserID, opt => opt.MapFrom(x => x.userID))
               .ForMember(x => x.person, opt => opt.MapFrom(x => x.peopleDtos));
               ;

            // add 
            CreateMap<addCustomerPersonDto, Customers>()
             .ForMember(x => x.CustomerID, opt => opt.Ignore())
             .ForMember(x => x.UserID, opt => opt.MapFrom(x => x.UserID))
             .ForMember(x => x.PersonID, opt => opt.MapFrom(x => x.personID))
             .ForMember(x => x.person, opt => opt.MapFrom(x => x.peopleDtos))
             .ForMember(x => x.user, opt => opt.Ignore());
             ;
            ;


        }
    }
}
