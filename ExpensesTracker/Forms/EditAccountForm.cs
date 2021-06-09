using ExpensesTracker.Models;
using System;
using System.Windows.Forms;

namespace ExpensesTracker.Forms
{
    public partial class EditAccountForm : Form
    {
        public Action OnAccountEdit;
        public Action OnAccountDeleted;
        public Account TargetAccountForEdit;


        public EditAccountForm()
        {
            InitializeComponent();
        }

        private void EditAccount_Load(object sender, EventArgs e)
        {
            editAccountNameInput.Text = TargetAccountForEdit.Name;
            editInitialBalanceInput.Value = TargetAccountForEdit.InitialBalance;
        }

        public void SaveEditedAccountButton_Click(object sender, EventArgs e)
        {
            TargetAccountForEdit.Name = editAccountNameInput.Text;
            TargetAccountForEdit.InitialBalance = editInitialBalanceInput.Value;
            OnAccountEdit();
            this.Close();
        }

        private void CanceledEditAccount_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DeleteAccountButton_Click(object sender, EventArgs e)
        {
            OnAccountDeleted();
            this.Close();
        }
    }
}
