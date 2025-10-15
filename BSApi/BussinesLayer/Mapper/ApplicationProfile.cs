using AutoMapper;
using DataLayer.Entities;
using Dtos.ApplicationsDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Mapper
{
    public  class ApplicationProfile:Profile
    {
    public ApplicationProfile()
        {
            /// Find By Application 
            CreateMap<BarberApplications, findApplicationDtos>()
                .ForMember(x=>x.ApplicationID,opt=>opt.MapFrom(opt=>opt.ApplicationID))
                .ForMember(x => x.Status, opt => opt.MapFrom(opt => opt.Status.ToString()))
                ;

            /// Find By Temp Barber Services 
            CreateMap<TempBarberServices, findTempBarberServiceGeneralDtos>()
                .ForMember(x => x.TempServiceID, opt => opt.MapFrom(opt => opt.TempServiceID));
            
            ;

            /// Find By History Application
            CreateMap<ApplicationsHistory, findApplicationHistotyDtos>()
                .ForMember(x => x.HistoryID, opt => opt.MapFrom(opt => opt.HistoryID));

            ;







            /// add Application 
            CreateMap<addApplicationDtos, BarberApplications>()
                .ForMember(x => x.ApplicationID, opt => opt.Ignore())
                .ForMember(x => x.Reason, opt => opt.Ignore())
                .ForMember(x => x.TempBarberServices, opt => opt.Ignore())
                .ForMember(x => x.UpdateAt, opt => opt.Ignore())
                .ForMember(x => x.applicationsHistories, opt => opt.Ignore())
                .ForMember(x => x.CreatAt, opt => opt.Ignore())
                .ForMember(x => x.person, opt => opt.Ignore())
                .ForMember(x => x.user, opt => opt.Ignore())
                ;


            // add Temp services

            CreateMap<addTempBarberServiceDtos,TempBarberServices>()
                .ForMember(x => x.barberApplication, opt => opt.Ignore())
                .ForMember(x => x.servicesDetials, opt => opt.Ignore());


            


            /// update Application 
            CreateMap<updateApplicationDtos, BarberApplications>()
                .ForMember(x => x.ApplicationID, opt => opt.MapFrom(opt => opt.ApplicationID))
                .ForMember(x => x.Reason, opt => opt.Ignore())
                .ForMember(x => x.TempBarberServices, opt => opt.Ignore())
                .ForMember(x => x.UpdateAt, opt => opt.Ignore())
                .ForMember(x => x.applicationsHistories, opt => opt.Ignore())
                .ForMember(x => x.CreatAt, opt => opt.Ignore())
                .ForMember(x => x.person, opt => opt.Ignore())
                .ForMember(x => x.user, opt => opt.Ignore())
                ;



            // update Temp services
            CreateMap<updateTempBarberServiceDtos, TempBarberServices>()
                .ForMember(x => x.TempServiceID, opt => opt.MapFrom(x=>x.TempServiceID))
                .ForMember(x => x.barberApplication, opt => opt.Ignore())
                .ForMember(x => x.servicesDetials, opt => opt.Ignore())
                .ForMember(x => x.ApplicationID, opt => opt.Ignore())




            ;
        }
    }
}
