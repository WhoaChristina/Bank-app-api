namespace BankApp.Api.DTO
{
    public class AccountTypeDTO
    {
        public string TypeName { get; set; } = null!;
        public string? Description { get; set; }
        public decimal? Interest { get; set; }
    }
}
