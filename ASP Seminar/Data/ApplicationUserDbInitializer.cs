using Microsoft.AspNetCore.Identity;

namespace ASP_Seminar.Data
{
    public static class ApplicationUserDbInitializer
    {  
        public static void SeedUsers(UserManager<AppUser> userManager)
        {
            AppUser user = new AppUser()
            {
                UserName = "b@b.a",
                Email = "b@b.a"
            };

            var result = userManager.CreateAsync(user, "sifrica1").Result;

            if( result.Succeeded )
            {
                userManager.AddToRoleAsync(user, "Admin").Wait();
            }
        }
    }
}