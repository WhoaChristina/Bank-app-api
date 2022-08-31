namespace BankApp.Api.DTO
{
    public class AccountDTO
    {
        public int AccountId { get; set; }
        public string Frequency { get; set; } = null!;
        public DateTime Created { get; set; }
        public decimal Balance { get; set; }
        public string AccountTypeName { get; set; }
    }
}
