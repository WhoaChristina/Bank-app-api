using BankApp.Api.Models;
using BankApp.Api.DTO;
namespace BankApp.Api.Services.Interfaces
{
    public interface IAccountTypeService
    {
        bool CreateAccountTypeService(AccountTypeDTO acc);
        AccountType GetTypeName(int id);
    }
}
