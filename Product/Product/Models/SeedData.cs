using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Product.Models
{
    public static class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider services)
        {
            var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            // Create roles if they don't exist
            string[] roles = new[] { "Admin", "Manager" };
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new IdentityRole(role));
            }

            // Create Admin user
            var adminUser = await userManager.FindByNameAsync("admin");
            if (adminUser == null)
            {
                adminUser = new IdentityUser { UserName = "admin", Email = "admin@example.com" };
                await userManager.CreateAsync(adminUser, "Admin@123"); // automatically hashes password
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }

            // Create Manager user
            var managerUser = await userManager.FindByNameAsync("manager1");
            if (managerUser == null)
            {
                managerUser = new IdentityUser { UserName = "manager1", Email = "manager1@example.com" };
                await userManager.CreateAsync(managerUser, "Manager@123"); // automatically hashes password
                await userManager.AddToRoleAsync(managerUser, "Manager");
            }
        }
    }
}
