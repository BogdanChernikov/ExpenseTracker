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
        private Account TargetAccount => (Account)selectedAccountBox.SelectedItem;

        public MainWindow()
        {
            InitializeComponent();
            expensesTable.AutoGenerateColumns = false;
            categoryFilterBox.SelectedItem = "All costs";
            startDateDisplay.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.MinValue.Day);
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
            filteredExpenses = expenses.Where(x => x.Account.Name == TargetAccount.Name).ToList();

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

            XmlSerializer acc = new XmlSerializer(typeof(List<Account>));
            string accou = "account.txt";
            var stream1 = new FileStream(accou, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            accounts = (List<Account>)acc.Deserialize(stream1);

            stream.Close();

            selectedAccountBox.DataSource = null;
            selectedAccountBox.DataSource = accounts;
            selectedAccountBox.DisplayMember = "Name";
        }

        public void SaveChanges()
        {
            XmlSerializer ser = new XmlSerializer(typeof(List<Expense>));
            string path = "list.txt";
            FileStream stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
            ser.Serialize(stream, expenses);
            stream.Close();

            XmlSerializer acc = new XmlSerializer(typeof(List<Account>));
            string accou = "account.txt";
            FileStream stream1 = new FileStream(accou, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
            acc.Serialize(stream1, accounts);
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

        private void ExpensesTable_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EditExpense();
        }

        private void EditExpensButton_Click(object sender, EventArgs e)
        {
            EditExpense();
        }

        private void AddExpenseForm_Click(object sender, EventArgs e)
        {
            AddExpenseForm addExpenseForm = new AddExpenseForm();
            Account account = (Account)selectedAccountBox.SelectedItem;
            addExpenseForm.OnExpenseAdded = (expense) =>
            {
                expense.Account = (Account)selectedAccountBox.SelectedItem;
                expenses.Add(expense);
                FilterTable();
                ShowBalance();
                SaveChanges();
            };
            addExpenseForm.Show();
        }

        private void EditExpense()
        {
            foreach (DataGridViewRow row in this.expensesTable.SelectedRows)
            {
                var expense = row.DataBoundItem as Expense;
                EditDataForm editDataForm = new EditDataForm();
                editDataForm.TargetExpense = expense;
                editDataForm.OnExpenseEdit = () =>
                {
                    FilterTable();
                    ShowBalance();
                    SaveChanges();
                };
                editDataForm.OnExpenseDeleted = () =>
                {
                    if (expense != null)
                    {
                        expenses.Remove(expense);
                        FilterTable();
                        ShowBalance();
                        SaveChanges();
                    }
                };
                editDataForm.Show();
            }
        }

        private void RefreshAccount()
        {
            selectedAccountBox.DataSource = null;
            selectedAccountBox.DataSource = accounts;
            selectedAccountBox.DisplayMember = "Name";
            selectedAccountBox.SelectedItem = TargetAccount;
        }

        public void SelectedAccountBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectedAccountBox.SelectedIndex == -1)
                selectedAccountBox.SelectedIndex = 0; /*TODO: Fix it later*/
            FilterTable();
            ShowBalance();
        }

        public void ShowBalance()
        {
            var expensesSum = expenses.Where(x => x.Account.Name == TargetAccount.Name).Sum(x => x.Cost);
            accountBalance.Text = Convert.ToString(TargetAccount.InitialBalance - expensesSum);
        }

        private void AddAccountForm_Click(object sender, EventArgs e)
        {
            AddNewAccount addAccountForm = new AddNewAccount();
            addAccountForm.OnAccountAdded = (account) =>
            {
                accounts.Add(account);
                RefreshAccount();
                SaveChanges();
            };
            addAccountForm.Show();
        }

        private void EditAccountButton_Click(object sender, EventArgs e)
        {
            Account account = (Account)selectedAccountBox.SelectedItem;
            EditAccount editAccountForm = new EditAccount();
            editAccountForm.TargetAccount = account;
            editAccountForm.OnAccountEdit = () =>
            {
                RefreshAccount();
                ShowBalance();
                SaveChanges();
            };
            editAccountForm.OnAccountDeleted = () =>
             {
                 if (account != null)
                 {
                     accounts.Remove(account);

                 }
                 selectedAccountBox.SelectedIndex = 0;
             };

            editAccountForm.Show();
        }
    }
}