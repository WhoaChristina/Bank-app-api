using BankApp.Api.Models;

namespace BankApp.Api.Repos.Interfaces
{
    public interface IDispositionRepo
    {
        List<Disposition> GetDispositions(int customerId);
    }
}
