using ExpensesTracker.Models;
using System;
using System.Windows.Forms;

namespace ExpensesTracker.Forms
{
    public partial class CreateIncomeForm : Form
    {
        public Action<AccountOperation> OnIncomeAdded;

        public CreateIncomeForm()
        {
            InitializeComponent();
            incomeDateInput.Value = DateTime.Today;
        }

        private void CloseAddIncomeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void AddIncomeButton_Click(object sender, EventArgs e)
        {
            var income = new AccountOperation
            {
                Amount = incomeAmountInput.Value,
                Comment = incomeCommentTextBox.Text,
                Date = incomeDateInput.Value
            };

            OnIncomeAdded(income);
            this.Close();
        }
    }
}
