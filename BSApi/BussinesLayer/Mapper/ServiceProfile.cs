using AutoMapper;
using DataLayer.Entities;
using Dtos.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Mapper
{
    public  class ServiceProfile: Profile
    {
        public ServiceProfile() 
        {
            CreateMap<Servics, findServicesDtos>()
                .ForMember(x => x.Enabled, i => i.MapFrom(x => x.Enabled ? "Active" : "Not Active"))
                ;
            CreateMap<Servics, findServicesDetialsDtos>()
                .ForMember(x => x.Enabled, i => i.MapFrom(x => x.Enabled ? "Active" : "Not Active"))
                .ForMember(x=>x.SpeclizeID,opt=>opt.MapFrom(x=>x.servicesDetials.SpecilityID))
                ;

            CreateMap<addServicesDtos, Servics>()

                .ForMember(x => x.Enabled, i => i.Ignore())
                .ForMember(x => x.servicesDetials, i => i.Ignore())
                .ForMember(x => x.ServiceID, i => i.Ignore())
                ;


            CreateMap<updateServiceDtos, Servics>()

               .ForMember(x => x.Enabled, i => i.Ignore())
               .ForMember(x => x.servicesDetials, i => i.Ignore())
               .ForMember(x => x.ServiceID, i => i.MapFrom(x=>x.ServiceID))
               ;




        }
    }
}
