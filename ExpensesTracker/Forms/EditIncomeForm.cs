using ExpensesTracker.Models;
using ExpensesTracker.Models.RequestModels;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpensesTracker.Forms
{
    public partial class EditIncomeForm : Form
    {
        public Func<EditOperationModel, Task> OnIncomeEdit;
        public Func<Task> OnIncomeDeleted;
        public AccountOperation TargetIncome;

        public EditIncomeForm()
        {
            InitializeComponent();
        }

        private void EditDataFormForIncome_Load(object sender, EventArgs e)
        {
            IncomeCommentTextBox.Text = TargetIncome.Comment;
            incomeAmountInput.Value = TargetIncome.Amount;
            incomeDateInput.Value = TargetIncome.Date;
        }

        private async void DeleteTargetIncomeButton_Click(object sender, EventArgs e)
        {
            await OnIncomeDeleted();
            this.Close();
        }

        private async void SaveEditedIncomeButton_Click(object sender, EventArgs e)
        {
            await OnIncomeEdit(new EditOperationModel()
            {
                Amount = incomeAmountInput.Value,
                Date = incomeDateInput.Value,
                Comment = IncomeCommentTextBox.Text,
                Id = TargetIncome.Id
            });
            this.Close();
        }

        private void CloseFormButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
