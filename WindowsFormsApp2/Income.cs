using System;

namespace WindowsFormsApp2
{
    class Income
    {
        public string comment { get; set; }
        public decimal amount { get; set; }
        public DateTime date { get; set; }
        public IncomeCategory incomeCategory { get; set; }
    }
}
