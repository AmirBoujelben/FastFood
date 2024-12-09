using Microsoft.AspNetCore.Identity;

namespace FastFood.Data
{
    public class DbInitializer
    {
        public static async Task SeedDataAsync(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

            // Seed roles
            var roles = new[] { "Admin", "Manager", "Customer" };
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            // Seed default admin user
            var defaultUserEmail = "admin@gmail.com";
            var defaultUser = await userManager.FindByEmailAsync(defaultUserEmail);
            if (defaultUser == null)
            {
                var user = new IdentityUser
                {
                    UserName = defaultUserEmail,
                    Email = defaultUserEmail,
                    EmailConfirmed = true,
                };

                // Create user and assign the "Admin" role
                var result = await userManager.CreateAsync(user, "Admin@123");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Admin");
                }
            }
        }
    }
}
