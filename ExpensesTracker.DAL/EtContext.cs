using System.Data.Entity;

namespace ExpensesTracker.DAL
{
    public class EtContext : DbContext
    {
        public EtContext()
            : base("DbConnection")
        {
        }
        public DbSet<Account> Account { get; set; }
        public DbSet<Operation> Operation { get; set; }
    }
}
