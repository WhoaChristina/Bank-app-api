using BankApp.Api.Models;
using BankApp.Api.Services.Interfaces;
using BankApp.Api.Repos.Interfaces;
using BankApp.Api.DTO;
namespace BankApp.Api.Services
{
    public class LoanService : ILoanService
    {
        private readonly ILoanRepo _loanRepo;

        public LoanService(ILoanRepo loanRepo)
        {
            _loanRepo = loanRepo;
        }

        public bool CreateLoanService(LoanDTO loan)
        {
            Loan newLoan = new Loan()
            {
                AccountId = loan.AccountId,
                Date = loan.Date,
                Amount = loan.Amount,
                Duration = loan.Duration,
                Payments = loan.Payments,
                Status = loan.Status
            };
            bool res = _loanRepo.CreateLoanRepo(newLoan);
            return res;
        }
    }
}
