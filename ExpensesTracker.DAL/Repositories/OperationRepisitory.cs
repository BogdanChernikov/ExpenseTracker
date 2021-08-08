using System.Linq;
using ExpensesTracker.DAL.Models;

namespace ExpensesTracker.DAL
{
    public class OperationRepository
    {
        private readonly EtContext _dbContext;

        public OperationRepository(EtContext dbContext)
        {
            _dbContext = dbContext;
        }

        public OperationEntity FindById(int id)
        {
            return _dbContext.Operation.FirstOrDefault(x => x.Id == id);
        }

        public void CreateOperation(OperationEntity operation)
        {
            _dbContext.Operation.Add(operation);
        }

        public void DeleteOperation(int id)
        {
            var operation = _dbContext.Operation.First(x => x.Id == id);
            _dbContext.Operation.Remove(operation);
        }
    }
}
