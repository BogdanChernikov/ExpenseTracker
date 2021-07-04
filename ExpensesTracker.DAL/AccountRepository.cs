using System.Linq;

namespace ExpensesTracker.DAL
{
    public class AccountRepository
    {
        private readonly EtContext _db;

        public AccountRepository(EtContext db)
        {
            _db = db;
        }

        public void CreateAccount(Account account)
        {
            _db.Account.Add(account);
            _db.SaveChanges();
        }

        public void DeleteAccount(int id)
        {
            var account = _db.Account.First(x => x.Id == id);
            _db.Account.Remove(account);
            _db.SaveChanges();
        }
    }
}
