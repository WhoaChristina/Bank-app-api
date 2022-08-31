using BankApp.Models;
namespace BankApp.Models
{
    public class TempModel
    {
        public int AccountID { get; set; }
        public List<TempTransactions> transactions;

        public List<TempTransactions> Transactions
        {
            get { return transactions; }
            set { transactions = value; }
        }
    }
}
