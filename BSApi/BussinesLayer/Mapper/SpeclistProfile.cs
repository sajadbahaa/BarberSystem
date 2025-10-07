using AutoMapper;
using DataLayer.Entities;
using Dtos.SpeclisysDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Mapper
{
    public  class SpeclistProfile: Profile
    {

        public SpeclistProfile()
        {
            CreateMap<Speclitys, findSpecliystDtos>()
.ForMember(x => x.Enabled, i => i.MapFrom(x=>x.Enabled?"Active":"Not Active"))
                ;


            CreateMap<addSpeclistNewDtos, Speclitys>()
                .ForMember(x => x.Enabled, i => i.Ignore())
                .ForMember(x => x.SpecilityID, i => i.Ignore())
.ForMember(x => x.Description, i => i.MapFrom(y => string.IsNullOrEmpty(y.Description) ? null : y.Description))
.ForMember(x => x.ServicesDetials, i => i.Ignore());


            CreateMap<updateSpeclistDtos, Speclitys>()
                .ForMember(x => x.Enabled, i => i.Ignore())
                .ForMember(x => x.SpecilityID, i => i.MapFrom(x=>x.SpecilityID))
.ForMember(x => x.Description, i => i.MapFrom(y => string.IsNullOrEmpty(y.Description) ? null : y.Description))
.ForMember(x => x.ServicesDetials, i => i.Ignore());


        }
    }
}
