using ExpensesTracker.Models;
using ExpensesTracker.Models.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExpensesTracker.Services
{
    public class Storage
    {
        private readonly List<Account> _accounts;
        public readonly DbStorage DbStorage;

        public IReadOnlyCollection<Account> Accounts => _accounts.AsReadOnly();

        public Storage()
        {
            DbStorage = new DbStorage();
            _accounts = DbStorage.GetAccounts();
        }

        public OperationResult AddAccount(Account account)
        {
            var operationResult = new OperationResult()
            {
                Success = false
            };

            if (Accounts.Any(x => x.Name == account.Name))
            {
                operationResult.ErrorMassage = @"This account name is already in use.Choose another name";
                return operationResult;
            }

            _accounts.Add(account);
            DbStorage.CreateAccount(account);

            operationResult.Success = true;
            return operationResult;
        }

        public void DeleteAccount(Account account)
        {
            _accounts.Remove(account);
            DbStorage.DeleteAccount(account.Id);
        }

        public void EnsureAccountExists()
        {
            if (!Accounts.Any())
                CreateDefaultAccount();
        }

        private void CreateDefaultAccount()
        {
            var account = new Account()
            {
                Name = "Main",
                InitialBalance = 0,
                AccountOperations = new List<AccountOperation>()
            };

            var operationResult = AddAccount(account);
            if (!operationResult.Success)
            {
                throw new InvalidOperationException(operationResult.ErrorMassage);
            }
        }
    }
}
