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

        public OperationEntity FindById(int id)
        {
            return _db.Operation.FirstOrDefault(x => x.Id == id);
        }

        public void CreateOperation(OperationEntity operation)
        {
            _db.Operation.Add(operation);
        }

        public void DeleteOperation(int id)
        {
            var operation = _db.Operation.First(x => x.Id == id);
            _db.Operation.Remove(operation);
        }
    }
}
