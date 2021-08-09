using ExpensesTracker.DAL.Models;
using ExpensesTracker.Models;
using System.Collections.Generic;
using System.Linq;
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

        public List<Account> GetAccounts()
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var accountEntities = scope.AccountRepository.GetAccounts();
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

        public void CreateAccount(AccountEntity accountEntity)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                scope.AccountRepository.CreateAccount(accountEntity);
                scope.SaveChanges();
            }
        }

        public void DeleteAccount(int id)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                scope.AccountRepository.DeleteAccount(id);
                scope.SaveChanges();
            }
        }

        public void EditAccount(Account account)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var accountEntities = scope.AccountRepository.FindById(account.Id);

                accountEntities.Name = account.Name;
                accountEntities.InitialBalance = account.InitialBalance;

                scope.SaveChanges();
            }
        }

        public void CreateOperation(OperationEntity operationEntity)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                scope.OperationRepository.CreateOperation(operationEntity);
                scope.SaveChanges();
            }
        }

        public void DeleteOperation(AccountOperation operation)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                scope.OperationRepository.DeleteOperation(operation.Id);
                scope.SaveChanges();
            }
        }

        public void EditOperation(AccountOperation operation)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var operationEntity = scope.OperationRepository.FindById(operation.Id);

                operationEntity.Amount = operation.Amount;
                operationEntity.Category = operation.Category;
                operationEntity.Comment = operation.Comment;
                operationEntity.Date = operation.Date;

                scope.SaveChanges();
            }
        }
    }
}
