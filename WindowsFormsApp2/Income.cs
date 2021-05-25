using System;

namespace WindowsFormsApp2
{
    public class Income
    {
        public string comment { get; set; }
        public decimal amount { get; set; }
        public DateTime date { get; set; }
        public Account account { get; set; }
    }
}
