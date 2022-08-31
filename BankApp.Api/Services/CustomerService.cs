using BankApp.Api.DTO;
using BankApp.Api.Models;
using BankApp.Api.Services.Interfaces;
using BankApp.Api.Repos.Interfaces;
namespace BankApp.Api.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepo _customerRepo;

        public CustomerService(ICustomerRepo customerRepo)
        {
            _customerRepo = customerRepo;
        }

        public bool AddCustomer(CustomerDTO newCustomer)
        {
            Customer customer = new Customer()
            {
                Gender = newCustomer.Gender,
                Givenname = newCustomer.Givenname,
                Surname = newCustomer.Surname,
                Streetaddress = newCustomer.Streetaddress,
                City = newCustomer.City,
                Zipcode = newCustomer.Zipcode,
                Country = newCustomer.Country,
                CountryCode = newCustomer.CountryCode,
                Birthday = newCustomer.Birthday,
                Telephonecountrycode = newCustomer.Telephonecountrycode,
                Telephonenumber = newCustomer.Telephonenumber,
                Emailaddress = newCustomer.Emailaddress
            };
            try
            {
                bool res = _customerRepo.AddCustomer(customer);
                return res;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Customer GetCustomer(CustomerDTO customer)
        {
            Customer res = _customerRepo.GetCustomer(customer.CustomerId);
            return res;
        }
    }
}
