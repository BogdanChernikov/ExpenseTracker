using ExpensesTracker.DAL.Models;
using ExpensesTracker.Models;
using ExpensesTracker.Models.Infrastructure;
using ExpensesTracker.Models.RequestModels;
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

        public OperationResult CreateAccount(Account account)
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

        public OperationResult EditAccount(EditAccountModel editAccountModel)
        {
            var operationResult = new OperationResult();

            if (Accounts.Any(account => account.Name == editAccountModel.Name && account.Id != editAccountModel.Id))
            {
                operationResult.ErrorMassage = @"This account name is already in use.Choose another name";
                return operationResult;
            }

            var accountToEdit = Accounts.Single(x => x.Id == editAccountModel.Id);

            accountToEdit.Name = editAccountModel.Name;
            accountToEdit.InitialBalance = editAccountModel.InitialBalance;

            DbStorage.EditAccount(accountToEdit);

            operationResult.Success = true;

            return operationResult;
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

        public void EditOperation(EditOperationModel editOperationModel, int selectedAccountId)
        {
            var operationToEdit = Accounts.Single(x => x.Id == selectedAccountId)
                .AccountOperations.Single(x => x.Id == editOperationModel.Id);

            operationToEdit.Amount = editOperationModel.Amount;
            operationToEdit.Category = editOperationModel.Category;
            operationToEdit.Comment = editOperationModel.Comment;
            operationToEdit.Date = editOperationModel.Date;

            DbStorage.EditOperation(operationToEdit);
        }

        public void DeleteOperation(AccountOperation operation)
        {
            DbStorage.DeleteOperation(operation);
        }

        public List<AccountOperation> GetFilteredOperations(OperationsQueryFilter filteredOperationModel)
        {
            IEnumerable<AccountOperation> filteredOperations = _accounts.Single(x => x.Id == filteredOperationModel.Id).AccountOperations;

            var chosenCategory = filteredOperationModel.Category;

            if (chosenCategory != "All categories")
            {
                filteredOperations = filteredOperations.Where(x => x.Category == chosenCategory);
            }

            if (!string.IsNullOrWhiteSpace(filteredOperationModel.SearchText))
            {
                filteredOperations = filteredOperations
                    .Where(x => x.Comment.Contains(filteredOperationModel.SearchText.Trim()));
            }

            filteredOperations = filteredOperations.Where(x => x.Date >= filteredOperationModel.StartDate);
            filteredOperations = filteredOperations.Where(x => x.Date <= filteredOperationModel.EndDate);
            return filteredOperations.ToList();
        }

        private void CreateDefaultAccount()
        {
            var account = new Account()
            {
                Name = "Main",
                InitialBalance = 0,
                AccountOperations = new List<AccountOperation>()
            };

            var operationResult = CreateAccount(account);
            if (!operationResult.Success)
            {
                throw new InvalidOperationException(operationResult.ErrorMassage);
            }
        }
    }
}
