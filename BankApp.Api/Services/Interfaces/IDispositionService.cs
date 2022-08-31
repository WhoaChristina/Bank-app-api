using BankApp.Api.Models;
namespace BankApp.Api.Services.Interfaces
{
    public interface IDispositionService
    {
        List<Disposition> GetDispositions(int customerId);
    }
}
