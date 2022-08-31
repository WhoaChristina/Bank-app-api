using BankApp.Api.Services.Interfaces;
using BankApp.Api.Models;
using BankApp.Api.Repos.Interfaces;
using BankApp.Api.DTO;
namespace BankApp.Api.Services
{
    public class AccountTypeService : IAccountTypeService
    {
       private readonly IAccountTypeRepo _accountTypeRepo;

        public AccountTypeService(IAccountTypeRepo accountTypeRepo)
        {
            _accountTypeRepo = accountTypeRepo;
        }

        public bool CreateAccountTypeService(AccountTypeDTO acc)
        {
            AccountType newType = new AccountType()
            {
                TypeName = acc.TypeName,
                Description = acc.Description,
                Interest = acc.Interest
            };
            bool res = _accountTypeRepo.CreateAccountTypeRepo(newType);
            return res;
        }

        public AccountType GetTypeName(int id)
        {
            try
            {
                AccountType accountType = _accountTypeRepo.GetTypeName(id);
                return accountType;
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
