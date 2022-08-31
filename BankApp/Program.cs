using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using BankApp.ModelsIdentity;
using BankApp.Services.Interfaces;
using BankApp.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc(options => options.EnableEndpointRouting = false);

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer
(builder.Configuration.GetConnectionString("IdentityConnection")));
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
.AddRoles<IdentityRole>()
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();
builder.Services.AddScoped<IApplicationUserService, ApplicationUserService>();

var app = builder.Build();

app.UseAuthentication();
app.UseStaticFiles();
app.UseMvc(routes => {
    routes.MapRoute(
    name: "default",
    template: "{controller=Login}/{action=Login}/{id?}");
});


app.Run();
