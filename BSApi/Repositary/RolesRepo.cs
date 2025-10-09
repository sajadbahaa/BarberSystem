using DataLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repositary
{
    public class RolesRepo
    {
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public RolesRepo(RoleManager<IdentityRole<int>> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
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


    }
}
