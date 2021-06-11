using ExpensesTracker.Models;
using System;
using System.Windows.Forms;

namespace ExpensesTracker.Forms
{
    public partial class CreateAccountForm : Form
    {
        public Action<Account> OnAccountAdded;

        public CreateAccountForm()
        {
            InitializeComponent();
        }

        private void CanceledAddAccount_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddNewAccountButton_Click(object sender, EventArgs e)
        {
            var account = new Account();
            account.InitialBalance = initialBalanceInput.Value;
            account.Name = newAccountNameTextBox.Text;
            OnAccountAdded(account);

            this.Close();
        }
    }
}
