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
    public partial class AddNewIncomeForm : Form
    {
        public Action<Income> onIncomeAdded;
        public Account IncomeAccount;

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
            income.Account = IncomeAccount;
            onIncomeAdded(income);
            this.Close();
        }
    }
}
