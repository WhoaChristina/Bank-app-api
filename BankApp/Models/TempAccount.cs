using BankApp.Models;
namespace BankApp.Models
{
    public class TempAccount
    {
        public int AccountId { get; set; }
        public string Frequency { get; set; }
        public DateTime Created { get; set; }
        public decimal Balance { get; set; }
        public string AccountTypeName { get; set; }

    }
}
