using BankApp.Api.Models;
using BankApp.Api.Repos.Interfaces;
namespace BankApp.Api.Repos
{
    public class LoanRepo : ILoanRepo
    {
        private readonly BankAppDataContext _context;

        public LoanRepo(BankAppDataContext context)
        {
            _context = context;
        }
        public bool CreateLoanRepo(Loan loan)
        {
            try
            {
                _context.Loans.Add(loan);
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
