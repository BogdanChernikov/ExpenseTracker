using System;

namespace WindowsFormsApp2
{
    public class AccountOperation
    {
        public string Category { get; set; }
        public decimal Amount { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }
        public Account Account { get; set; }
        public OperationType Type { get; set; }
    }
}
