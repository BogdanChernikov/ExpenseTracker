using ExpensesTracker.DAL;
using ExpensesTracker.DAL.Repositories;
using System;
using System.Threading.Tasks;

namespace ExpensesTracker.Services
{
    public class Scope : IDisposable
    {
        public AccountRepository AccountRepository { get; }
        public OperationRepository OperationRepository { get; }
        private readonly EtContext _dbContext;

        public Scope(AccountRepository accountRepository, OperationRepository operationRepository, EtContext dbContext)
        {
            AccountRepository = accountRepository;
            OperationRepository = operationRepository;
            _dbContext = dbContext;
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
