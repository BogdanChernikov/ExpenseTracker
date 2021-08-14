using ExpensesTracker.Models;
using ExpensesTracker.Models.RequestModels;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpensesTracker.Forms
{
    public partial class EditAccountForm : Form
    {
        public Func<EditAccountModel, Task> OnAccountEdit;
        public Func<Task> OnAccountDeleted;
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

        public async void SaveEditedAccountButton_Click(object sender, EventArgs e)
        {
            await OnAccountEdit(new EditAccountModel()
            {
                InitialBalance = editInitialBalanceInput.Value,
                Name = editAccountNameInput.Text,
                Id = TargetAccountForEdit.Id
            });
            this.Close();
        }

        private void CanceledEditAccount_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void DeleteAccountButton_Click(object sender, EventArgs e)
        {
            await OnAccountDeleted();
            this.Close();
        }
    }
}
