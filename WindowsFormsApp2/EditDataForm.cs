using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class EditDataForm : Form
    {
        public Action OnExpenseEdit;
        public Expense editExpense;
        public List<Expense> expenses;
        

        public EditDataForm()
        {
            InitializeComponent();
        }

        private void EditDataForm_Load(object sender, EventArgs e)
        {
            PriceInput.Value = editExpense.Cost;
            commentInput.Text = editExpense.Comment;
            expenseCategory.SelectedItem = editExpense.Category;
            expensetDate.Value = editExpense.Date;
        }

        private void CancelEditButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DeleteDataButton_Click(object sender, EventArgs e)
        {
            if (editExpense != null)
            {
                expenses.Remove(editExpense);
            }
            OnExpenseEdit();
            this.Close();
        }

        private void EditDataButton_Click(object sender, EventArgs e)
        {
            editExpense.Cost = PriceInput.Value;
            editExpense.Comment = commentInput.Text;
            //editExpense.Category = expenseCategory.SelectedItem;
            editExpense.Date = expensetDate.Value;
            OnExpenseEdit();
            this.Close();
        }
    }
}
