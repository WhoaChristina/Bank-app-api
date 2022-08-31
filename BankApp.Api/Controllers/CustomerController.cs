using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BankApp.Api.DTO;
using BankApp.Api.Services.Interfaces;
using BankApp.Api.Models;
namespace BankApp.Api.Controllers
{
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IDispositionService _dispositionService;
        private readonly IAccountService _accountService;
        private readonly IAccountTypeService _accountTypeService;
        private readonly ITransactionService _transactionService;

        public CustomerController(ICustomerService customerService, IDispositionService dispositionService, IAccountService accountService, IAccountTypeService accountTypeService, ITransactionService transactionService)
        {
            _customerService = customerService;
            _dispositionService = dispositionService;
            _accountService = accountService;
            _accountTypeService = accountTypeService;
            _transactionService = transactionService;
        }

        [Route("api/[action]")]
        public IActionResult GetAccounts(CustomerDTO customer)
        {
            List<AccountDTO> accounts= new List<AccountDTO>();
            List<Account> temp = new List<Account>();
            try
            {
                Customer customerRes = _customerService.GetCustomer(customer);
                List<Disposition> dispositionRes = _dispositionService.GetDispositions(customerRes.CustomerId);
                foreach (var disp in dispositionRes)
                {
                    temp.Add(_accountService.GetAccount(disp.AccountId));
                }
                foreach (var acc in temp)
                {
                    var res = _accountTypeService.GetTypeName(acc.AccountTypesId.Value);
                    accounts.Add(new AccountDTO() { AccountId = acc.AccountId, Frequency = acc.Frequency, Created = acc.Created, Balance = acc.Balance, AccountTypeName = res.TypeName});
                }
                return Ok(accounts);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [Route("api/[action]")]
        [HttpPost]
        public IActionResult GetTransactions(AccountDTO acc)
        {
            try
            {
                var res = _transactionService.GetTransactions(acc);
                return Ok(res);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [Route("api/[action]")]
        public IActionResult MakeTransfer(TransactionDTO transaction)
        {
            try
            {
                bool res = _transactionService.Input(transaction);
                if (res)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
