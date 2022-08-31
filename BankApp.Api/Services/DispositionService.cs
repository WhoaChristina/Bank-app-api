using BankApp.Api.Models;
using BankApp.Api.Services.Interfaces;
using BankApp.Api.Repos.Interfaces;
namespace BankApp.Api.Services
{
    public class DispositionService : IDispositionService
    {
        private readonly IDispositionRepo _repo;

        public DispositionService(IDispositionRepo repo)
        {
            _repo = repo;
        }

        public List<Disposition> GetDispositions(int customerId)
        {
            try
            {
                List<Disposition> res = _repo.GetDispositions(customerId);
                return res;
            }
            catch (Exception)
            {
                return null;
            }

        }
    }
}
