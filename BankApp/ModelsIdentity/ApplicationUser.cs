using Microsoft.AspNetCore.Identity;

namespace BankApp.ModelsIdentity
{
    public class ApplicationUser : IdentityUser
    {
        public int CustomerID { get; set; }
    }
}
