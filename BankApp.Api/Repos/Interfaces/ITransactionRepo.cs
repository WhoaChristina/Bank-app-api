using BankApp.Api.Models;
namespace BankApp.Api.Repos.Interfaces
{
    public interface ITransactionRepo
    {
        bool Input (Transaction transaction);
        List<Transaction> GetTransactions (int accountId);
    }
}
