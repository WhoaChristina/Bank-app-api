using BankApp.Models;
namespace BankApp.Models
{
    public class TempLoan
    {
        public int AccountId { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public int Duration { get; set; }
        public decimal Payments { get; set; }
        public string Status { get; set; }

        public TempLoan(int AccountId, DateTime Date, decimal Amount, int Duration, decimal Payments, string Status)
        {
            this.AccountId = AccountId;
            this.Date = Date;
            this.Amount = Amount;
            this.Duration = Duration;
            this.Payments = Payments;
            this.Status = Status;
        }
    }
}
