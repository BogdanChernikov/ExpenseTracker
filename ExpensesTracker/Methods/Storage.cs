using ExpensesTracker.Models;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace ExpensesTracker.Methods
{
    class Storage
    {
        public List<Account> Accounts;
        public List<AccountOperation> AccountOperations;

        public void SaveChanges(List<Account> _accounts, List<AccountOperation> _accountOperations)
        {
            XmlSerializer acc = new XmlSerializer(typeof(List<Account>));
            string accou = "account.txt";
            FileStream stream1 = new FileStream(accou, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
            acc.Serialize(stream1, _accounts);
            stream1.Close();

            XmlSerializer accountOperation = new XmlSerializer(typeof(List<AccountOperation>));
            string operat = "accountOperations.txt";
            FileStream streamoperation = new FileStream(operat, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
            accountOperation.Serialize(streamoperation, _accountOperations);
            streamoperation.Close();
        }

        public void LoadData()
        {
            XmlSerializer acc = new XmlSerializer(typeof(List<Account>));
            string accou = "account.txt";
            var stream1 = new FileStream(accou, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            Accounts = (List<Account>)acc.Deserialize(stream1);

            stream1.Close();

            XmlSerializer accountOperation = new XmlSerializer(typeof(List<AccountOperation>));
            string operat = "accountOperations.txt";
            var streamoperation = new FileStream(operat, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            AccountOperations = (List<AccountOperation>)accountOperation.Deserialize(streamoperation);

            streamoperation.Close();
        }
    }
}
