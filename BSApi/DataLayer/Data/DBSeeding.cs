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
        //static async Task EnsureAdminExists(string adminUserName, string Password, string Email, UserManager<AppUser>? roleManager)
        //{
        //    if (await roleManager.FindByNameAsync(adminUserName) == null)
        //    {
        //        var adminUser = new AppUser
        //        {
        //            Email = Email,       // مهم لأن RequireUniqueEmail = true
        //            EmailConfirmed = true,
        //            UserName = adminUserName,
        //        };

        //        var result = await roleManager.CreateAsync(adminUser, Password);
        //        if (result.Succeeded)
        //        {
        //            await roleManager.AddToRoleAsync(adminUser, "Admin");
        //        }
        //    }
        //}
        public static async Task InitializeAsync(this IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();

            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<int>>>();

            // 1️⃣ Check if roles exist first — only seed if empty
            if (!roleManager.Roles.Any())
            {
                string[] roles = { "Admin", "Barber", "Customer", "PendingBarber" };
                foreach (var role in roles)
                    await roleManager.CreateAsync(new IdentityRole<int>(role));
            }

            // 2️⃣ Check if admin already exists
            if (!userManager.Users.Any(u => u.UserName == "admin"))
            {
                var adminUser = new AppUser
                {
                    UserName = "admin",
                    Email = "admin@gmail.com",
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(adminUser, "Admin@123");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }
        }
    }
}
    
