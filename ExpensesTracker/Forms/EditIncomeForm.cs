using ExpensesTracker.Models;
using System;
using System.Windows.Forms;

namespace ExpensesTracker.Forms
{
    public partial class EditIncomeForm : Form
    {
        public Action OnIncomeEdit;
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
            TargetIncome.Comment = IncomeCommentTextBox.Text;
            TargetIncome.Amount = incomeAmountInput.Value;
            TargetIncome.Date = incomeDateInput.Value;

            OnIncomeEdit();
            this.Close();
        }

        private void CloseFormButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
