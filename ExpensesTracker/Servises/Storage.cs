using ExpensesTracker.Models;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace ExpensesTracker.Servises
{
    public class Storage
    {
        private const string AccountsFileName = "account.txt";
        private const string AccountOperationsFileName = "accountOperations.txt";

        public void SaveChanges(List<Account> accounts)
        {
            var serializer = new XmlSerializer(typeof(List<Account>));
            using (var stream = new FileStream(AccountsFileName, FileMode.Create))
            {
                serializer.Serialize(stream, accounts);
            }
        }
        public void SaveChanges(List<AccountOperation> accountOperations)
        {
            var serializer = new XmlSerializer(typeof(List<AccountOperation>));
            using (var stream = new FileStream(AccountOperationsFileName, FileMode.Create))
            {
                serializer.Serialize(stream, accountOperations);
            }
        }

        public List<Account> GetAccount()
        {
            var serializer = new XmlSerializer(typeof(List<Account>));
            using (var stream = new FileStream(AccountsFileName, FileMode.Open))
            {
                return (List<Account>)serializer.Deserialize(stream);
            }
        }
        public List<AccountOperation> GetAccountOperations()
        {
            var serializer = new XmlSerializer(typeof(List<AccountOperation>));
            using (var stream = new FileStream(AccountOperationsFileName, FileMode.Open))
            {
                return (List<AccountOperation>)serializer.Deserialize(stream);
            }
        }
    }
}
