using System;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class AddNewIncomeForm : Form
    {
        public Action<Income> OnIncomeAdded;

        public AddNewIncomeForm()
        {
            InitializeComponent();
        }

        private void CloseAddIncomeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void AddIncomeButton_Click(object sender, EventArgs e)
        {
            var income = new Income();
            income.Cost = incomeAmountInput.Value;
            income.Comment = newIncomeCommentTextBox.Text;
            income.Date = incomeDateInput.Value;
            OnIncomeAdded(income);
            this.Close();
        }
    }
}
