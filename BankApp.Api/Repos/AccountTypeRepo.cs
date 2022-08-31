using BankApp.Api.Models;
using BankApp.Api.Repos.Interfaces;
namespace BankApp.Api.Repos
{
    public class AccountTypeRepo : IAccountTypeRepo
    {
        private readonly BankAppDataContext _context;

        public AccountTypeRepo(BankAppDataContext context)
        {
            _context = context;
        }

        public bool CreateAccountTypeRepo(AccountType accountType)
        {
            try
            {
                _context.AccountTypes.Add(accountType);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public AccountType GetTypeName(int id)
        {
            try
            {
                AccountType type = _context.AccountTypes.Where(a => a.AccountTypeId == id).SingleOrDefault();
                return type;
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
