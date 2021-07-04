using ExpensesTracker.DAL;
using ExpensesTracker.Models;
using ExpensesTracker.Models.Enums;
using System.Collections.Generic;
using System.Linq;
using Account = ExpensesTracker.Models.Account;

namespace ExpensesTracker.Services
{
    public class Storage
    {
        private readonly AccountRepository _accountRepository;
        private readonly OperationRepository _operationRepository;
        private readonly EtContext _dbContext;
        private readonly List<AccountOperation> _accountOperations;

        public Storage(AccountRepository accountRepository, OperationRepository operationRepository, EtContext etContext)
        {
            _accountRepository = accountRepository;
            _operationRepository = operationRepository;
            _dbContext = etContext;
            _accountOperations = GetOperationsList();
        }

        public List<Account> GetAccountsList()
        {
            var accounts = new List<Account>();

            foreach (var dbAccount in _dbContext.Account)
            {
                var account = new Account
                {
                    Name = dbAccount.Name,
                    Id = dbAccount.Id,
                    InitialBalance = dbAccount.InitialBalance,
                    AccountOperations = _accountOperations.Where(x => x.AccountId == dbAccount.Id).ToList()
                };
                accounts.Add(account);
            }

            return accounts;
        }

        public List<AccountOperation> GetOperationsList()
        {
            return _dbContext.Operation.Select(dbOperation => new AccountOperation
            {
                Id = dbOperation.Id,
                Amount = dbOperation.Amount,
                Category = dbOperation.Category,
                Comment = dbOperation.Comment,
                Date = dbOperation.Date,
                AccountId = dbOperation.AccountId,
                Type = dbOperation.Category == "Incomes" ? OperationType.Income : OperationType.Expense
            })
                .ToList();
        }

        public void AddAccountToDb(Account account)
        {
            var accountDb = new DAL.Account { Name = account.Name, InitialBalance = account.InitialBalance };

            _accountRepository.CreateAccount(accountDb);
        }

        public void DeleteAccount(int id)
        {
            _accountRepository.DeleteAccount(id);
        }

        public void EditAccount(Account account)
        {
            foreach (var dbAccount in _dbContext.Account)
            {
                if (dbAccount.Id != account.Id) continue;
                dbAccount.Name = account.Name;
                dbAccount.InitialBalance = account.InitialBalance;
            }
            _dbContext.SaveChanges();
        }

        public void AddOperationToDb(AccountOperation operation, string targetAccount)
        {
            var operationDb = new Operation
            {
                Amount = operation.Amount,
                Category = operation.Category,
                Comment = operation.Comment,
                Date = operation.Date,
            };
            _operationRepository.CreateOperation(operationDb, targetAccount);
        }

        public void DeleteOperation()
        {
            _operationRepository.DeleteOperation();
        }

        public void EditOperation(AccountOperation operation)
        {
            foreach (var dbOperation in _dbContext.Operation)
            {
                if (dbOperation.Id != operation.Id) continue;
                dbOperation.Amount = operation.Amount;
                dbOperation.Category = operation.Category;
                dbOperation.Comment = operation.Comment;
                dbOperation.Date = operation.Date;
            }
            _dbContext.SaveChanges();
        }
    }
}
