using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace WindowsFormsApp2
{
    public partial class MainWindow : Form
    {
        private List<Expense> expenses = new List<Expense>();
        private List<Expense> filteredExpenses = new List<Expense>();
        private List<Account> accounts = new List<Account>();
        public delegate void CostRow();
        public delegate void RefreshData();

        public MainWindow()
        {
            InitializeComponent();
            expensesTable.AutoGenerateColumns = false;
            categoryFilterBox.SelectedItem = "All costs";
            startDateDisplay.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.MinValue.Day);
        }

        private void OpenAddForm_Click(object sender, EventArgs e)
        {
            AddCostForm addCostForm = new AddCostForm();
            addCostForm.OnExpenseAdded = (expense) =>
            {
                expenses.Add(expense);
            };
            addCostForm.Show();
        }


        private void DeleteCostButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.expensesTable.SelectedRows)
            {
                var expense = row.DataBoundItem as Expense;
                if (expense != null)
                {
                    expenses.Remove(expense);
                }
            }
            FilterTable();
            SaveChanges();
        }

        private void CategoryFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterTable();
        }

        private void CommentSearch_TextChanged(object sender, EventArgs e)
        {
            FilterTable();
        }

        public void RefreshTable()
        {
            expensesTable.DataSource = null;
            expensesTable.DataSource = filteredExpenses;
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            FilterTable();
        }

        private void DateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            FilterTable();
        }

        private void FilterTable()
        {
            filteredExpenses = expenses.ToList();

            //category Filtred
            var chosenCategory = Convert.ToString(categoryFilterBox.SelectedItem);

            if (chosenCategory != "All costs")
            {
                filteredExpenses = filteredExpenses.Where(x => Convert.ToString(x.Category) == chosenCategory).ToList();
            }

            //name search
            if (!string.IsNullOrWhiteSpace(searchNameInput.Text))
            {
                filteredExpenses = filteredExpenses.Where(x => x.Comment.Contains(searchNameInput.Text.Trim())).ToList();
            }

            //data filrer1
            filteredExpenses = filteredExpenses.Where(x => x.Date >= startDateDisplay.Value).ToList();

            //data filter2
            filteredExpenses = filteredExpenses.Where(x => x.Date <= endDateDisplay.Value).ToList();

            RefreshTable();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            XmlSerializer ser = new XmlSerializer(typeof(List<Expense>));
            string path = "list.txt";
            var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            expenses = (List<Expense>)ser.Deserialize(stream);

            stream.Close();
            filteredExpenses = expenses.ToList();
            RefreshTable();
        }

        private void SaveChanges()
        {
            XmlSerializer ser = new XmlSerializer(typeof(List<Expense>));
            string path = "list.txt";
            FileStream stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
            ser.Serialize(stream, expenses);
            stream.Close();
        }

        private void SavePdfButton_Click(object sender, EventArgs e)
        {
            iTextSharp.text.Document doc = new iTextSharp.text.Document();

            PdfWriter.GetInstance(doc, new FileStream("pdfTables.pdf", FileMode.Create));

            doc.Open();

            PdfPTable table = new PdfPTable(expensesTable.Columns.Count);

            for (int j = 0; j < expensesTable.Columns.Count; j++)
            {
                var cell = new PdfPCell(new Phrase(expensesTable.Columns[j].HeaderText));

                table.AddCell(cell);
            }

            for (int j = 0; j < expensesTable.Rows.Count; j++)
            {
                for (int k = 0; k < expensesTable.Columns.Count; k++)
                {
                    table.AddCell(new Phrase(expensesTable[k, j].Value.ToString()));
                }
            }

            doc.Add(table);
            doc.Close();
            MessageBox.Show("Pdf seved");
        }

        private void addAccountForm_Click(object sender, EventArgs e)
        {
            AddNewAccount addAccountForm = new AddNewAccount();
            addAccountForm.Account = accounts;
            addAccountForm.Show();
        }

        private void costsTable_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EditDataForm editDataForm = new EditDataForm();
            editDataForm.expenes = expenses;
            editDataForm.Show();
        }
    }
}