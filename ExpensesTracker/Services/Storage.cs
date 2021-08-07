using ExpensesTracker.Models;
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

        public void AddAccount(Account account)
        {
            _accounts.Add(account);
            DbStorage.CreateAccount(account);
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

            AddAccount(account);
        }
    }
}
