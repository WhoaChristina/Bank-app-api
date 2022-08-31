using BankApp.Api.Models;
namespace BankApp.Api.Repos.Interfaces
{
    public interface IAccountRepo
    {
        Account GetAccount(int id);
        bool UpdateAccount (Account account);
    }
}
