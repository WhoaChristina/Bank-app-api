using BankApp.Api.Models;
namespace BankApp.Api.Repos.Interfaces
{
    public interface IAccountTypeRepo
    {
        bool CreateAccountTypeRepo(AccountType accountType);
        AccountType GetTypeName(int id);
    }
}
