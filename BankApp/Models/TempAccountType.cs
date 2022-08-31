namespace BankApp.Models
{
    public class TempAccountType
    {
        public string TypeName { get; set; }
        public string Description { get; set; }
        public decimal Interest { get; set; }

        public TempAccountType(string typeName, string description, decimal interest)
        {
            TypeName = typeName;
            Description = description;
            Interest = interest;
        }
    }
}
