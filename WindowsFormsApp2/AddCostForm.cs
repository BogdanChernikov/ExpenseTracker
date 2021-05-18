using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static WindowsFormsApp2.MainWindow;

namespace WindowsFormsApp2
{
    public partial class AddCostForm : Form
    {
        Expenses cost = new Expenses();
        public List<Expenses> expenes;
        public DataGridView dataGridView1;
        public CostRow tab;

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

            //cost.name = newCostNameInput.Text;
            cost.cost = Convert.ToDecimal(PriceInput.Value);
            cost.comment = commentInput.Text;
            if (Convert.ToString(newCostCategory.SelectedItem) == "Traffic")
            { cost.Category = "Traffic"; }
            if (Convert.ToString(newCostCategory.SelectedItem) == "Utilities")
            { cost.Category = "Utilities"; }
            if (Convert.ToString(newCostCategory.SelectedItem) == "Services Communication")
            { cost.Category = "Services Communication"; }
            if (Convert.ToString(newCostCategory.SelectedItem) == "Medicines And Hygiene Products")
            { cost.Category = "Medicines And Hygiene Products"; }
            if (Convert.ToString(newCostCategory.SelectedItem) == "Food")
            { cost.Category = "Food"; }
            cost.date = newCostDate.Value.Date;
            
            expenes.Add(cost);
            tab();

            this.Close();
        }
    }
}
