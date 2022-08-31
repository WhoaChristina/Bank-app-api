using BankApp.Api.Models;
using BankApp.Api.Repos.Interfaces;
namespace BankApp.Api.Repos
{
    public class CustomerRepo : ICustomerRepo
    {
        private readonly BankAppDataContext _context;

        public CustomerRepo(BankAppDataContext context)
        {
            _context = context;
        }

        public bool AddCustomer(Customer newCustomer)
        {
            try
            {
                _context.Customers.Add(newCustomer);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Customer GetCustomer(int id)
        {
            try
            {
                Customer customer = _context.Customers.Where(c => c.CustomerId == id).FirstOrDefault();
                return customer;
            }
            catch (Exception)
            {

                return null;
            }

        }
    }
}
