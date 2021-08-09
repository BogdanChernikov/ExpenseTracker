using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using ExpensesTracker.DAL.Models;

namespace ExpensesTracker.DAL
{
    public class AccountRepository
    {
        private readonly EtContext _dbContext;

        public AccountRepository(EtContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<AccountEntity> GetAccounts()
        {
            var accountEntities = _dbContext.Account
                .Include(x => x.Operations)
                .ToList();
            return accountEntities;
        }

        public AccountEntity FindById(int id)
        {
            return _dbContext.Account.FirstOrDefault(x => x.Id == id);
        }

        public void CreateAccount(AccountEntity account)
        {
            _dbContext.Account.Add(account);
        }

        public void DeleteAccount(int id)
        {
            var account = _dbContext.Account.First(x => x.Id == id);
            _dbContext.Account.Remove(account);
        }
    }
}
