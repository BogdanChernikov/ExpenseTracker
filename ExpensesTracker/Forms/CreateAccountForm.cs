using ExpensesTracker.Models;
using System;
using System.Collections.Generic;
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
            var account = new Account
            {
                InitialBalance = initialBalanceInput.Value,
                Name = newAccountNameTextBox.Text,
                AccountOperations = new List<AccountOperation>()
            };
            OnAccountAdded(account);

            this.Close();
        }
    }
}
