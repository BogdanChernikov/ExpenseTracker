using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExpensesTracker.DAL
{
    public class Account
    {

        [Key]
        public int Id { get; set; }
        public decimal InitialBalance { get; set; }
        public string Name { get; set; }
        public ICollection<Operation> Operations { get; set; }
    }
}
