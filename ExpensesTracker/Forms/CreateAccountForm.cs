using ExpensesTracker.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpensesTracker.Forms
{
    public partial class CreateAccountForm : Form
    {
        public Func<Account, Task> OnAccountAdded;

        public CreateAccountForm()
        {
            InitializeComponent();
        }

        private void CanceledAddAccount_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void AddNewAccountButton_Click(object sender, EventArgs e)
        {
            var account = new Account
            {
                InitialBalance = initialBalanceInput.Value,
                Name = newAccountNameTextBox.Text,
                AccountOperations = new List<AccountOperation>()
            };
            await OnAccountAdded(account);

            this.Close();
        }
    }
}
