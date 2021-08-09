using System;

namespace ExpensesTracker.Models.RequestModels
{
    public class EditOperationModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Category { get; set; }
        public decimal Amount { get; set; }
        public string Comment { get; set; }
    }
}
