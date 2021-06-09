using ExpensesTracker.Models;
using System;
using System.Windows.Forms;

namespace ExpensesTracker.Forms
{
    public partial class EditExpenseForm : Form
    {
        public Action OnExpenseEdit;
        public Action OnExpenseDeleted;
        public AccountOperation TargetExpense;

        public EditExpenseForm()
        {
            InitializeComponent();
        }

        private void EditDataForm_Load(object sender, EventArgs e)
        {
            expenseSumInput.Value = TargetExpense.Amount;
            commentInput.Text = TargetExpense.Comment;
            expenseCategoryBox.SelectedItem = TargetExpense.Category;
            expenseDatePicker.Value = TargetExpense.Date;
        }

        private void CancelEditButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DeleteDataButton_Click(object sender, EventArgs e)
        {
            OnExpenseDeleted();
            this.Close();
        }

        private void EditDataButton_Click(object sender, EventArgs e)
        {
            TargetExpense.Amount = expenseSumInput.Value;
            TargetExpense.Comment = commentInput.Text;
            TargetExpense.Category = Convert.ToString(expenseCategoryBox.SelectedItem);
            TargetExpense.Date = expenseDatePicker.Value;
            OnExpenseEdit();
            this.Close();
        }
    }
}
