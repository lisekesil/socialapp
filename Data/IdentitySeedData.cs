using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using socialapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace socialapp.Data
{
    public static class IdentitySeedData
    {
        private const string adminLogin = "admin";
        private const string adminPassword = "Admin12#";

        private const string userFirstName = "Janusz";
        private const string userLastName = "Pawłowski";
        private const string userEmail = "pawjan@wp.pl";
        private const string userName = "January";
        private const string userPassword = "@Qwerty123";

        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var roleManager = (RoleManager<IdentityRole>)scope.ServiceProvider.GetRequiredService(typeof(RoleManager<IdentityRole>));
            var userManager = (UserManager<UserModel>)scope.ServiceProvider.GetRequiredService(typeof(UserManager<UserModel>));
            IdentityResult roleResult;
            foreach (var roleName in Enum.GetValues(typeof(Roles)))
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName.ToString());

                if (!roleExist)
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(roleName.ToString()));
                }
            }

            UserModel adminUser = await userManager.FindByIdAsync(adminLogin);
            if (adminUser == null)
            {
                adminUser = new UserModel()
                {
                    UserName = adminLogin,
                };
                await userManager.CreateAsync(adminUser, adminPassword);
            }
            await userManager.AddToRoleAsync(adminUser, Roles.Admin.ToString());

            UserModel normalUser = await userManager.FindByIdAsync(userName);
            if (normalUser == null)
            {
                normalUser = new UserModel()
                {
                    UserName = userName,
                    FirstName = userFirstName,
                    LastName = userLastName,
                    Email = userEmail,
                };
                await userManager.CreateAsync(normalUser, userPassword);
            }
            await userManager.AddToRoleAsync(normalUser, Roles.User.ToString());

        }
    }
}
