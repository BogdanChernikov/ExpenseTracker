using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class AddNewAccount : Form
    {
        Account account = new Account();
        public List<Account> Account;
        public Label accountStatus;
        public ComboBox selectedAccountBox;

        public AddNewAccount()
        {
            InitializeComponent();
        }

        private void CanceledAddAccount_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addNewAccountButton_Click(object sender, EventArgs e)
        {
            account.initialBalance = initialBalance.Value;
            account.name = newAccountName.Text;
            Account.Add(account);
            selectedAccountBox.Items.Add(account.name);

            this.Close();
        }
    }
}
