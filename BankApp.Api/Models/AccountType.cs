﻿using System;
using System.Collections.Generic;

namespace BankApp.Api.Models
{
    public partial class AccountType
    {
        public AccountType()
        {
            Accounts = new HashSet<Account>();
        }

        public int AccountTypeId { get; set; }
        public string TypeName { get; set; } = null!;
        public string? Description { get; set; }
        public decimal? Interest { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
    }
}
