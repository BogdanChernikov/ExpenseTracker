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
        List<Expenses> expenses = new List<Expenses>();
        List<Expenses> filteredExpenses = new List<Expenses>();
        List<Account> accounts = new List<Account>();
        public delegate void CostRow();
        

        public MainWindow()
        {
            InitializeComponent();
            categoryFilterBox.SelectedItem = "All costs";
            startDateDisplay.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.MinValue.Day);
        }

        private void OpenAddForm_Click(object sender, EventArgs e)
        {
            AddCostForm addCostForm = new AddCostForm();
            addCostForm.expenes = expenses;
            addCostForm.tab = ShowCosts;
            addCostForm.Show();
        }

        public void ShowCosts()
        {
            int costCount = expenses.Count;

            for (int i = costCount - 1; i < costCount; i++)
            {
                DataGridViewCell date = new DataGridViewTextBoxCell();
                DataGridViewCell category = new DataGridViewTextBoxCell();
                DataGridViewCell price = new DataGridViewTextBoxCell();
                DataGridViewCell coment = new DataGridViewTextBoxCell();
                price.Value = expenses[i].cost;
                coment.Value = expenses[i].comment;
                category.Value = expenses[i].Category;
                date.Value = expenses[i].date;

                DataGridViewRow row = new DataGridViewRow();
                row.Cells.AddRange(date, category, price, coment);
                costsTable.Rows.Add(row);
            }
            SaveChanges();
        }

        private void DeleteCostButton_Click(object sender, EventArgs e)
        {
            int row = costsTable.SelectedCells[0].RowIndex;
            costsTable.Rows.RemoveAt(row);
            expenses.RemoveAt(row);
            SaveChanges();
        }

        private void CategoryFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterTable();
        }

        private void NameSearch_TextChanged(object sender, EventArgs e)
        {
            FilterTable();
        }

        public void FillTable()
        {
            int costCount = filteredExpenses.Count;
            costsTable.Rows.Clear();
            for (int i = 0; i < costCount; i++)
            {
                DataGridViewCell date = new DataGridViewTextBoxCell();
                // DataGridViewCell name = new DataGridViewTextBoxCell();
                DataGridViewCell category = new DataGridViewTextBoxCell();
                DataGridViewCell price = new DataGridViewTextBoxCell();
                DataGridViewCell coment = new DataGridViewTextBoxCell();
                // name.Value = filteredExpenses[i].name;
                price.Value = filteredExpenses[i].cost;
                coment.Value = filteredExpenses[i].comment;
                category.Value = filteredExpenses[i].Category;
                date.Value = filteredExpenses[i].date;

                DataGridViewRow row = new DataGridViewRow();
                row.Cells.AddRange(date, category, price, coment);
                costsTable.Rows.Add(row);
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            FilterTable();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
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

                for (int i = 0; i < costsTable.Rows.Count; i++)
                {
                    if (!costsTable[3, i].FormattedValue.ToString().Contains(searchNameInput.Text.Trim()))
                    {
                        filteredExpenses.Remove(expenses[i]);
                    }
                }
            }

            //data filrer1
            filteredExpenses = filteredExpenses.Where(x => x.date >= startDateDisplay.Value).ToList();

            //data filter2
            filteredExpenses = filteredExpenses.Where(x => x.date <= endDateDisplay.Value).ToList();

            FillTable();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

            XmlSerializer ser = new XmlSerializer(typeof(List<Expenses>));
            string path = "list.txt";
            var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            expenses = (List<Expenses>)ser.Deserialize(stream);

            stream.Close();
            filteredExpenses = expenses.ToList();
            FillTable();
        }

        private void SaveChanges()
        {
            XmlSerializer ser = new XmlSerializer(typeof(List<Expenses>));
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

            PdfPTable table = new PdfPTable(costsTable.Columns.Count);


            for (int j = 0; j < costsTable.Columns.Count; j++)
            {
                var cell = new PdfPCell(new Phrase(costsTable.Columns[j].HeaderText));

                table.AddCell(cell);
            }

            for (int j = 0; j < costsTable.Rows.Count; j++)
            {
                for (int k = 0; k < costsTable.Columns.Count; k++)
                {
                    table.AddCell(new Phrase(costsTable[k, j].Value.ToString()));
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
            EditDataForm editDataForm= new EditDataForm();
            editDataForm.expenes = expenses;
            editDataForm.tab = ShowCosts;
            editDataForm.Show();
        }
    }
}