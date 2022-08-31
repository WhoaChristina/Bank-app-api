using BankApp.Api.Models;
using BankApp.Api.DTO;

namespace BankApp.Api.Services.Interfaces
{
    public interface ITransactionService
    {
        bool Input(TransactionDTO transaction);
        List<TransactionDTO> GetTransactions(AccountDTO acc);
    }
}
