using System;
using System.ComponentModel.DataAnnotations;

namespace ExpensesTracker.DAL
{
    public class Operation
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Category { get; set; }
        public decimal Amount { get; set; }
        public string Comment { get; set; }

        public int AccountId { get; set; }
        public Account Account { get; set; }
    }
}
