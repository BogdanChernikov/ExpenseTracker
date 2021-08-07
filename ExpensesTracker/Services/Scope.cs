using ExpensesTracker.DAL;
using System;

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

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
