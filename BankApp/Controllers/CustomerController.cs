using Microsoft.AspNetCore.Mvc;
using BankApp.Models;
using Newtonsoft.Json;
using System.Text;

namespace BankApp.Controllers
{
    public class CustomerController : Controller
    {
        public async Task<IActionResult> CustomerStart(int ID)
        {
            CookieOptions cookie = new CookieOptions();
            cookie.Expires = DateTime.Now.AddDays(2);
            Response.Cookies.Append("LoggedIn", ID.ToString(), cookie);

            string url = "https://localhost:7121/api/GetAccounts";
            TempCustomer customer= new TempCustomer()
            {
                CustomerId = ID,
                Gender= "",
                Givenname ="",
                Surname ="",
                Streetaddress ="",
                City ="",
                Zipcode ="",
                Country ="",
                CountryCode ="",
                Birthday = DateTime.Now,
                Telephonecountrycode ="",
                Telephonenumber ="",
                Emailaddress =""
            };
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    string json = JsonConvert.SerializeObject(customer);
                    var data = new StringContent(json, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await httpClient.PostAsync(url, data);
                    response.EnsureSuccessStatusCode();
                    string jsonReturn = await response.Content.ReadAsStringAsync();
                    List<TempAccount> model = JsonConvert.DeserializeObject<List<TempAccount>>(jsonReturn);
                    return View(model);
                }
            }
            catch (Exception)
            {
                ViewBag.msg = "Oj! något gick fel";
                return View();
            }
        }
        public async Task<IActionResult> ShowDetails(int accId)
        {
            string url = "https://localhost:7121/api/GetTransactions";
            TempAccount acc = new TempAccount()
            {
                AccountId = accId,
                Frequency = "",
                Created = DateTime.Now,
                Balance = 0,
                AccountTypeName = ""
            };
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    string json = JsonConvert.SerializeObject(acc);
                    var data = new StringContent(json, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await httpClient.PostAsync(url, data);
                    response.EnsureSuccessStatusCode();
                    string jsonReturn = await response.Content.ReadAsStringAsync();
                    List<TempTransactions> res = JsonConvert.DeserializeObject<List<TempTransactions>>(jsonReturn);
                    var sorted = res.OrderByDescending(x => x.Date).ToList();
                    TempModel model = new TempModel()
                    {
                        AccountID = accId,
                        transactions = sorted
                    };
                    return View(model);
                }
            }
            catch (Exception)
            {
                ViewBag.msg = "Oj! något gick fel";
                string tempCusId = Request.Cookies["LoggedIn"];
                int cusId = int.Parse(tempCusId);
                return RedirectToAction("CustomerStart", new { ID = cusId });
            }
        }
        public IActionResult MakeTransaction(int id)
        {
            TempAccount acc = new TempAccount()
            {
                AccountId=id,
                Frequency = "",
                Created= DateTime.Now,
                Balance= 0,
                AccountTypeName=""
            };
            return View(acc);
        }
        [HttpPost]
        public async Task<IActionResult> MakeTransaction( int amount, string tooAcc, int id)
        {
            string url = "https://localhost:7121/api/MakeTransfer";
            TempTransactions temp = new TempTransactions()
            {
                AccountId = id,
                Date = DateTime.Now,
                Type = "debit",
                Operation = "Transfer",
                Amount = amount,
                Balance = 0,
                Symbol = "",
                Bank= "Nodify",
                Account = tooAcc
            };
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    string json = JsonConvert.SerializeObject(temp);
                    var data = new StringContent(json, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await httpClient.PostAsync(url, data);
                    response.EnsureSuccessStatusCode();
                    string jsonReturn = await response.Content.ReadAsStringAsync();
                    string tempCusId = Request.Cookies["LoggedIn"];
                    int cusId = int.Parse(tempCusId);
                    return RedirectToAction("CustomerStart", new { ID = cusId });
                }
            }
            catch (Exception)
            {
                ViewBag.msg = "Oj! Något gick fel";
                return View();
            }
        }
        public IActionResult BackToStart()
        {
            string tempCusId = Request.Cookies["LoggedIn"];
            int cusId = int.Parse(tempCusId);
            return RedirectToAction("CustomerStart", new { ID = cusId });
        }
    }
}
