using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    public class AccountOperation
    {
        public string Category { get; set; }
        public decimal Cost { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }
        public Account Account { get; set; }
        public string Type { get; set; }
    }
}
