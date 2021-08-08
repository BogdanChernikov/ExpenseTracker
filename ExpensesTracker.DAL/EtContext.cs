using System.Data.Entity;
using ExpensesTracker.DAL.Models;

namespace ExpensesTracker.DAL
{
    public class EtContext : DbContext
    {
        public EtContext()
            : base("DbConnection")
        {
        }
        public DbSet<AccountEntity> Account { get; set; }
        public DbSet<OperationEntity> Operation { get; set; }
    }
}
