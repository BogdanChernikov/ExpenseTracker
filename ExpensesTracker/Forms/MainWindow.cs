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
        private List<AccountOperation> AccountOperations => TargetAccount.AccountOperations;
        private List<AccountOperation> _filteredOperations = new List<AccountOperation>();
        private List<Account> _accounts = new List<Account>();
        private readonly PdfGenerator _pdfGenerator = new PdfGenerator();
        private readonly Storage _storage = new Storage();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            startDateDisplay.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            endDateDisplay.Value = DateTime.Today;
            startDateDisplay.ValueChanged += DateTimePicker1_ValueChanged;
            endDateDisplay.ValueChanged += DateTimePicker2_ValueChanged;

            _accounts = _storage.GetAccounts();

            if (!_accounts.Any())
                CreateDefaultAccount();

            accountBox.DataSource = null;
            accountBox.DataSource = _accounts;
            accountBox.DisplayMember = "Name";

            operationsTable.AutoGenerateColumns = false;

            accountBox.SelectedIndex = 0;
            accountBox.SelectedIndexChanged += SelectedAccountBox_SelectedIndexChanged;

            categoryFilterBox.SelectedItem = "All categories";
            categoryFilterBox.SelectedIndexChanged += CategoryFilter_SelectedIndexChanged;

            SetupPlaceHolder();

            ShowBalance();
            ShowTable();
        }

        private void CreateDefaultAccount()
        {
            _accounts.Add(new Account()
            {
                Name = "Main",
                InitialBalance = 0,
                AccountOperations = new List<AccountOperation>()
            });
        }

        private void CategoryFilter_SelectedIndexChanged(object sender, EventArgs e) => ShowTable();

        private void SearchInput_TextChanged(object sender, EventArgs e) => ShowTable();

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e) => ShowTable();

        private void DateTimePicker2_ValueChanged(object sender, EventArgs e) => ShowTable();

        private void SelectedAccountBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowTable();
            ShowBalance();
        }

        private void FilterOperations()
        {
            _filteredOperations = TargetAccount.AccountOperations.ToList();

            //category Filtered
            var chosenCategory = Convert.ToString(categoryFilterBox.SelectedItem);

            if (chosenCategory != "All categories" && chosenCategory != "Incomes")
            {
                _filteredOperations = _filteredOperations.Where(x => Convert.ToString(x.Category) == chosenCategory)
                    .ToList();
            }

            if (chosenCategory == "Incomes")
            {
                _filteredOperations = _filteredOperations.Where(x => x.Type == OperationType.Income).ToList();
            }

            //name search
            if (!searchInput.IsPlaceHolderActive)
            {
                if (!string.IsNullOrWhiteSpace(searchInput.Text))
                {
                    _filteredOperations = _filteredOperations
                        .Where(x => x.Comment.Contains(searchInput.Text.Trim())).ToList();
                }
            }

            //data filter1
            _filteredOperations = _filteredOperations.Where(x => x.Date >= startDateDisplay.Value).ToList();

            //data filter2
            _filteredOperations = _filteredOperations.Where(x => x.Date <= endDateDisplay.Value).ToList();
        }

        private void RefreshData()
        {
            _storage.SaveChanges(_accounts);

            ShowTable();
            ShowBalance();
        }

        private void ActualizeTableRecords()
        {
            operationsTable.DataSource = null;
            operationsTable.DataSource = _filteredOperations;
            operationsTable.ClearSelection();
        }

        private void ColorTable()
        {
            for (var i = 0; i < _filteredOperations.Count; i++)
            {
                if (_filteredOperations[i].Type == OperationType.Expense)
                {
                    operationsTable.Rows[i].DefaultCellStyle.BackColor = Color.PaleVioletRed;
                }

                if (_filteredOperations[i].Type == OperationType.Income)
                {
                    operationsTable.Rows[i].DefaultCellStyle.BackColor = Color.DarkSeaGreen;
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

        private void RefreshAccountsData()
        {
            accountBox.SelectedIndexChanged -= (SelectedAccountBox_SelectedIndexChanged);
            accountBox.DataSource = null;
            accountBox.DataSource = _accounts;
            accountBox.DisplayMember = "Name";
            accountBox.SelectedIndexChanged += (SelectedAccountBox_SelectedIndexChanged);
            accountBox.SelectedItem = _accounts.First();
        }

        private void ShowBalance()
        {
            var expensesSum = AccountOperations
                .Where(x => x.Type == OperationType.Expense)
                .Sum(x => x.Amount);

            var incomesSum = AccountOperations
                .Where(x => x.Type == OperationType.Income)
                .Sum(x => x.Amount);

            accountBalanceLable.Text = @"On your balance  " + Convert.ToString
                (TargetAccount.InitialBalance - expensesSum + incomesSum, CultureInfo.InvariantCulture);
        }

        private void CreateAccountForm_Click(object sender, EventArgs e)
        {
            CreateAccount();
        }

        private void CreateAccount()
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
                        RefreshAccountsData();
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
                    RefreshAccountsData();
                    ShowBalance();
                    _storage.SaveChanges(_accounts);
                },

                OnAccountDeleted = () =>
                {
                    _accounts.Remove(TargetAccount);

                    if (!_accounts.Any())
                        CreateDefaultAccount();

                    accountBox.SelectedIndex = 0;
                    RefreshAccountsData();
                    RefreshData();
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
                    AccountOperations.Add(income);
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
                    AccountOperations.Add(expense);
                    RefreshData();
                }
            };
            createExpenseForm.Show();
        }

        private void OperationsTable_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            EditOperation();
        }

        private void EditOperationButton_Click(object sender, EventArgs e)
        {
            if (operationsTable.SelectedRows.Count == 0)
            {
                MessageBox.Show(@"You have not selected any operations");
                return;
            }

            EditOperation();
        }

        private void EditOperation()
        {
            if (operationsTable.SelectedRows.Count == 0 || !(operationsTable.SelectedRows[0].DataBoundItem is AccountOperation operation))
                return;

            if (operation.Type == OperationType.Expense)
            {
                var editExpenseForm = new EditExpenseForm
                {
                    TargetExpense = operation,
                    OnExpenseEdit = RefreshData,
                    OnExpenseDeleted = () =>
                    {
                        AccountOperations.Remove(operation);
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
                        AccountOperations.Remove(operation);
                        RefreshData();
                    }
                };
                editIncomeForm.Show();
            }
        }

        private void OperationsTable_SelectionChanged(object sender, EventArgs e)
        {
            if (operationsTable.SelectedRows.Count == 0 ||
                !(operationsTable.SelectedRows[0].DataBoundItem is AccountOperation operation))
                return;

            operationsTable.DefaultCellStyle.SelectionBackColor = operation.Type == OperationType.Expense
                ? Color.Brown
                : Color.DarkOliveGreen;
        }

        private void SetupPlaceHolder()
        {
            PlaceHolderTextBox placeHolderTextBox = searchInput;
            placeHolderTextBox.SetupPlaceHolder("Search", Color.DarkGray);
        }
    }
}
