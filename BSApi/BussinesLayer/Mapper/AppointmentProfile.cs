using AutoMapper;
using DataLayer.Entities;
using Dtos.AppointmentDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Mapper
{
    public  class AppointmentProfile:Profile
    {
        public AppointmentProfile()
        {
            CreateMap<Appointments, findAppointmentDtos>()
                .ForMember(x => x.AppointmentID, opt => opt.MapFrom(y => y.AppointmentID))
                .ForMember(x => x.Status, opt => opt.MapFrom(y => y.status.ToString()));

            CreateMap<addAppointmentDtos, Appointments>()
                        .ForMember(x => x.AppointmentID, opt => opt.Ignore())
                        .ForMember(x => x.barberServices, opt => opt.Ignore())
                        .ForMember(x => x.customer, opt => opt.Ignore())
                        .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.StartDate.Add(src.Duration)));


            CreateMap<updateAppointmentDtos, Appointments>()
                       .ForMember(x => x.AppointmentID, opt => opt.MapFrom(x=>x.AppointmentID))
                       .ForMember(x => x.barberServices, opt => opt.Ignore())
                       .ForMember(x => x.customer, opt => opt.Ignore())
                     .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.StartDate.Add(src.Duration)));

            ;


        }
    }
}
