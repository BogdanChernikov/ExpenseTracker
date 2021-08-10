using ExpensesTracker.Models.Enums;
using ExpensesTracker.Models.RequestModels;
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
        private readonly PdfGenerator _pdfGenerator;
        private readonly StateManager _stateManager;

        private Account GetSelectedAccount() => (Account)accountBox.SelectedItem;
        private List<AccountOperation> GetSelectedAccountOperations() => GetSelectedAccount().AccountOperations;

        public MainWindow()
        {
            InitializeComponent();

            _pdfGenerator = new PdfGenerator();
            _stateManager = new StateManager();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            startDateDisplay.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            endDateDisplay.Value = DateTime.Today;
            startDateDisplay.ValueChanged += DateTimePicker1_ValueChanged;
            endDateDisplay.ValueChanged += DateTimePicker2_ValueChanged;

            _stateManager.Initialize();
            _stateManager.EnsureAccountExists();

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

        private List<AccountOperation> GetFilteredOperations()
        {
            return _stateManager.GetFilteredOperations(new OperationsQueryFilter
            {
                Category = Convert.ToString(categoryFilterBox.SelectedItem),
                EndDate = endDateDisplay.Value,
                StartDate = startDateDisplay.Value,
                Id = GetSelectedAccount().Id,
                SearchText = !searchInput.IsPlaceHolderActive ? searchInput.Text : null
            });
        }

        private void RefreshTableAndBalance()
        {
            RefreshTable();
            RefreshBalance();
        }

        private void ActualizeTableRecords()
        {
            operationsTable.DataSource = null;
            operationsTable.DataSource = GetFilteredOperations();
            operationsTable.ClearSelection();
        }

        private void ColorTable()
        {
            var filteredOperations = GetFilteredOperations();
            for (var i = 0; i < filteredOperations.Count; i++)
            {
                if (filteredOperations[i].Type == OperationType.Expense)
                {
                    operationsTable.Rows[i].DefaultCellStyle.BackColor = Color.PaleVioletRed;
                }

                if (filteredOperations[i].Type == OperationType.Income)
                {
                    operationsTable.Rows[i].DefaultCellStyle.BackColor = Color.DarkSeaGreen;
                }
            }
        }

        private void RefreshTable()
        {
            GetFilteredOperations();

            ActualizeTableRecords();
            ColorTable();
        }

        private void SavePdfButton_Click(object sender, EventArgs e)
        {
            _pdfGenerator.GeneratePdf(GetFilteredOperations());
        }

        private void RefreshListOfAccountsInAccountsBox(Account accountToUse = null)
        {
            accountToUse = accountToUse ?? _stateManager.Accounts.First();

            accountBox.SelectedIndexChanged -= SelectedAccountBox_SelectedIndexChanged;

            accountBox.DataSource = null;
            accountBox.DataSource = _stateManager.Accounts;

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
                    var operationResult = _stateManager.CreateAccount(account);
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
                    var operationResult = _stateManager.EditAccount(editedAccountModel);
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
                    _stateManager.DeleteAccount(GetSelectedAccount());

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
                    _stateManager.CreateOperation(income, GetSelectedAccount().Id);
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
                    _stateManager.CreateOperation(expense, GetSelectedAccount().Id);
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
                        _stateManager.EditOperation(editOperation, GetSelectedAccount().Id);
                        RefreshTableAndBalance();
                    },

                    OnExpenseDeleted = () =>
                    {
                        _stateManager.DeleteOperation(operation, GetSelectedAccount().Id);
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
                        _stateManager.EditOperation(editOperation, GetSelectedAccount().Id);
                        RefreshTableAndBalance();
                    },
                    OnIncomeDeleted = () =>
                    {
                        _stateManager.DeleteOperation(operation, GetSelectedAccount().Id);
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
