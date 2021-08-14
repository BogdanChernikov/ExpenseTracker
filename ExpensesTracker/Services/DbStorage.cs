using ExpensesTracker.DAL.Models;
using ExpensesTracker.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Account = ExpensesTracker.Models.Account;

namespace ExpensesTracker.Services
{
    public class DbStorage
    {
        private readonly ScopeFactory _scopeFactory;

        public DbStorage()
        {
            _scopeFactory = new ScopeFactory();
        }

        public async Task<List<Account>> GetAccountsAsync()
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var accountEntities = await scope.AccountRepository.GetAccountsAsync();
                var accounts = accountEntities.Select(account => new Account()
                {
                    Name = account.Name,
                    Id = account.Id,
                    InitialBalance = account.InitialBalance,
                    AccountOperations = account.Operations.Select(dbOperation => new AccountOperation
                    {
                        Id = dbOperation.Id,
                        Amount = dbOperation.Amount,
                        Category = dbOperation.Category,
                        Comment = dbOperation.Comment,
                        Date = dbOperation.Date,
                    }).ToList()
                }).ToList();

                return accounts;
            }
        }

        public async Task CreateAccountAsync(AccountEntity accountEntity)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                scope.AccountRepository.CreateAccount(accountEntity);
                await scope.SaveChangesAsync();
            }
        }

        public async Task DeleteAccountAsync(int id)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                await scope.AccountRepository.DeleteAccountAsync(id);
                await scope.SaveChangesAsync();
            }
        }

        public async Task EditAccountAsync(Account account)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var accountEntities = await scope.AccountRepository.FindByIdAsync(account.Id);
                accountEntities.Name = account.Name;
                accountEntities.InitialBalance = account.InitialBalance;

                await scope.SaveChangesAsync();
            }
        }

        public async Task CreateOperationAsync(OperationEntity operationEntity)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                scope.OperationRepository.CreateOperation(operationEntity);
                await scope.SaveChangesAsync();
            }
        }

        public async Task DeleteOperationAsync(int id)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                await scope.OperationRepository.DeleteOperationAsync(id);
                await scope.SaveChangesAsync();
            }
        }

        public async Task EditOperationAsync(AccountOperation operation)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var operationEntity = await scope.OperationRepository.FindByIdAsync(operation.Id);

                operationEntity.Amount = operation.Amount;
                operationEntity.Category = operation.Category;
                operationEntity.Comment = operation.Comment;
                operationEntity.Date = operation.Date;

                await scope.SaveChangesAsync();
            }
        }
    }
}
