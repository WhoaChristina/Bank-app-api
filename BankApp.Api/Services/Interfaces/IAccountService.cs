using BankApp.Api.DTO;
using BankApp.Api.Models;

namespace BankApp.Api.Services.Interfaces
{
    public interface IAccountService
    {
        Account GetAccount(int id);
        bool UpdateAccount(Account acc);
    }
}
