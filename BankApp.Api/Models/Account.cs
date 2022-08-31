﻿using System;
using System.Collections.Generic;

namespace BankApp.Api.Models
{
    public partial class Account
    {
        public Account()
        {
            Dispositions = new HashSet<Disposition>();
            Loans = new HashSet<Loan>();
            Transactions = new HashSet<Transaction>();
        }

        public int AccountId { get; set; }
        public string Frequency { get; set; } = null!;
        public DateTime Created { get; set; }
        public decimal Balance { get; set; }
        public int? AccountTypesId { get; set; }

        public virtual AccountType? AccountTypes { get; set; }
        public virtual ICollection<Disposition> Dispositions { get; set; }
        public virtual ICollection<Loan> Loans { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
