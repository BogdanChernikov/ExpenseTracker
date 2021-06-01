using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class EditDataForm : Form
    {
        public Action OnExpenseEdit;
        public AccountOperation TargetExpense;
        public List<Expense> Expenses;


        public EditDataForm()
        {
            InitializeComponent();
        }

        private void EditDataForm_Load(object sender, EventArgs e)
        {
            costInput.Value = TargetExpense.Cost;
            commentInput.Text = TargetExpense.Comment;
            expenseCategory.SelectedItem = TargetExpense.Category;
            expensetDate.Value = TargetExpense.Date;
        }

        private void CancelEditButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DeleteDataButton_Click(object sender, EventArgs e)
        {
            if (TargetExpense != null)
            {
                //Expenses.Remove();
            }
            OnExpenseEdit();
            this.Close();
        }

        private void EditDataButton_Click(object sender, EventArgs e)
        {
            TargetExpense.Cost = costInput.Value;
            TargetExpense.Comment = commentInput.Text;
            TargetExpense.Category = Convert.ToString(expenseCategory.SelectedItem);
            TargetExpense.Date = expensetDate.Value;
            OnExpenseEdit();
            this.Close();
        }
    }
}
