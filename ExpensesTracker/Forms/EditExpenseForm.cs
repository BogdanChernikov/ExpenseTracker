using ExpensesTracker.Models;
using ExpensesTracker.Models.RequestModels;
using System;
using System.Windows.Forms;

namespace ExpensesTracker.Forms
{
    public partial class EditExpenseForm : Form
    {
        public Action<EditOperationModel> OnExpenseEdit;
        public Action OnExpenseDeleted;
        public AccountOperation TargetExpense;

        public EditExpenseForm()
        {
            InitializeComponent();
        }

        private void EditDataForm_Load(object sender, EventArgs e)
        {
            expenseCategoryBox.SelectedItem = TargetExpense.Category;
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
            OnExpenseEdit(new EditOperationModel()
            {
                Amount = expenseSumInput.Value,
                Category = Convert.ToString(expenseCategoryBox.SelectedItem),
                Date = expenseDatePicker.Value,
                Comment = commentInput.Text,
                Id = TargetExpense.Id
            });
            this.Close();
        }
    }
}
