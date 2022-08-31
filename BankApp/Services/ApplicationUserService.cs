using BankApp.ModelsIdentity;
using BankApp.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace BankApp.Services
{
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public ApplicationUserService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<bool> GetRole(ApplicationUser user)
        {
            bool isAdmin = await _userManager.IsInRoleAsync(user, "Admin");
            return isAdmin;
        }

        public async Task<ApplicationUser> Login(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user != null && await _userManager.CheckPasswordAsync(user, password))
            {
                return user;
            }
            return null;
        }

        public async Task<bool> Register(string username, string password, int id, string role)
        {
            ApplicationUser newUser = new ApplicationUser()
            {
                CustomerID = id,
                UserName = username
            };

            var res = await _userManager.CreateAsync(newUser, password);

            if (res.Succeeded)
            {
                var roleExists = await _roleManager.RoleExistsAsync(role);
                if (!roleExists)
                {
                    var roleres = await _roleManager.CreateAsync(new IdentityRole(role));
                }
                var currentUser = await _userManager.FindByNameAsync(newUser.UserName);
                var roleresult = await _userManager.AddToRoleAsync(newUser, role);

                return true;
            }
            return false;
        }
    }
}
