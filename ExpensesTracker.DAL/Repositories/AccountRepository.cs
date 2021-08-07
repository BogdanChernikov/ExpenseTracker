using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace ExpensesTracker.DAL
{
    public class AccountRepository
    {
        public readonly EtContext _db;

        public AccountRepository(EtContext db)
        {
            _db = db;
        }

        public List<AccountEntity> GetAccounts()
        {
            var accountEntities = _db.Account
                    .Include(x => x.Operations)
                    .ToList();
            return accountEntities;
        }

        public AccountEntity FindById(int id)
        {
            return _db.Account.FirstOrDefault(x => x.Id == id);
        }

        public void CreateAccount(AccountEntity account)
        {
            _db.Account.Add(account);
        }

        public void DeleteAccount(int id)
        {
            var account = _db.Account.First(x => x.Id == id);
            _db.Account.Remove(account);
        }
    }
}
