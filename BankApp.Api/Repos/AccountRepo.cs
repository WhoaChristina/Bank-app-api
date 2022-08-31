using BankApp.Api.Repos.Interfaces;
using BankApp.Api.Models;
namespace BankApp.Api.Repos
{
    public class AccountRepo : IAccountRepo
    {
        private readonly BankAppDataContext _context;

        public AccountRepo(BankAppDataContext context)
        {
            _context = context;
        }

        public Account GetAccount(int id)
        {
            try
            {
                Account acc = _context.Accounts.Where(a => a.AccountId == id).SingleOrDefault();
                return acc;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public bool UpdateAccount(Account account)
        {
            try
            {
                _context.Accounts.Update(account);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
