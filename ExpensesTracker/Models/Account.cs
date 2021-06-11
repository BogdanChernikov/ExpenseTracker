using System.Collections.Generic;

namespace ExpensesTracker.Models
{
    public class Account
    {
        public decimal InitialBalance { get; set; }
        public string Name { get; set; }
        public List<AccountOperation> AccountOperations { get; set; }
    }
}