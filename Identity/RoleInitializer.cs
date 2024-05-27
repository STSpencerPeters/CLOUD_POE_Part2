using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace CLOUD_POE_Part2
{
    public static class RoleInitializer
    {
        public static async Task InitializeAsync(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            string adminRole = "Admin";
            string adminUsername = "admin@example.com";
            string adminPassword = "Admin@123";

            // Check if the admin role exists, and create it if it doesn't
            if (!await roleManager.RoleExistsAsync(adminRole))
            {
                await roleManager.CreateAsync(new IdentityRole(adminRole));
            }

            // Check if the admin user exists, and create it if it doesn't
            var adminUser = await userManager.FindByNameAsync(adminUsername);
            if (adminUser == null)
            {
                adminUser = new IdentityUser { UserName = adminUsername, Email = adminUsername };
                var result = await userManager.CreateAsync(adminUser, adminPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, adminRole);
                }
            }
        }
    }
}
