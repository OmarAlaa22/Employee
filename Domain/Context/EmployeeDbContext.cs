using Domain.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Context
{
    public class EmployeeDbContext:IdentityDbContext<ApplicationUser>
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //string ADMIN_ID = "02174cf0–9412–4cfe - afbf - 59f706d72cf6";
            //string ROLE_ID = "341743f0 - asd2–42de - afbf - 59kmkkmk72cf6";

            ////seed admin role
            //builder.Entity<IdentityRole>().HasData(new IdentityRole
            //{
            //    Name = "superadmin",
            //    NormalizedName = "SUPERADMIN",
            //    Id = ROLE_ID,
            //    ConcurrencyStamp = ROLE_ID
            //});

            ////create user
            //var appUser = new IdentityUser
            //{
            //    Id = ADMIN_ID,
            //    Email = "SuperAdmin@gmail.com",
            //    EmailConfirmed = true,
            //    UserName = "SuperAdmin",
            //    NormalizedUserName = "SUPERADMIN"
            //};

            ////set user password
            //PasswordHasher<IdentityUser> ph = new PasswordHasher<IdentityUser>();
            //appUser.PasswordHash = ph.HashPassword(appUser, "12345aA@");

            ////seed user
            //builder.Entity<IdentityUser>().HasData(appUser);

            ////set user role to admin
            //builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            //{
            //    RoleId = ROLE_ID,
            //    UserId = ADMIN_ID
            //});
        }
    
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Governorate>  governorates { get; set; }
        public DbSet<Center> centers { get; set; }
        public DbSet<EmployeeList> EmployeesList { get; set; }

        public List<EmployeeList> GetAllEmployee()
        {
            return this.EmployeesList.FromSqlRaw("EXECUTE GetEmployeeDetails").ToList();
        }

    }
}
