using BankApp.Api.DTO;
namespace BankApp.Api.Services.Interfaces
{
    public interface ILoanService
    {
        bool CreateLoanService(LoanDTO loan);
    }
}
