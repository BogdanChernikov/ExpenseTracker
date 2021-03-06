using ExpensesTracker.Models.Enums;
using System;

namespace ExpensesTracker.Models
{
    public class AccountOperation
    {
        public DateTime Date { get; set; }
        public string Category { get; set; }
        public decimal Amount { get; set; }
        public string Comment { get; set; }
        public OperationType Type => Category == "Incomes" ? OperationType.Income : OperationType.Expense;

        public int Id { get; set; }
    }
}
