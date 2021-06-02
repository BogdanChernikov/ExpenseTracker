using System;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class AddNewAccount : Form
    {
        public Action<Account> OnAccountAdded;

        public AddNewAccount()
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
