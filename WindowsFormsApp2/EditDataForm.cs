using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class EditDataForm : Form
    {
        public Action OnExpenseEdit;
        public Action OnExpenseDeleted;
        public Expense TargetExpense;

        public EditDataForm()
        {
            InitializeComponent();
        }

        private void EditDataForm_Load(object sender, EventArgs e)
        {
            expenseSumInput.Value = TargetExpense.Cost;
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
            TargetExpense.Cost = expenseSumInput.Value;
            TargetExpense.Comment = commentInput.Text;
            TargetExpense.Category = Convert.ToString(expenseCategoryBox.SelectedItem);
            TargetExpense.Date = expenseDatePicker.Value;
            OnExpenseEdit();
            this.Close();
        }
    }
}
