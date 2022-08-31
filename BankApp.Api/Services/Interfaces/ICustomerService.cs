using BankApp.Api.Models;
using BankApp.Api.DTO;
namespace BankApp.Api.Services.Interfaces
{
    public interface ICustomerService
    {
        Customer GetCustomer(CustomerDTO customer);
        bool AddCustomer(CustomerDTO newCustomer);
    }
}
