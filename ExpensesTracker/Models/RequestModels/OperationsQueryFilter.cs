using System;

namespace ExpensesTracker.Models.RequestModels
{
    public class OperationsQueryFilter
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string SearchText { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
