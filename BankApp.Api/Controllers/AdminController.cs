using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BankApp.Api.Services.Interfaces;
using BankApp.Api.Models;
using BankApp.Api.DTO;
namespace BankApp.Api.Controllers
{
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAccountTypeService _accountTypeService;
        private readonly ILoanService _loanService;
        private readonly ITransactionService _transactionService;
        private readonly ICustomerService _customerService;

        public AdminController(IAccountTypeService accountTypeService, ILoanService loanService, ITransactionService transactionService, ICustomerService customerService)
        {
            _accountTypeService = accountTypeService;
            _loanService = loanService;
            _transactionService = transactionService;
            _customerService = customerService;
        }

        [Route("api/[action]")]
        [HttpPost]
        public IActionResult CreateAccountType(AccountTypeDTO newType)
        {
            try
            {
                bool res = _accountTypeService.CreateAccountTypeService(newType);
                return Ok("kontot tillagd");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [Route("api/[action]")]
        [HttpPost]
        public IActionResult CreateLoan(LoanDTO newLoan)
        {
            try
            {
                bool res = _loanService.CreateLoanService(newLoan);
                return Ok("Lån skapad");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("api/[action]")]
        [HttpPost]
        public IActionResult InputLoan(TransactionDTO loanInput)
        {
            try
            {
                bool res = _transactionService.Input(loanInput);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        [Route("api/[action]")]
        [HttpPost]
        public IActionResult AddCustomer(CustomerDTO newCus)
        {
            try
            {
                bool res = _customerService.AddCustomer(newCus);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
