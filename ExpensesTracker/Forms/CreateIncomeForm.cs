using ExpensesTracker.Models;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpensesTracker.Forms
{
    public partial class CreateIncomeForm : Form
    {
        public Func<AccountOperation, Task> OnIncomeAdded;

        public CreateIncomeForm()
        {
            InitializeComponent();
            incomeDateInput.Value = DateTime.Today;
        }

        private void CloseAddIncomeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public async void AddIncomeButton_Click(object sender, EventArgs e)
        {
            var income = new AccountOperation
            {
                Amount = incomeAmountInput.Value,
                Comment = incomeCommentTextBox.Text,
                Date = incomeDateInput.Value,
                Category = "Incomes",
            };

            await OnIncomeAdded(income);
            this.Close();
        }
    }
}
