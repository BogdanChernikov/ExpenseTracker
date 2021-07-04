using System.Linq;

namespace ExpensesTracker.DAL
{
    public class OperationRepository
    {
        private readonly EtContext _db;

        public OperationRepository(EtContext db)
        {
            _db = db;
        }

        public void CreateOperation(Operation operation, string account)
        {
            var targetAccount = _db.Account.Where(x => x.Name == account);
            operation.AccountId = targetAccount.First().Id;
            _db.Operation.Add(operation);
            _db.SaveChanges();
        }

        public void DeleteOperation()
        {
            //_db.Account.Remove();
            _db.SaveChanges();
        }
    }
}
