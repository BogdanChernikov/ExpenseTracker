using ExpensesTracker.DAL.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace ExpensesTracker.DAL.Repositories
{
    public class AccountRepository
    {
        private readonly EtContext _dbContext;

        public AccountRepository(EtContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<AccountEntity>> GetAccountsAsync()
        {
            var accountEntities = await _dbContext.Account
                .Include(x => x.Operations)
                .ToListAsync();
            return accountEntities;
        }

        public async Task<AccountEntity> FindByIdAsync(int id)
        {
            return await _dbContext.Account.FirstOrDefaultAsync(x => x.Id == id);
        }

        public void CreateAccount(AccountEntity account)
        {
            _dbContext.Account.Add(account);
        }

        public async Task DeleteAccountAsync(int id)
        {
            var account = await _dbContext.Account.FirstAsync(x => x.Id == id);
            _dbContext.Account.Remove(account);
        }
    }
}
