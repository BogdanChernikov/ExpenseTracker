using System;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class AddExpenseForm : Form
    {
        public Action<Expense> OnExpenseAdded;
        public Account expenseAccount;

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
            var cost = new Expense();
            cost.Cost = Convert.ToDecimal(PriceInput.Value);
            cost.Comment = commentInput.Text;
            if (Convert.ToString(newCostCategory.SelectedItem) == "Traffic")
                cost.Category = "Traffic";
            if (Convert.ToString(newCostCategory.SelectedItem) == "Utilities")
                cost.Category = "Utilities";
            if (Convert.ToString(newCostCategory.SelectedItem) == "Services Communication")
                cost.Category = "ServicesCommunication";
            if (Convert.ToString(newCostCategory.SelectedItem) == "Medicines And Hygiene Products")
                cost.Category = "MedicinesAndHygieneProducts";
            if (Convert.ToString(newCostCategory.SelectedItem) == "Food")
                cost.Category = "Food";
            cost.Date = newCostDate.Value.Date;

            OnExpenseAdded(cost);

            this.Close();
        }
    }
}
