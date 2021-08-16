using ExpensesTracker.DAL.Models;
using ExpensesTracker.Models;
using ExpensesTracker.Models.Enums;
using ExpensesTracker.Models.Infrastructure;
using ExpensesTracker.Models.RequestModels;
using ExpensesTracker.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task InitializeAsync()
        {
            _accounts = await _dbStorage.GetAccountsAsync();
        }

        public List<AccountViewModel> GetAccountViewModels()
        {
            return Accounts.Select(account => new AccountViewModel
            {
                Name = account.Name,
                Id = account.Id,
            }).ToList();
        }

        public async Task<OperationResult> CreateAccountAsync(Account account)
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
            await _dbStorage.CreateAccountAsync(accountEntity);

            account.Id = accountEntity.Id;
            _accounts.Add(account);

            operationResult.Success = true;
            return operationResult;
        }

        public async Task<OperationResult> EditAccountAsync(EditAccountModel editAccountModel)
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

            await _dbStorage.EditAccountAsync(accountToEdit);

            operationResult.Success = true;

            return operationResult;
        }

        public async Task DeleteAccountAsync(int accountId)
        {
            _accounts.Remove(Accounts.Single(x => x.Id == accountId));
            await _dbStorage.DeleteAccountAsync(accountId);
            await EnsureAccountExistsAsync();
        }

        public async Task EnsureAccountExistsAsync()
        {
            if (!Accounts.Any())
                await CreateDefaultAccountAsync();
        }

        public async Task CreateOperationAsync(AccountOperation operation, int accountId)
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
            await _dbStorage.CreateOperationAsync(operationEntity);
            operation.Id = operationEntity.Id;
        }

        public async Task EditOperationAsync(EditOperationModel editOperationModel)
        {
            var account = Accounts.Single(x =>
                x.AccountOperations.Any(a => a.Id == editOperationModel.Id));

            var operationToEdit = account.AccountOperations.Single(x => x.Id == editOperationModel.Id);

            operationToEdit.Amount = editOperationModel.Amount;
            operationToEdit.Category = editOperationModel.Category;
            operationToEdit.Comment = editOperationModel.Comment;
            operationToEdit.Date = editOperationModel.Date;

            await _dbStorage.EditOperationAsync(operationToEdit);
        }

        public async Task DeleteOperationAsync(int operationId)
        {
            var account = Accounts.Single(x =>
                x.AccountOperations.Any(y => y.Id == operationId));

            var operationToDelete = account.AccountOperations.Single(x => x.Id == operationId);

            account.AccountOperations.Remove(operationToDelete);
            await _dbStorage.DeleteOperationAsync(operationId);
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

        public decimal GetAccountBalance(int accountId)
        {
            var account = Accounts.Single(x => x.Id == accountId);

            var sum = account.InitialBalance
                      + account.AccountOperations
                          .Where(x => x.Type == OperationType.Income)
                          .Sum(x => x.Amount)
                      - account.AccountOperations.Where(x => x.Type == OperationType.Expense)
                          .Sum(x => x.Amount);

            return sum;
        }

        private async Task CreateDefaultAccountAsync()
        {
            var account = new Account()
            {
                Name = "Main",
                InitialBalance = 0,
                AccountOperations = new List<AccountOperation>()
            };

            var operationResult = await CreateAccountAsync(account);
            if (!operationResult.Success)
            {
                throw new InvalidOperationException(operationResult.ErrorMassage);
            }
        }
    }
}
