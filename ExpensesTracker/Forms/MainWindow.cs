using ExpensesTracker.Models.Enums;
using ExpensesTracker.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Account = ExpensesTracker.Models.Account;
using AccountOperation = ExpensesTracker.Models.AccountOperation;

namespace ExpensesTracker.Forms
{
    public partial class MainWindow : Form
    {
        private List<AccountOperation> _filteredOperations;
        private readonly PdfGenerator _pdfGenerator = new PdfGenerator();
        private readonly Storage _storage;

        private Account GetSelectedAccount() => (Account)accountBox.SelectedItem;
        private List<AccountOperation> GetSelectedAccountOperations() => GetSelectedAccount().AccountOperations;

        public MainWindow()
        {
            InitializeComponent();

            _storage = new Storage(GetSelectedAccount());
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            startDateDisplay.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            endDateDisplay.Value = DateTime.Today;
            startDateDisplay.ValueChanged += DateTimePicker1_ValueChanged;
            endDateDisplay.ValueChanged += DateTimePicker2_ValueChanged;

            _storage.EnsureAccountExists();

            categoryFilterBox.SelectedItem = "All categories";
            categoryFilterBox.SelectedIndexChanged += CategoryFilter_SelectedIndexChanged;

            RefreshListOfAccountsInAccountsBox();

            RefreshTableAndBalance();

            SetupPlaceHolder();
        }

        private void CategoryFilter_SelectedIndexChanged(object sender, EventArgs e) => RefreshTable();

        private void SearchInput_TextChanged(object sender, EventArgs e) => RefreshTable();

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e) => RefreshTable();

        private void DateTimePicker2_ValueChanged(object sender, EventArgs e) => RefreshTable();

        private void SelectedAccountBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshTableAndBalance();
        }

        private void FilterOperations()
        {
            _filteredOperations = GetSelectedAccountOperations();

            //category Filtered
            var chosenCategory = Convert.ToString(categoryFilterBox.SelectedItem);

            if (chosenCategory != "All categories" && chosenCategory != "Incomes")
            {
                _filteredOperations = _filteredOperations.Where(x => x.Category == chosenCategory)
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

        private void RefreshTableAndBalance()
        {
            RefreshTable();
            RefreshBalance();
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

        private void RefreshTable()
        {
            FilterOperations();

            ActualizeTableRecords();
            ColorTable();
        }

        private void SavePdfButton_Click(object sender, EventArgs e)
        {
            _pdfGenerator.GeneratePdf(_filteredOperations);
        }

        private void RefreshListOfAccountsInAccountsBox(Account accountToUse = null)
        {
            accountToUse = accountToUse ?? _storage.Accounts.First();

            accountBox.SelectedIndexChanged -= SelectedAccountBox_SelectedIndexChanged;

            accountBox.DataSource = null;
            accountBox.DataSource = _storage.Accounts;

            accountBox.DisplayMember = "Name";

            accountBox.SelectedItem = accountToUse;

            accountBox.SelectedIndexChanged += SelectedAccountBox_SelectedIndexChanged;
        }

        private void RefreshBalance()
        {
            var expensesSum = GetSelectedAccountOperations()
                .Where(x => x.Type == OperationType.Expense)
                .Sum(x => x.Amount);

            var incomesSum = GetSelectedAccountOperations()
                .Where(x => x.Type == OperationType.Income)
                .Sum(x => x.Amount);

            accountBalanceLable.Text = @"On your balance  " + Convert.ToString
                (GetSelectedAccount().InitialBalance - expensesSum + incomesSum, CultureInfo.InvariantCulture);
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
                    var operationResult = _storage.AddAccount(account);
                    if (!operationResult.Success)
                    {
                        MessageBox.Show(operationResult.ErrorMassage);
                        return;
                    }

                    RefreshListOfAccountsInAccountsBox(GetSelectedAccount());
                }
            };
            createAccountForm.Show();
        }

        private void EditAccountButton_Click(object sender, EventArgs e)
        {
            var editAccountForm = new EditAccountForm
            {
                TargetAccountForEdit = GetSelectedAccount(),
                OnAccountEdit = editedAccountModel =>
                {
                    var operationResult = _storage.EditAccount(editedAccountModel);
                    if (!operationResult.Success)
                    {
                        MessageBox.Show(operationResult.ErrorMassage);
                        return;
                    }

                    RefreshListOfAccountsInAccountsBox(GetSelectedAccount());
                    RefreshBalance();
                },

                OnAccountDeleted = () =>
                {
                    _storage.DeleteAccount(GetSelectedAccount());

                    RefreshListOfAccountsInAccountsBox();
                    RefreshTableAndBalance();
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
                    _storage.CreateOperation(income, GetSelectedAccount().Id);
                    GetSelectedAccount().AccountOperations.Add(income);
                    RefreshTableAndBalance();
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
                    _storage.CreateOperation(expense, GetSelectedAccount().Id);
                    GetSelectedAccount().AccountOperations.Add(expense);
                    RefreshTableAndBalance();
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
                    OnExpenseEdit = editOperation =>
                    {
                        _storage.EditOperation(editOperation);
                        RefreshTableAndBalance();
                    },

                    OnExpenseDeleted = () =>
                    {
                        GetSelectedAccountOperations().Remove(operation);
                        _storage.DeleteOperation(operation);
                        RefreshTableAndBalance();
                    }
                };
                editExpenseForm.Show();
            }
            else
            {
                var editIncomeForm = new EditIncomeForm
                {
                    TargetIncome = operation,
                    OnIncomeEdit = editOperation =>
                    {
                        _storage.EditOperation(editOperation);
                        RefreshTableAndBalance();
                    },
                    OnIncomeDeleted = () =>
                    {
                        GetSelectedAccountOperations().Remove(operation);
                        _storage.DeleteOperation(operation);
                        RefreshTableAndBalance();
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
            var placeHolderTextBox = searchInput;
            placeHolderTextBox.SetupPlaceHolder("Search", Color.DarkGray);
        }
    }
}
