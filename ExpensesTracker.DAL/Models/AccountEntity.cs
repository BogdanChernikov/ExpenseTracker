using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpensesTracker.DAL
{
    [Table("Accounts")]
    public class AccountEntity
    {
        [Key]
        public int Id { get; set; }
        public decimal InitialBalance { get; set; }
        public string Name { get; set; }
        public ICollection<OperationEntity> Operations { get; set; }
    }
}
