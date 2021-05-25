using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace WindowsFormsApp2
{
    public partial class IncomeForm : Form
    {
        public Account TargetAccount;
        public List<Income> Incomes;
        public Action<Income> addIncome;

        public IncomeForm()
        {
            InitializeComponent();
            incomesesTable.AutoGenerateColumns = false;
        }
        public void RefreshTable()
        {
            incomesesTable.DataSource = null;
            incomesesTable.DataSource = Incomes;
        }

        private void AddIncomeButton_Click(object sender, EventArgs e)
        {
            AddNewIncomeForm addNewIncomeForm = new AddNewIncomeForm();
            addNewIncomeForm.IncomeAccount = TargetAccount;
            addNewIncomeForm.onIncomeAdded = (income) =>
            {
                RefreshTable();
                addIncome(income);

                RefreshTable();
            };
            addNewIncomeForm.Show();
        }

        private void IncomeForm_Load(object sender, EventArgs e)
        {
            XmlSerializer ser = new XmlSerializer(typeof(List<Income>));
            string path = "income.txt";
            var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            Incomes = (List<Income>)ser.Deserialize(stream);
            stream.Close();

            RefreshTable();
        }
    }
}
