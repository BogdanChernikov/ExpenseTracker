using ExpensesTracker.DAL.Models;
using ExpensesTracker.Models;
using ExpensesTracker.Models.Infrastructure;
using ExpensesTracker.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExpensesTracker.Services
{
    public class StateManager
    {
        private List<Account> _accounts;
        private readonly DbStorage _dbStorage;

        public IReadOnlyCollection<Account> Accounts => _accounts.AsReadOnly();

        public StateManager()
        {
            _dbStorage = new DbStorage();
        }

        public void Initialize()
        {
            _accounts = _dbStorage.GetAccounts();
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
            _dbStorage.CreateAccount(accountEntity);

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

            _dbStorage.EditAccount(accountToEdit);

            operationResult.Success = true;

            return operationResult;
        }

        public void DeleteAccount(Account account)
        {
            _accounts.Remove(account);
            _dbStorage.DeleteAccount(account.Id);
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

            _accounts.Single(x => x.Id == accountId).AccountOperations.Add(operation);
            _dbStorage.CreateOperation(operationEntity);
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

            _dbStorage.EditOperation(operationToEdit);
        }

        public void DeleteOperation(AccountOperation operation, int accountId)
        {
            Accounts.Single(x => x.Id == accountId).AccountOperations.Remove(operation);
            _dbStorage.DeleteOperation(operation.Id);
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
