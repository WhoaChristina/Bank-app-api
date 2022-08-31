namespace BankApp.Api.DTO
{
    public class LoanDTO
    {
        public int AccountId { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public int Duration { get; set; }
        public decimal Payments { get; set; }
        public string Status { get; set; }

        public LoanDTO(int AccountId, DateTime Date, decimal Amount, int Duration, decimal Payments, string Status)
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
