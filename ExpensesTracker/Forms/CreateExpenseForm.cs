using ExpensesTracker.Models;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpensesTracker.Forms
{
    public partial class CreateExpenseForm : Form
    {
        public Func<AccountOperation, Task> OnExpenseAdded;

        public CreateExpenseForm()
        {
            InitializeComponent();
            newCostDate.Value = DateTime.Today;
        }

        private void CancelAddButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public async void AddCostButton_Click(object sender, EventArgs e)
        {
            var expense = new AccountOperation
            {
                Amount = Convert.ToDecimal(PriceInput.Value),
                Comment = commentInput.Text,
                Category = GetSelectedCategory(),
                Date = newCostDate.Value
            };

            if (expense.Category == null)
            {
                MessageBox.Show(@"You don't select a category.To save the expense, select the expense category");
                return;
            }

            await OnExpenseAdded(expense);

            this.Close();
        }

        private string GetSelectedCategory()
        {
            switch (Convert.ToString(newCostCategory.SelectedItem))
            {
                case "Traffic":
                    return "Traffic";
                case "Utilities":
                    return "Utilities";
                case "Services Communication":
                    return "ServicesCommunication";
                case "Medicines And Hygiene Products":
                    return "MedicinesAndHygieneProducts";
                case "Food":
                    return "Food";
                default:
                    return null;
            }
        }
    }
}
