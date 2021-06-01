using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace WindowsFormsApp2
{
    public partial class MainWindow : Form
    {
        private List<Expense> expenses = new List<Expense>();
        private List<AccountOperation> filteredOperations = new List<AccountOperation>();
        private List<Account> accounts = new List<Account>();
        private Account TargetAccount { get; set; }
        private List<Income> incomes = new List<Income>();
        private List<AccountOperation> accountOperations = new List<AccountOperation>();

        public MainWindow()
        {
            InitializeComponent();
            XmlSerializer acc = new XmlSerializer(typeof(List<Account>));
            string accou = "account.txt";
            var stream1 = new FileStream(accou, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            accounts = (List<Account>)acc.Deserialize(stream1);

            stream1.Close();

            selectedAccountBox.DataSource = null;
            selectedAccountBox.DataSource = accounts;
            selectedAccountBox.DisplayMember = "Name";
            expensesTable.AutoGenerateColumns = false;
            categoryFilterBox.SelectedItem = "All costs";
            startDateDisplay.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.MinValue.Day);
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            XmlSerializer ser = new XmlSerializer(typeof(List<Expense>));
            string path = "list.txt";
            var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            expenses = (List<Expense>)ser.Deserialize(stream);
            stream.Close();
            filteredOperations = accountOperations.ToList();

            XmlSerializer incom = new XmlSerializer(typeof(List<Income>));
            string inc = "income.txt";
            var stream2 = new FileStream(inc, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            incomes = (List<Income>)incom.Deserialize(stream2);

            stream2.Close();

            XmlSerializer accountOperation = new XmlSerializer(typeof(List<AccountOperation>));
            string operat = "accountOperations.txt";
            var streamoperation = new FileStream(operat, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            accountOperations = (List<AccountOperation>)accountOperation.Deserialize(streamoperation);

            streamoperation.Close();

            selectedAccountBox.DataSource = null;
            selectedAccountBox.DataSource = accounts;
            selectedAccountBox.DisplayMember = "Name";
            selectedAccountBox.SelectedIndex = 0;

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
            expensesTable.DataSource = filteredOperations;
            expensesTable.Columns[4].Visible = false;
            expensesTable.Columns[5].Visible = false;
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            FilterTable();
        }

        private void DateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            FilterTable();
        }

        private void TableColoring()
        {
            for (int i = 0; i < filteredOperations.Count; i++)
            {
                if (filteredOperations[i].Type == "expense")
                {
                    expensesTable.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                }
                if (filteredOperations[i].Type == "income")
                {
                    expensesTable.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                }
            }
        }

        private void FilterTable()
        {
            filteredOperations = new List<AccountOperation>();
            filteredOperations = accountOperations.Where(x => x.Account.Name == TargetAccount.Name).ToList();
            filteredOperations.Sort((x, y) => x.Date.CompareTo(y.Date));

            //category Filtred
            var chosenCategory = Convert.ToString(categoryFilterBox.SelectedItem);

            if (chosenCategory != "All costs")
            {
                filteredOperations = filteredOperations.Where(x => Convert.ToString(x.Category) == chosenCategory).ToList();
            }

            //name search
            if (!string.IsNullOrWhiteSpace(searchNameInput.Text))
            {
                filteredOperations = filteredOperations.Where(x => x.Comment.Contains(searchNameInput.Text.Trim())).ToList();
            }

            //data filrer1
            filteredOperations = filteredOperations.Where(x => x.Date >= startDateDisplay.Value).ToList();

            //data filter2
            filteredOperations = filteredOperations.Where(x => x.Date <= endDateDisplay.Value).ToList();
            RefreshTable();
            TableColoring();
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
            stream1.Close();

            XmlSerializer inc = new XmlSerializer(typeof(List<Income>));
            string inco = "income.txt";
            FileStream ino = new FileStream(inco, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
            inc.Serialize(ino, incomes);
            ino.Close();

            XmlSerializer accountOperation = new XmlSerializer(typeof(List<AccountOperation>));
            string operat = "accountOperations.txt";
            FileStream streamoperation = new FileStream(operat, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
            accountOperation.Serialize(streamoperation, accountOperations);
            streamoperation.Close();
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
            EditOperation();
        }

        private void EditExpensButton_Click(object sender, EventArgs e)
        {
            EditOperation();
        }

        private void EditOperation()
        {
            foreach (DataGridViewRow row in this.expensesTable.SelectedRows)
            {
                var operation = row.DataBoundItem as AccountOperation;
                if (operation.Type == "expense")
                {
                    EditDataFormForExpense editDataForm = new EditDataFormForExpense();
                    editDataForm.TargetExpense = operation;
                    editDataForm.OnExpenseEdit = () =>
                    {
                        SaveChanges();
                        RefreshTable();
                        FilterTable();
                        ShowBalance();
                    };
                    editDataForm.OnExpenseDeleted = () =>
                    {
                        if (operation != null)
                        {
                            accountOperations.Remove(operation);
                        }
                        RefreshTable();
                        FilterTable();
                        ShowBalance();
                        SaveChanges();
                    };
                    editDataForm.Show();
                }
                else
                {
                    EditDataFormForIncome editIncomeForm = new EditDataFormForIncome();
                    editIncomeForm.TargetIncome = operation;
                    editIncomeForm.OnIncomeEdit = () =>
                    {
                        RefreshTable();
                        FilterTable();
                        ShowBalance();
                        SaveChanges();
                    };
                    editIncomeForm.OnIncomeDeleted = () =>
                    {
                        if (operation != null)
                        {
                            accountOperations.Remove(operation);
                        }
                        RefreshTable();
                        FilterTable();
                        ShowBalance();
                        SaveChanges();
                    };
                    editIncomeForm.Show();
                }
            }
        }

        private void RefreshAccount()
        {
            TargetAccount = (Account)selectedAccountBox.SelectedItem;
            selectedAccountBox.DataSource = null;
            selectedAccountBox.DataSource = accounts;
            selectedAccountBox.DisplayMember = "Name";
            selectedAccountBox.SelectedItem = TargetAccount;
        }

        public void SelectedAccountBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectedAccountBox.SelectedIndex == -1)
                selectedAccountBox.SelectedIndex = 0;
            TargetAccount = (Account)selectedAccountBox.SelectedItem;
            FilterTable();
            ShowBalance();
        }

        public void ShowBalance()
        {
            var expensesSum = accountOperations.Where(x => x.Account.Name == TargetAccount.Name && x.Type == "expense").Sum(x => x.Cost);
            var incomesSum = accountOperations.Where(x => x.Account.Name == TargetAccount.Name && x.Type == "income").Sum(x => x.Cost);
            accountBalance.Text = Convert.ToString(TargetAccount.InitialBalance - expensesSum + incomesSum);
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
            editAccountForm.Accounts = accounts;
            editAccountForm.accountBox = selectedAccountBox;
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
            };
            editAccountForm.Show();
        }

        private void AddIncomeForm_Click(object sender, EventArgs e)
        {
            AddNewIncomeForm addNewIncomeForm = new AddNewIncomeForm();
            addNewIncomeForm.onIncomeAdded = (income) =>
            {
                income.Account = TargetAccount;
                incomes.Add(income);
                var operation = new AccountOperation();
                operation.Account = (Account)selectedAccountBox.SelectedItem;
                operation.Category = income.Category;
                operation.Comment = income.Comment;
                operation.Cost = income.Cost;
                operation.Date = income.Date;
                operation.Type = "income";
                accountOperations.Add(operation);
                SaveChanges();
                RefreshTable();
                FilterTable();
                ShowBalance();
            };
            addNewIncomeForm.Show();
        }
        private void AddExpenseForm_Click(object sender, EventArgs e)
        {
            AddExpenseForm addCostForm = new AddExpenseForm();
            Account account = (Account)selectedAccountBox.SelectedItem;
            addCostForm.OnExpenseAdded = (expense) =>
            {
                expense.Account = (Account)selectedAccountBox.SelectedItem;
                expenses.Add(expense);
                var operation = new AccountOperation();
                operation.Account = (Account)selectedAccountBox.SelectedItem;
                operation.Category = expense.Category;
                operation.Comment = expense.Comment;
                operation.Cost = expense.Cost;
                operation.Date = expense.Date;
                operation.Type = "expense";
                accountOperations.Add(operation);
                SaveChanges();
                RefreshTable();
                FilterTable();
                ShowBalance();
            };
            addCostForm.Show();
        }
    }
}