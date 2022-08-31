using BankApp.Api.Models;
namespace BankApp.Api.Repos.Interfaces
{
    public interface ICustomerRepo
    {
        Customer GetCustomer(int id);
        bool AddCustomer(Customer newCustomer);
    }
}
