using AutoMapper;
using DataLayer.Entities;
using Dtos.RatingsDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Mapper
{
    public class RatingProfile:Profile
    {
public RatingProfile()
        {
            CreateMap<addRatingDtos, Ratings>()
                    .ForMember(x => x.Customer, opt => opt.Ignore())
                    .ForMember(x => x.appointments, opt => opt.Ignore())
    .ForMember(x => x.Barber, opt => opt.Ignore());

            CreateMap<updateRatingDtos, Ratings>()
.ForMember(x => x.RatingID, opt => opt.MapFrom(x=>x.RatingID))

                .ForMember(x => x.Customer, opt => opt.Ignore())
             .ForMember(x => x.appointments, opt => opt.Ignore())
    .ForMember(x => x.Barber, opt => opt.Ignore());


            CreateMap<Ratings,findRatingDtos>()
                .ForMember(x => x.RatingID, opt => opt.MapFrom(x => x.RatingID))
;

            ;



        }
    }
}
