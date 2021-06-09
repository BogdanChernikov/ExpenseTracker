using ExpensesTracker.Servises;
using ExpensesTracker.Models;
using ExpensesTracker.Models.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace ExpensesTracker.Forms
{
    public partial class MainWindow : Form
    {
        private Account TargetAccount => (Account)selectedAccountBox.SelectedItem;
        private List<AccountOperation> _filteredOperations = new List<AccountOperation>();
        private List<Account> _accounts = new List<Account>();
        private List<AccountOperation> _accountOperations = new List<AccountOperation>();
        private readonly PdfGenerator _pdfGenerator = new PdfGenerator();
        private readonly Storage _storage = new Storage();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            _accounts = _storage.GetAccount();
            _accountOperations = _storage.GetAccountOperations();
            selectedAccountBox.DataSource = null;
            selectedAccountBox.DataSource = _accounts;
            selectedAccountBox.DisplayMember = "Name";
            selectedAccountBox.SelectedIndex = 0;
            expensesTable.AutoGenerateColumns = false;
            categoryFilterBox.SelectedItem = "All amount";
        }

        private void CategoryFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterTable();
        }

        private void RefreshData()
        {
            _storage.SaveChanges(_accounts);
            _storage.SaveChanges(_accountOperations);
            RefreshTable();
            FilterTable();
            ShowBalance();
        }

        private void CommentSearch_TextChanged(object sender, EventArgs e)
        {
            FilterTable();
        }

        public void RefreshTable()
        {
            expensesTable.DataSource = null;
            expensesTable.DataSource = _filteredOperations;
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
            for (int i = 0; i < _filteredOperations.Count; i++)
            {
                if (_filteredOperations[i].Type == OperationType.Expense)
                {
                    expensesTable.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                }
                if (_filteredOperations[i].Type == OperationType.Income)
                {
                    expensesTable.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                }
            }
        }

        private void FilterTable()
        {
            FilterOperation();
            _filteredOperations.Sort((x, y) => x.Date.CompareTo(y.Date));
            RefreshTable();
            TableColoring();
        }

        private void FilterOperation()
        {
            _filteredOperations = _accountOperations.Where(x => x.Account.Name == TargetAccount.Name).ToList();
            //category Filtered
            var chosenCategory = Convert.ToString(categoryFilterBox.SelectedItem);

            if (chosenCategory != "All amount")
            {
                _filteredOperations = _filteredOperations.Where(x => Convert.ToString(x.Category) == chosenCategory).ToList();
            }

            //name search
            if (!string.IsNullOrWhiteSpace(searchNameInput.Text))
            {
                _filteredOperations = _filteredOperations.Where(x => x.Comment.Contains(searchNameInput.Text.Trim())).ToList();
            }

            //data filter1
            _filteredOperations = _filteredOperations.Where(x => x.Date >= startDateDisplay.Value).ToList();

            //data filter2
            _filteredOperations = _filteredOperations.Where(x => x.Date <= endDateDisplay.Value).ToList();
        }

        private void SavePdfButton_Click(object sender, EventArgs e)
        {
            _pdfGenerator.GeneratePdf(_filteredOperations);
        }

        private void ExpensesTable_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EditOperation();
        }

        private void EditExpenseButton_Click(object sender, EventArgs e)
        {
            EditOperation();
        }

        private void EditOperation()
        {
            var operation = expensesTable.SelectedRows[0].DataBoundItem as AccountOperation;
            if (operation != null && operation.Type == OperationType.Expense)
            {
                var editDataForm = new EditDataFormForExpense
                {
                    TargetExpense = operation,
                    OnExpenseEdit = RefreshData,
                    OnExpenseDeleted = () =>
                    {
                        if (true)
                        {
                            _accountOperations.Remove(operation);
                        }
                        RefreshData();
                    }
                };
                editDataForm.Show();
            }
            else
            {
                var editIncomeForm = new EditDataFormForIncome
                {
                    TargetIncome = operation,
                    OnIncomeEdit = RefreshData,
                    OnIncomeDeleted = () =>
                    {
                        {
                            _accountOperations.Remove(operation);
                        }
                        RefreshData();
                    }
                };
                editIncomeForm.Show();
            }
        }

        private void RefreshAccount()
        {
            selectedAccountBox.DataSource = null;
            selectedAccountBox.DataSource = _accounts;
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
            var expensesSum = _accountOperations.Where(x => x.Account.Name == TargetAccount.Name && x.Type == OperationType.Expense).Sum(x => x.Amount);
            var incomesSum = _accountOperations.Where(x => x.Account.Name == TargetAccount.Name && x.Type == OperationType.Income).Sum(x => x.Amount);
            accountBalance.Text = Convert.ToString(TargetAccount.InitialBalance - expensesSum + incomesSum, CultureInfo.InvariantCulture);
        }

        private void AddAccountForm_Click(object sender, EventArgs e)
        {
            var addAccountForm = new AddNewAccount
            {
                OnAccountAdded = (account) =>
                {
                    var accountVerification = _accounts.Count(x => x.Name == account.Name);
                    if (accountVerification > 0)
                    {
                        MessageBox.Show(@"An account with this name already exists. Choose another name.");
                    }
                    else
                    {
                        _accounts.Add(account);
                        RefreshAccount();
                        _storage.SaveChanges(_accounts);
                    }
                }
            };
            addAccountForm.Show();
        }

        private void EditAccountButton_Click(object sender, EventArgs e)
        {
            var editAccountForm = new EditAccount
            {
                TargetAccountForEdit = TargetAccount,
                OnAccountEdit = () =>
                {
                    RefreshAccount();
                    ShowBalance();
                    _storage.SaveChanges(_accounts);
                },
                OnAccountDeleted = () =>
                {
                    if (TargetAccount == null) return;
                    _accounts.Remove(TargetAccount);
                    selectedAccountBox.SelectedIndex = 0;
                    RefreshData();
                    RefreshAccount();
                }
            };
            editAccountForm.Show();
        }

        private void AddIncomeForm_Click(object sender, EventArgs e)
        {
            var addNewIncomeForm = new AddNewIncomeForm
            {
                OnIncomeAdded = (income) =>
                {
                    income.Account = TargetAccount;
                    _accountOperations.Add(income);
                    RefreshData();
                }
            };
            addNewIncomeForm.Show();
        }

        private void AddExpenseForm_Click(object sender, EventArgs e)
        {
            var addCostForm = new AddExpenseForm
            {
                OnExpenseAdded = (expense) =>
                {
                    expense.Account = TargetAccount;
                    _accountOperations.Add(expense);
                    RefreshData();
                }
            };
            addCostForm.Show();
        }
    }
}
