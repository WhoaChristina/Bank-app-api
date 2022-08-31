using Microsoft.AspNetCore.Mvc;
using BankApp.Models;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;

namespace BankApp.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult AdminStart()
        {
            return View();
        }
        public IActionResult CreateLoan()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateLoan(int accountId, decimal amount, int duration, decimal payments, string status)
        {
            DateTime today = DateTime.Now;
            string url = "https://localhost:7121/api/CreateLoan";
            TempLoan temp = new TempLoan(accountId, today, amount, duration, payments, status);
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    string json = JsonConvert.SerializeObject(temp);
                    var data = new StringContent(json, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await httpClient.PostAsync(url, data);
                    response.EnsureSuccessStatusCode();
                    string jsonReturn = await response.Content.ReadAsStringAsync();
                    return View("AdminStart");
                }
            }
            catch (Exception)
            {
                ViewBag.msg = "Oj! något gick fel";
                return View();
            }
        }
        public IActionResult MakeLoanInput()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> MakeLoanInput(string type, int amount, int fromAcc, string tooAcc)
        {
            string bank = "Nodify";
            DateTime date = DateTime.Now;
            string operation = "Cash in Credit";
            string url = "https://localhost:7121/api/InputLoan";
            TempTransactions tempTransactions = new TempTransactions()
            {
                AccountId = fromAcc,
                Date = date,
                Type = type,
                Operation = operation,
                Amount = amount,
                Balance = 0,
                Symbol = "",
                Bank = bank,
                Account = tooAcc
            };
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    string json = JsonConvert.SerializeObject(tempTransactions);
                    var data = new StringContent(json, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await httpClient.PostAsync(url, data);
                    response.EnsureSuccessStatusCode();
                    string jsonReturn = await response.Content.ReadAsStringAsync();
                    return View("AdminStart");
                }
            }
            catch (Exception)
            {
                ViewBag.msg = "Oj! något gick fel";
                return View();
            }
        }
        public IActionResult CreateAccountType()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAccountType(string typeName, string description, decimal interest)
        {
            TempAccountType temp = new TempAccountType(typeName, description, interest);
            string url = "https://localhost:7121/api/CreateAccountType";

            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    string json = JsonConvert.SerializeObject(temp);
                    var data = new StringContent(json, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await httpClient.PostAsync(url, data);
                    response.EnsureSuccessStatusCode();
                    string jsonReturn = await response.Content.ReadAsStringAsync();
                    return View("AdminStart");
                }
            }
            catch (Exception)
            {
                ViewBag.msg = "Oj! något gick fel";
                return View(); 
            }
        }
        public IActionResult AddCustomer()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddCustomer(string gender, string givenName, string surname, string streetname, string city, string zipcode, string country, string countrycode, DateTime birthday, string tCountryCode, string phone, string email)
        {
            string url = "https://localhost:7121/api/AddCustomer";
            TempCustomer newCus = new TempCustomer()
            {
                Gender = gender,
                Givenname = givenName,
                Surname = surname,
                Streetaddress = streetname,
                City = city,
                Zipcode = zipcode,
                Country = country,
                CountryCode = countrycode,
                Birthday = birthday,
                Telephonecountrycode = tCountryCode,
                Telephonenumber = phone,
                Emailaddress = email
            };
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    string json = JsonConvert.SerializeObject(newCus);
                    var data = new StringContent(json, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await httpClient.PostAsync(url, data);
                    response.EnsureSuccessStatusCode();
                    string jsonReturn = await response.Content.ReadAsStringAsync();
                    return View("AdminStart");
                }
            }
            catch (Exception)
            {
                ViewBag.msg = "Oj! något gick fel";
                return View();
            }
        }
    }
}
