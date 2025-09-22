using Azure.Identity;
using kreator_pomieszczen.Data;
using kreator_pomieszczen.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata;

namespace kreator_pomieszczen.Services
{
    public class SeedService
    {
        public static async Task SeedDatabase(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<Uzytkownicy>>();
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<SeedService>>();

            try
            {
                logger.LogInformation("Baza Danych uruchamia się...");
                await context.Database.EnsureCreatedAsync();

                logger.LogInformation("Sprawdzanie ról...");
                await AddRoleAsync(roleManager, "Admin");
                await AddRoleAsync(roleManager, "User");

                logger.LogInformation("Sprawdzanie użytkowników...");
                var adminEmail = "admin@codehub.com";
                if (await userManager.FindByEmailAsync(adminEmail) == null)
                {
                    var adminUser = new Uzytkownicy
                    {
                        PelnaNazwa = "Code Hub",
                        UserName = adminEmail,
                        NormalizedUserName = adminEmail.ToUpper(),
                        Email = adminEmail,
                        NormalizedEmail = adminEmail.ToUpper(),
                        EmailConfirmed = true,
                        SecurityStamp = Guid.NewGuid().ToString()
                    };

                    var result = await userManager.CreateAsync(adminUser, "Admin@123");
                    if (result.Succeeded)
                    {
                        logger.LogInformation("Dodano rolle admin do użytkownika admina");
                        await userManager.AddToRoleAsync(adminUser, "Admin");
                    }
                    else
                    {
                        logger.LogError("Błąd podczas tworzenia użytkownika Admin: " + string.Join(", ", result.Errors.Select(e => e.Description)));
                    }
                }

            }
            catch (Exception ex)
            {
                logger.LogError("Wystąpił błąd podczas sprawdzania bazy danych");

            }

        }

        private static async Task AddRoleAsync(RoleManager<IdentityRole> roleManager, string roleName)
        {
            if (!await roleManager.RoleExistsAsync(roleName))
            {
                var result = await roleManager.CreateAsync(new IdentityRole(roleName));
                if (!result.Succeeded)
                {
                    throw new Exception($"Nie udało się utworzyć roli '{roleName}': " + string.Join(", ", result.Errors.Select(e => e.Description)));
                }
            }
        }

    }
}
