using AutoMapper;
using DataLayer.Entities;
//using DataLayer.Migrations;
using Dtos.UsersDtos;
using Microsoft.EntityFrameworkCore.Migrations.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Mapper
{
    public  class UserProfile:Profile
    {
        public UserProfile()
        {

            CreateMap<addUserDtos, AppUser>()

                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.IsActive, opt => opt.Ignore())
                    .ForMember(x => x.Email, opt => opt.MapFrom(x => !string.IsNullOrEmpty(x.Email) ? x.Email : null))
                ;                ;


            CreateMap<updateUserDtos, AppUser>()

    .ForMember(x => x.Id, opt => opt.MapFrom(x=>x.Id))
    .ForMember(x => x.Email, opt => opt.MapFrom(x =>!string.IsNullOrEmpty(x.Email)?x.Email:null))
    ;



            CreateMap<ChangePasswordDto, AppUser>()

.ForMember(x => x.Id, opt => opt.MapFrom(x => x.UserId))
.ForMember(x => x.PasswordHash, opt => opt.MapFrom(x => x.Password))
;

            CreateMap<ResetPasswordDto, AppUser>()

.ForMember(x => x.Id, opt => opt.MapFrom(x => x.UserId))
.ForMember(x => x.PasswordHash, opt => opt.MapFrom(x => x.NewPassword))

;


            CreateMap<AppUser, findUserDtos>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
.ForMember(x => x.UserName, opt => opt.MapFrom(x => x.UserName))
.ForMember(x => x.IsActive, opt => opt.MapFrom(x => x.IsActive ? "Active" : "Not Active"));


            CreateMap<AppUser, findUserWithRolesDtos>()
                .ForMember(x => x.UserID, opt => opt.MapFrom(x => x.Id))


;

            CreateMap<AppUser, LoginDtos>()
                .ForMember(x => x.UserName, opt => opt.MapFrom(x => x.UserName))
.ForMember(x => x.Password, opt => opt.MapFrom(x => x.PasswordHash));
;


            CreateMap<AppUser, UserRolesDto>()
     .ForMember(x => x.UserId, opt => opt.MapFrom(x => x.Id))
.ForMember(x => x.UserName, opt => opt.MapFrom(x => x.UserName))
;




        }


    }
}
