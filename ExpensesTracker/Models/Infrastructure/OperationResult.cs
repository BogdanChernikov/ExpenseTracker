using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesTracker.Models.Infrastructure
{
    public class OperationResult
    {
        public string ErrorMassage { get; set; }
        public bool Success { get; set; }
    }
}
