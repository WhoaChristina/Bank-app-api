using BankApp.Api.Models;
using BankApp.Api.Repos.Interfaces;

namespace BankApp.Api.Repos
{
    public class DispositionRepo : IDispositionRepo
    {
        private readonly BankAppDataContext _context;

        public DispositionRepo(BankAppDataContext context)
        {
            _context = context;
        }
        public List<Disposition> GetDispositions(int customerId)
        {
            try
            {
                List<Disposition> res = _context.Dispositions.Where(d => d.CustomerId == customerId).ToList();
                return res;
            }
            catch (Exception)
            {
                return null;
            }

        }
    }
}
