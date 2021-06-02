using System;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class AddExpenseForm : Form
    {
        public Action<Expense> OnExpenseAdded;

        public AddExpenseForm()
        {
            InitializeComponent();
        }

        private void CancelAddButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void AddCostButton_Click(object sender, EventArgs e)
        {
            var expense = new Expense();
            expense.Cost = Convert.ToDecimal(PriceInput.Value);
            expense.Comment = commentInput.Text;
            if (Convert.ToString(newCostCategory.SelectedItem) == "Traffic")
                expense.Category = "Traffic";
            if (Convert.ToString(newCostCategory.SelectedItem) == "Utilities")
                expense.Category = "Utilities";
            if (Convert.ToString(newCostCategory.SelectedItem) == "Services Communication")
                expense.Category = "ServicesCommunication";
            if (Convert.ToString(newCostCategory.SelectedItem) == "Medicines And Hygiene Products")
                expense.Category = "MedicinesAndHygieneProducts";
            if (Convert.ToString(newCostCategory.SelectedItem) == "Food")
                expense.Category = "Food";
            expense.Date = newCostDate.Value.Date;

            OnExpenseAdded(expense);

            this.Close();
        }
    }
}
