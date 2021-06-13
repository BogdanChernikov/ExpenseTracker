using ExpensesTracker.Models;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace ExpensesTracker.Services
{
    public class Storage
    {
        private const string AccountsFileName = "account.txt";

        public void SaveChanges(List<Account> accounts)
        {
            var serializer = new XmlSerializer(typeof(List<Account>));
            using (var stream = new FileStream(AccountsFileName, FileMode.Create))
            {
                serializer.Serialize(stream, accounts);
            }
        }

        public List<Account> GetAccounts()
        {
            try
            {
                var serializer = new XmlSerializer(typeof(List<Account>));
                using (var stream = new FileStream(AccountsFileName, FileMode.Open))
                {
                    return (List<Account>)serializer.Deserialize(stream);
                }
            }
            catch
            {
                return new List<Account>();
            }
        }
    }
}
