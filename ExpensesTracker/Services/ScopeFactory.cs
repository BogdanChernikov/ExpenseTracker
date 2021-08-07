using ExpensesTracker.DAL;

namespace ExpensesTracker.Services
{
    public class ScopeFactory
    {
        public Scope CreateScope()
        {
            var dbContext = new EtContext();
            var accountRepository = new AccountRepository(dbContext);
            var operationRepository = new OperationRepository(dbContext);
            var scope = new Scope(accountRepository, operationRepository, dbContext);
            return scope;
        }
    }
}
