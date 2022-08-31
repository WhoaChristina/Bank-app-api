using BankApp.Api.Models;
using BankApp.Api.Repos.Interfaces;

namespace BankApp.Api.Repos
{
    public class TransactionRepo : ITransactionRepo
    {
        private readonly BankAppDataContext _context;

        public TransactionRepo(BankAppDataContext context)
        {
            _context = context;
        }

        public List<Transaction> GetTransactions(int accountId)
        {
            try
            {
                List<Transaction> res = _context.Transactions.Where(t => t.AccountId == accountId || t.Account == accountId.ToString()).ToList();
                return res;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public bool Input(Transaction transaction)
        {
            try
            {
                _context.Transactions.Add(transaction);
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
