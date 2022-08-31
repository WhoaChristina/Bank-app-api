using BankApp.ModelsIdentity;
namespace BankApp.Services.Interfaces
{
    public interface IApplicationUserService
    {
        Task<ApplicationUser> Login(string username, string password);
        Task<bool> Register(string username, string password, int id, string role);
        Task<bool> GetRole(ApplicationUser user);
    }
}
