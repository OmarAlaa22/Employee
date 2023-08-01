using Domain.Context;
using Domain.Entity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NToastNotify;
using Services.Interfaces;
using Services.Repository;
using Services.seed;
using Services.UniteOfWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
#region Database Connection
builder.Services.AddDbContext<EmployeeDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));
#endregion
#region Identity
builder.Services.AddSession();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.AccessDeniedPath = "/Employee/AssessDenied";
    options.LoginPath = "/Employee/AssessDenied";

});
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("crud", policy => policy.RequireRole("admin"));
    options.AddPolicy("onlysee", policy => policy.RequireRole("user","admin"));
});
#endregion
#region Toaster

builder.Services.AddRazorPages().AddNToastNotifyNoty(new NotyOptions
{
    ProgressBar = true,
    Timeout = 5000
});

#endregion
#region Identity

builder.Services.AddIdentity<ApplicationUser,IdentityRole>().AddEntityFrameworkStores<EmployeeDbContext>().AddDefaultTokenProviders(); ;

#endregion
#region DI
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IGovernorateRepository,GovernorateRepository >();
builder.Services.AddScoped<IUnitOfWork, UniteOfWork>();
builder.Services.AddScoped<ICityRepository, CityRepository>();
builder.Services.AddScoped<ICenterRepository, CenterRepository>();
builder.Services.AddTransient<EmployeeDbContext>();
builder.Services.AddTransient<SeedData>();

#endregion
var app = builder.Build();   
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();
app.UseRouting();
app.UseSession();
app.UseNToastNotify();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Accounts}/{action=Login}/{id?}"
    
  );


app.Run();
