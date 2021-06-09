using ExpensesTracker.Services;
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
        private Account TargetAccount => (Account)accountBox.SelectedItem;
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
            _accounts = _storage.GetAccounts();
            _accountOperations = _storage.GetAccountOperations();

            accountBox.DataSource = null;
            accountBox.DataSource = _accounts;
            accountBox.DisplayMember = "Name";
            accountBox.SelectedIndex = 0;

            expensesTable.AutoGenerateColumns = false;
            categoryFilterBox.SelectedItem = "All amount";
        }

        private void CategoryFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowTable();
        }

        private void CommentSearch_TextChanged(object sender, EventArgs e)
        {
            ShowTable();
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            ShowTable();
        }

        private void DateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            ShowTable();
        }

        public void SelectedAccountBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (accountBox.SelectedIndex == -1)
                accountBox.SelectedIndex = 0; /*TODO: Fix it later*/
            ShowTable();
            ShowBalance();
        }

        private void FilterOperations()
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

        private void RefreshData()
        {
            _storage.SaveChanges(_accounts);
            _storage.SaveChanges(_accountOperations);

            ShowTable();
            ShowBalance();
        }

        public void ActualizeTableRecords()
        {
            expensesTable.DataSource = null;
            expensesTable.DataSource = _filteredOperations;
            expensesTable.Columns[4].Visible = false;
            expensesTable.Columns[5].Visible = false;
        }

        private void ColorTable()
        {
            for (var i = 0; i < _filteredOperations.Count; i++)
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

        private void ShowTable()
        {
            FilterOperations();
            _filteredOperations.Sort((x, y) => x.Date.CompareTo(y.Date));
            ActualizeTableRecords();
            ColorTable();
        }

        private void SavePdfButton_Click(object sender, EventArgs e)
        {
            _pdfGenerator.GeneratePdf(_filteredOperations);
        }

        private void RefreshAccount()
        {
            accountBox.DataSource = null;
            accountBox.DataSource = _accounts;
            accountBox.DisplayMember = "Name";
            accountBox.SelectedItem = TargetAccount;
        }

        public void ShowBalance()
        {
            var expensesSum = _accountOperations
                .Where(x => x.Account.Name == TargetAccount.Name && x.Type == OperationType.Expense)
                .Sum(x => x.Amount);

            var incomesSum = _accountOperations
                .Where(x => x.Account.Name == TargetAccount.Name && x.Type == OperationType.Income)
                .Sum(x => x.Amount);

            accountBalanceLable.Text = Convert.ToString
                (TargetAccount.InitialBalance - expensesSum + incomesSum, CultureInfo.InvariantCulture);
        }

        private void CreateAccountForm_Click(object sender, EventArgs e)
        {
            var createAccountForm = new CreateAccountForm
            {
                OnAccountAdded = (account) =>
                {
                    if (_accounts.Any(x => x.Name == account.Name))
                    {
                        MessageBox.Show(@"This account name is already in use. Choose another name");
                    }
                    else
                    {
                        _accounts.Add(account);
                        RefreshAccount();
                        _storage.SaveChanges(_accounts);
                    }
                }
            };
            createAccountForm.Show();
        }

        private void EditAccountButton_Click(object sender, EventArgs e)
        {
            var editAccountForm = new EditAccountForm
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
                    _accounts.Remove(TargetAccount);
                    accountBox.SelectedIndex = 0;
                    RefreshData();
                    RefreshAccount();
                }
            };
            editAccountForm.Show();
        }

        private void CreateIncomeForm_Click(object sender, EventArgs e)
        {
            var createIncomeForm = new CreateIncomeForm
            {
                OnIncomeAdded = (income) =>
                {
                    income.Account = TargetAccount;
                    _accountOperations.Add(income);
                    RefreshData();
                }
            };
            createIncomeForm.Show();
        }

        private void CreateExpenseForm_Click(object sender, EventArgs e)
        {
            var createExpenseForm = new CreateExpenseForm
            {
                OnExpenseAdded = (expense) =>
                {
                    if (expense.Category == null)
                    {
                        MessageBox.Show(@"You don't select a category.To save the expense, select the expense category");
                    }
                    else
                    {
                        expense.Account = TargetAccount;
                        _accountOperations.Add(expense);
                        RefreshData();
                    }
                }
            };
            createExpenseForm.Show();
        }

        private void ExpensesTable_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EditOperation();
        }

        private void EditExpenseButton_Click(object sender, EventArgs e)
        {
            if (expensesTable.SelectedRows.Count == 0)
            {
                MessageBox.Show(@"You have not selected any operations");
                return;
            }
            EditOperation();
        }

        private void EditOperation()
        {
            var operation = expensesTable.SelectedRows[0].DataBoundItem as AccountOperation;
            if (operation == null)
                return;

            if (operation.Type == OperationType.Expense)
            {
                var editExpenseForm = new EditExpenseForm
                {
                    TargetExpense = operation,
                    OnExpenseEdit = RefreshData,
                    OnExpenseDeleted = () =>
                    {
                        _accountOperations.Remove(operation);
                        RefreshData();
                    }
                };
                editExpenseForm.Show();
            }

            else
            {
                var editIncomeForm = new EditIncomeForm
                {
                    TargetIncome = operation,
                    OnIncomeEdit = RefreshData,
                    OnIncomeDeleted = () =>
                    {
                        _accountOperations.Remove(operation);
                        RefreshData();
                    }
                };
                editIncomeForm.Show();
            }
        }
    }
}
