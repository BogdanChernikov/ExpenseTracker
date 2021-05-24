using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class EditAccount : Form
    {
        public Action OnAccountEdit;
        public Account TargetAccount;
        public List<Account> Accounts;
        public ComboBox accountBox;

        public EditAccount()
        {
            InitializeComponent();
        }

        private void EditAccount_Load(object sender, EventArgs e)
        {
            editAccountNameInput.Text = TargetAccount.Name;
            editInitialBalanceInput.Value = TargetAccount.InitialBalance;
        }

        public void SaveEditedAccountButton_Click(object sender, EventArgs e)
        {
            TargetAccount.Name = editAccountNameInput.Text;
            TargetAccount.InitialBalance = editInitialBalanceInput.Value;
            OnAccountEdit();
            this.Close();
        }

        private void CanceledEditAccount_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DeleteAccountButton_Click(object sender, EventArgs e)
        {
            if (TargetAccount != null)
            {
                Accounts.Remove(TargetAccount);
                
            }
            accountBox.SelectedIndex = 0;
            OnAccountEdit();
            
            this.Close();
        }
    }
}
