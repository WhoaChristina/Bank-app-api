using BankApp.Api.DTO;
using BankApp.Api.Models;
using BankApp.Api.Services.Interfaces;
using BankApp.Api.Repos.Interfaces;
namespace BankApp.Api.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepo _accountRepo;

        public AccountService(IAccountRepo accountRepo)
        {
            _accountRepo = accountRepo;
        }

        public Account GetAccount(int id)
        {
            return _accountRepo.GetAccount(id);
        }

        public bool UpdateAccount(Account acc)
        {
            return _accountRepo.UpdateAccount(acc);
        }
    }
}
