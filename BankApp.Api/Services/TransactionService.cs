using BankApp.Api.DTO;
using BankApp.Api.Models;
using BankApp.Api.Services.Interfaces;
using BankApp.Api.Repos.Interfaces;
namespace BankApp.Api.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepo _transactionRepo;
        private readonly IAccountService _accountService;

        public TransactionService(ITransactionRepo transactionRepo, IAccountService accountService)
        {
            _transactionRepo = transactionRepo;
            _accountService = accountService;
        }

        public List<TransactionDTO> GetTransactions(AccountDTO acc)
        {
            List<TransactionDTO> res = new List<TransactionDTO>();
            try
            {
                List<Transaction> transactions = _transactionRepo.GetTransactions(acc.AccountId);
                foreach (var trans in transactions)
                {
                    res.Add(new TransactionDTO() { AccountId = trans.AccountId, Date = trans.Date, Type = trans.Type, Operation = trans.Operation, Amount = trans.Amount, Balance = trans.Balance, Symbol = trans.Symbol, Bank = trans.Bank, Account = trans.Account });
                }
                return res;
            }
            catch (Exception)
            {

                return null;
            }

        }

        public bool Input(TransactionDTO transaction)
        {
            int toAcc = int.Parse(transaction.Account);
            bool inputOutput;
            Account resOut = _accountService.GetAccount(transaction.AccountId);
            Account resIn = _accountService.GetAccount(toAcc);
            if (resOut != null && resIn != null)
            {
                resOut.Balance = resOut.Balance - transaction.Amount;
                resIn.Balance = resIn.Balance + transaction.Amount;

                try
                {
                    bool outAcc = _accountService.UpdateAccount(resOut);
                    bool inAcc = _accountService.UpdateAccount(resIn);
                    inputOutput = outAcc && inAcc;
                }
                catch (Exception)
                {
                    inputOutput = false;
                }
            }
            else
            {
                inputOutput = false;
            }


            Transaction trans = new Transaction()
            {
                AccountId = transaction.AccountId,
                Date = transaction.Date,
                Type = transaction.Type,
                Operation = transaction.Operation,
                Amount = transaction.Amount,
                Balance = resOut.Balance,
                Symbol = transaction.Symbol,
                Bank = transaction.Bank,
                Account = transaction.Account,
            };
            bool resTrans = _transactionRepo.Input(trans);
            return inputOutput && resTrans;
        }
    }
}
