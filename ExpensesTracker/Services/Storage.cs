﻿using ExpensesTracker.Models;
using ExpensesTracker.Models.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ExpensesTracker.DAL.Models;

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

            var accountEntity = new AccountEntity { Name = account.Name, InitialBalance = account.InitialBalance };
            DbStorage.CreateAccount(accountEntity);

            account.Id = accountEntity.Id;
            _accounts.Add(account);

            operationResult.Success = true;
            return operationResult;
        }

        public void EditAccount(Account selectedAccount)
        {
            DbStorage.EditAccount(selectedAccount);
        }

        public void DeleteAccount(Account account)
        {
            _accounts.Remove(account);
            DbStorage.DeleteAccount(account.Id);
            EnsureAccountExists();
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

        public void CreateOperation(AccountOperation operation, int accountId)
        {
            var operationEntity = new OperationEntity
            {
                Amount = operation.Amount,
                Category = operation.Category,
                Comment = operation.Comment,
                Date = operation.Date,
                AccountId = accountId,
            };
            DbStorage.CreateOperation(operationEntity);
            operation.Id = operationEntity.Id;
        }

        public void EditOperation(AccountOperation operation)
        {
            DbStorage.EditOperation(operation);
        }

        public void DeleteOperation(AccountOperation operation)
        {
            DbStorage.DeleteOperation(operation);
        }
    }
}
