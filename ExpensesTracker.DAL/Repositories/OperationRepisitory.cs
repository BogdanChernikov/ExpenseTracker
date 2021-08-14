using ExpensesTracker.DAL.Models;
using System.Data.Entity;
using System.Threading.Tasks;

namespace ExpensesTracker.DAL
{
    public class OperationRepository
    {
        private readonly EtContext _dbContext;

        public OperationRepository(EtContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationEntity> FindByIdAsync(int id)
        {
            return await _dbContext.Operation.FirstOrDefaultAsync(x => x.Id == id);
        }

        public void CreateOperation(OperationEntity operation)
        {
            _dbContext.Operation.Add(operation);
        }

        public async Task DeleteOperationAsync(int id)
        {
            var operation = _dbContext.Operation.FirstAsync(x => x.Id == id);
            _dbContext.Operation.Remove(await operation);
        }
    }
}
