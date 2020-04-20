using ConsultingDayDemo.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace ConsultingDayDemo.SeedData
{
    public class ApplivationDbContextSeeder
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly ApplicationDbContext dbContext;

        public ApplivationDbContextSeeder(IServiceProvider serviceProvider, ApplicationDbContext dbContext)
        {
            this.userManager = serviceProvider.GetService<UserManager<IdentityUser>>();
            this.roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();
            this.dbContext = dbContext;
        }
        public  async Task SeedDataAsync()
        {
            
            await SeedUsersAsync();
            await SeedRoleAsync();
            await SeedUserToRolesAsync();
        }

        private  async Task SeedUserToRolesAsync()
        {
            var user = await userManager.FindByNameAsync("Peter");
            var role = await roleManager.FindByNameAsync("Admin");

            var exists = this.dbContext.UserRoles.Any(x => x.UserId == user.Id && x.RoleId == role.Id);
            if (exists)
            {
                return;
            }

            dbContext.UserRoles.Add(new IdentityUserRole<string>
            {
                RoleId = role.Id,
                UserId = user.Id
            });

            await dbContext.SaveChangesAsync();
        }

        private async Task SeedRoleAsync()
        {
            var role = await roleManager.FindByNameAsync("Admin");
            if (role != null)
            {
                return;
            }

            await roleManager.CreateAsync(new IdentityRole
            {
                Name = "Admin"
            });
        }

        private async Task SeedUsersAsync()
        {
            var user =await userManager.FindByNameAsync("Peter");
            if (user != null)
            {
                return;
            }

            var result = await userManager.CreateAsync(new IdentityUser
            {
                UserName = "Peter",
                Email = "Peter@abv.bg",
                EmailConfirmed = true,
            },
            "qwerty");

        }
    }
}
