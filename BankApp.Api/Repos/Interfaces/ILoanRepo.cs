using BankApp.Api.Models;
namespace BankApp.Api.Repos.Interfaces
{
    public interface ILoanRepo
    {
        bool CreateLoanRepo(Loan loan);
    }
}
