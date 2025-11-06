using AutoMapper;
using AutoMapper.QueryableExtensions;
using DataLayer.Entities;
using Dtos.ApplicationsDtos;
using Dtos.AppointmentDtos;
using Dtos.UsersDtos;
using Microsoft.EntityFrameworkCore;
using Repositary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer
{
    public  class AppUserService
    {
        readonly UserRepo _repo;
        readonly IMapper _mapper;

        public AppUserService(UserRepo repo, IMapper mapper )
        {
            _repo = repo;
            _mapper = mapper;
           
        }

        //public async Task<List<findUserDtos>> GetAllWithPaginationAsync(int pageNumber, int pageSize)
        //{
        //    return _mapper.Map<List<findUserDtos>>(await _repo.GetAllWithPaginationAsync(pageNumber, pageSize));
        //}

        public async Task<List<findUserDtos>> GetAllWithPaginationAsync(int pageNumber, int pageSize)
        {
            return await _repo.GetAllWithPagination(pageNumber, pageSize) // IQueryable<T>
                .ProjectTo<findUserDtos>(_mapper.ConfigurationProvider) // Project to DTO
                .ToListAsync(); 
            
            // تنفيذ الاستعلام داخل SQL
        }


        // find UserInfoByID
        public async Task<findUserDtos?> FindUserByIDAsync(int userID)
        {
            var res =  await _repo.GetByIdAsync(userID);
            return _mapper.Map<findUserDtos>(res);
        }

        // findUserInfoByUserName
        public async Task<findUserDtos?> FindUserByUsernameAsync(string userName)
        {
            var res = await _repo.GetByUsernameAsync(userName);
            return _mapper.Map<findUserDtos>(res);
        }

        // findUserInfoByEmail
        public async Task<findUserDtos?> FindUserByEmailAsync(string Email)
        {
            var res = await _repo.GetByEmailAsync(Email);
            return _mapper.Map<findUserDtos>(res);
        }

        // find AllUsers
        // findUserInfoByUserName
       // get All User ACtive
        public async Task<List<findUserDtos>?> GetAllUsersAsync()
        {
            var res = await _repo.GetAllAsync();
            return _mapper.Map<List<findUserDtos>>(res); ;
        }
        // get All User ACtive
        public async Task<List<findUserDtos>?> GetAllActiveAsync()
        {
            var res = await _repo.GetAllActiveAsync();
            return _mapper.Map<List<findUserDtos>>(res);
        }

        // get All User ACtive

        public async Task<List<findUserDtos>?> GetAllDeactivatedAsync()
        {
            var res = await _repo.GetAllDeactivatedAsync();
            return _mapper.Map<List<findUserDtos>>(res); ;
        }
        // get Get User With Rules.
        public async Task<List<findUserWithRolesDtos>> GetAllUserWithRolesAsync()
        {
            return await _repo.GetUsersWithRolesAsync();
        }

        // add User Async

        // Create Method Pending Barber.

        public async Task<bool> AddPendingBarberAsync(addUserDtos dto)
        {
            // steps : 
            
            // check email, userName not used before.
            // 
            // 1 : add User succss
            // 2 : Get Id Of PendingBarber 
            // 3 : add Role for User.
            await _repo.BeginTransactionAsync();

            // 1 
            if (await _repo.UsernameOrEmailUsedAsync(dto.UserName,dto.Email))
            {
                await _repo.RollbackAsync();
                return false;
            }

            // 2 add User

            var user = 
                await _repo.AddUserAsync(_mapper.Map<AppUser>(dto),dto.PasswordHash);

            if (user  == null)
            {
                await _repo.RollbackAsync();
                return false;
            }
            // 3 : add Role

            var res = await _repo.AssignRoleAsync(user, "PendingBarber");

            if (res==false)
            {
                await _repo.RollbackAsync();
                return false;
            }
            await _repo.CommitAsync();
            return true;
        }
        public async Task<bool> UpdateUserAsync(updateUserDtos dto)
        {
            await _repo.BeginTransactionAsync();

            // 1 
            if (await _repo.UsernameOrEmailUsedAsync(dto.Id,dto.UserName, dto.Email))
            {
                await _repo.RollbackAsync();
                return false;
            }

            // 2 add User

            bool res = await _repo.UpdateAsync(_mapper.Map<AppUser>(dto));

            if (!res )
            {
                await _repo.RollbackAsync();
                return false;
            }
            await _repo.CommitAsync();
            return true;
        }
    
        public async Task<bool> ChangePassword(ChangePasswordDto dto)
        {
            var user = await _repo.GetByIdAsync(dto.UserId);
            if (user == null)
            {
                return false;
            }
            var res = await _repo.ChangePasswordAsync(user, dto.CurrentPassword, dto.Password);

                return res;
        }

        public async Task<bool> ResetPassword(ResetPasswordDto dto)
        {
            var user = await _repo.GetByIdAsync(dto.UserId);
            if (user == null)
            {
                return false;
            }
            var res = await _repo.ResetPasswordAsync(user,dto.NewPassword);

            return res;
        }

        public async Task<bool> ActivateeAsync(int ID)
        {
            return await _repo.ActivateAsync(ID);
        }

        public async Task<bool> DeleteAsync(int ID)
        {
            return await _repo.DeleteAsync(ID);
        }

        public async Task<(AppUser?, List<string>?)> LogainAsync(string UserName,string Password)
        {
            //await _repo.LoginAsync(UserName); ;
            var result = await _repo.LoginAsync(UserName,Password);

            // result هو (AppUser?, List<string>?)
            if (result.Item1 == null)
                return (null, null);
            return (result.Item1, result.Item2);
        }




    }
}
