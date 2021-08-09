using ExpensesTracker.Models;
using ExpensesTracker.Models.RequestModels;
using System;
using System.Windows.Forms;

namespace ExpensesTracker.Forms
{
    public partial class EditIncomeForm : Form
    {
        public Action<EditOperationModel> OnIncomeEdit;
        public Action OnIncomeDeleted;
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

        private void DeleteTargetIncomeButton_Click(object sender, EventArgs e)
        {
            OnIncomeDeleted();
            this.Close();
        }

        private void SaveEditedIncomeButton_Click(object sender, EventArgs e)
        {
            OnIncomeEdit(new EditOperationModel()
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
