using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static WindowsFormsApp2.MainWindow;

namespace WindowsFormsApp2
{
    public partial class AddCostForm : Form
    {
        public Action<Expense> OnExpenseAdded;

        public AddCostForm()
        {
            InitializeComponent();
        }

        private void CancelAddButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void AddCostButton_Click(object sender, EventArgs e)
        {
            Expense cost = new Expense();
            cost.Cost = Convert.ToDecimal(PriceInput.Value);
            cost.Comment = commentInput.Text;
            if (Convert.ToString(newCostCategory.SelectedItem) == "Traffic")
            { cost.Category = "Traffic"; }
            if (Convert.ToString(newCostCategory.SelectedItem) == "Utilities")
            { cost.Category = "Utilities"; }
            if (Convert.ToString(newCostCategory.SelectedItem) == "Services Communication")
            { cost.Category = "ServicesCommunication"; }
            if (Convert.ToString(newCostCategory.SelectedItem) == "Medicines And Hygiene Products")
            { cost.Category = "MedicinesAndHygieneProducts"; }
            if (Convert.ToString(newCostCategory.SelectedItem) == "Food")
            { cost.Category = "Food"; }
            cost.Date = newCostDate.Value.Date;

            OnExpenseAdded(cost);

            this.Close();
        }
    }
}
