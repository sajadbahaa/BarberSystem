using DataLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Data
{
   static public class DBSeeding
    {
        static async Task EnsureAdminExists(string adminUserName, string Password, string Email, UserManager<AppUser>? roleManager)
        {
            if (await roleManager.FindByNameAsync(adminUserName) == null)
            {
                var adminUser = new AppUser
                {
                    Email = Email,       // مهم لأن RequireUniqueEmail = true
                    EmailConfirmed = true,
                    UserName = adminUserName,
                };

                var result = await roleManager.CreateAsync(adminUser, Password);
                if (result.Succeeded)
                {
                    await roleManager.AddToRoleAsync(adminUser, "Admin");
                }
            }
        }
        public static async Task SeedRolesAsync(this IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();

            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole<int>>>();

            string[] roles = new[] { "Admin", "Barber", "Customer","PendingBarber" };
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new IdentityRole<int>(role));
            }

            // 2️⃣ إنشاء Admin تلقائي إذا لم يكن موجود
            string adminUserName = "admin";
            string adminPassword = "Admin@123"; // يمكنك تغييره لاحقًا
            await EnsureAdminExists(adminUserName, adminPassword, "admin@gmail.com", userManager);
            
            }
        }
    }
