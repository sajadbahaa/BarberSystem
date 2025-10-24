using DataLayer.Entities;
using DTLayer.Data;
using Dtos.UsersDtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repositary.BaseRepo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Repositary
{
    public class UserRepo : Repo<AppUser, int>
    {
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public UserRepo(AppDbContext context, RoleManager<IdentityRole<int>> roleManager, UserManager<AppUser> userManager)

            : base(context)
        {
            _roleManager = roleManager;
            _userManager = userManager;

        }
        public override async Task<AppUser?> GetByUsernameAsync(string userName)
        {
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.UserName == userName);
        }
        public async Task<AppUser?> GetByEmailAsync(string email)
        {
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Email == email);
        }
        public async Task<bool> UsernameOrEmailUsedAsync(int UserID, string Username, string Email)
        {
            return await _dbSet.AsNoTracking()
     .AnyAsync(x =>
            x.Id != UserID &&
            (
                (!string.IsNullOrEmpty(Username) && x.UserName == Username) ||
                (!string.IsNullOrEmpty(Email) && x.Email == Email)
            )
        );
        }


        public async Task<bool> UsernameOrEmailUsedAsync(string Username, string Email)
        {
            return await _dbSet.AsNoTracking()
     .AnyAsync(x =>
         (!string.IsNullOrEmpty(Username) && x.UserName == Username) ||
          (!string.IsNullOrEmpty(Email) && x.Email == Email)
     );
        }

        public async Task<bool> IsActiveAsync(int userID)
        {
            return await _dbSet.AsNoTracking()
     .AnyAsync(x => x.Id == userID && x.IsActive);
        }


        public override async Task<bool> UpdateAsync(AppUser entity)
        {

            var res = await _dbSet.Where(c => c.Id == entity.Id)
                .ExecuteUpdateAsync
                (x => x
                .SetProperty(i => i.UpdateAt, DateTime.Now)
                .SetProperty(i => i.UserName, entity.UserName)
                .SetProperty(i => i.Email, entity.Email)

                );
            return res > 0;
        }


        public async Task<AppUser?> AddUserAsync(AppUser entity, string password)
        {
            // Use UserManager to create user and hash the password internally
            var res = await _userManager.CreateAsync(entity, password);
            return res.Succeeded ? entity : null;
        }



        public override async Task<bool> DeleteAsync(int id)
        {
            var res = await _dbSet.Where(x => x.Id == id).ExecuteUpdateAsync
                (x => x.SetProperty(i => i.IsActive, false));
            return res > 0;
        }

        public override async Task<bool> ActivateAsync(int id)
        {
            var res = await _dbSet.Where(x => x.Id == id).ExecuteUpdateAsync
                (x => x.SetProperty(i => i.IsActive, true));
            return res > 0;
        }

        public async Task<List<AppUser>> GetAllActiveAsync()
        {
            return await _dbSet.AsNoTracking().Where(x => x.IsActive).ToListAsync();
        }

        public async Task<List<AppUser>> GetAllDeactivatedAsync()
        {
            return await _dbSet.AsNoTracking().Where(x => !x.IsActive).ToListAsync();
        }



        //public async Task<List<IdentityUserRole<int>>> GetUsersWithRolesAsync()
        //{
        //    return await _context.UserRoles.ToListAsync();
        //}
        public async Task<List<findUserWithRolesDtos>> GetUsersWithRolesAsync()
        {
            var result = await _context.Users.Join
                (_context.UserRoles
                , user => user.Id
                , ur => ur.UserId, (x, y) => new { UserID = x.Id, RoleID = y.RoleId }
                ).Join(_context.Roles
                , ur => ur.RoleID,
                r => r.Id
                , (x, y) => new { x.UserID, roleName = y.Name }
                ).GroupBy(x => x.UserID).Select(y => new findUserWithRolesDtos { UserID = y.Key, Roles = y.Select(x => x.roleName).ToList() })
                .ToListAsync();

            return result;
            ;

        }

        // ✅ التحقق من وجود الدور
        public async Task<bool> IsRoleExistAsync(string roleName)
        {
            return await _roleManager.RoleExistsAsync(roleName);
        }

        // ✅ إنشاء دور جديد
        public async Task<bool> CreateRoleAsync(string roleName)
        {
            if (!await _roleManager.RoleExistsAsync(roleName))
            {
                var result = await _roleManager.CreateAsync(new IdentityRole<int>(roleName));
                return result.Succeeded;
            }
            return false;
        }

        // ✅ إسناد دور إلى مستخدم
        public async Task<bool> AssignRoleAsync(AppUser user, string roleName)
        {
            // تحقق المستخدم عنده الدور مسبقًا
            if (await _userManager.IsInRoleAsync(user, roleName))
                return false;

            // إضافة الدور
            var result = await _userManager.AddToRoleAsync(user, roleName);
            return result.Succeeded;
        }

        // ✅ إزالة دور من مستخدم
        public async Task<bool> RemoveRoleAsync(AppUser user, string roleName)
        {
            var result = await _userManager.RemoveFromRoleAsync(user, roleName);
            return result.Succeeded;
        }

        // ✅ جلب كل الأدوار
        public async Task<List<IdentityRole<int>>> GetAllRolesAsync()
        {
            return await _roleManager.Roles.AsNoTracking().ToListAsync();
        }



        // ✅ التحقق إذا المستخدم يمتلك دور معين
        public async Task<bool> UserHasRoleAsync(AppUser user, string roleName)
        {
            return await _userManager.IsInRoleAsync(user, roleName);
        }


        public async Task<List<AppUser>> GetUsersInRoleAsync(string roleName)
        {
            var res = await _userManager.GetUsersInRoleAsync(roleName); ;
            return res.ToList();
        }


        public async Task<bool> ChangePasswordAsync(AppUser user, string currentPassword, string newPassword)
        {
            var result = await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);
            return result.Succeeded;
        }

        public async Task<bool> ResetPasswordAsync(AppUser user, string newPassword)
        {
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, token, newPassword);
            return result.Succeeded;
        }
        public async Task<(AppUser?, List<string>?)> LoginAsync(string username,string Password)
        {
            var result = await _context.Users
                .Where(u => u.UserName == username)
                .Join(_context.UserRoles,
                      user => user.Id,
                      ur => ur.UserId,
                      (user, ur) => new { user, ur.RoleId })
                .Join(_context.Roles,
                      combined => combined.RoleId,
                      role => role.Id,
                      (combined, role) => new { combined.user, RoleName = role.Name })
                .GroupBy(x => x.user)
                .Select(g => new
                {
                    User = g.Key,
                    Roles = g.Select(r => r.RoleName).ToList()
                })
                .SingleOrDefaultAsync();

            if (result == null)
                return (null, null);

            if (! await  _userManager.CheckPasswordAsync(result.User, Password)) 
            {
                return (null, null);
            }
            ;
            return (result.User, result.Roles);
        }

    }
}