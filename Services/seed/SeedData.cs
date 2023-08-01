using Domain.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Context;

namespace Services.seed
{
    public class SeedData
    {
        private EmployeeDbContext _context;

        public SeedData(EmployeeDbContext context)
        {
            _context = context;
        }

        //public async void SeedAdminUser()
        //{
        //    var user = new ApplicationUser
        //    {
        //        UserName = "user",
        //        Name = "user",
        //        NormalizedUserName = "USER",
        //        Email = "user@email.com",
        //        NormalizedEmail = "user@email.com",
        //        EmailConfirmed = true,
        //        LockoutEnabled = false,
        //        SecurityStamp = Guid.NewGuid().ToString()
        //    };

        //    var roleStore = new RoleStore<IdentityRole>(_context);

        //    if (!_context.Roles.Any(r => r.Name == "user"))
        //    {
        //        await roleStore.CreateAsync(new IdentityRole { Name = "user", NormalizedName = "user" });
        //    }

        //    if (!_context.Users.Any(u => u.UserName == user.UserName))
        //    {
        //        var password = new PasswordHasher<ApplicationUser>();
        //        var hashed = password.HashPassword(user, "12345678aA@");
        //        user.PasswordHash = hashed;
        //        var userStore = new UserStore<ApplicationUser>(_context);
        //        await userStore.CreateAsync(user);
        //        await _context.SaveChangesAsync();
        //        await userStore.AddToRoleAsync(user, "user");
        //    }

        //    await _context.SaveChangesAsync();
        //}
    }
}

