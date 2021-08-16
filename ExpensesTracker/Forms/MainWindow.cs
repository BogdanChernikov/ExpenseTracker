using ExpensesTracker.Models.Enums;
using ExpensesTracker.Models.RequestModels;
using ExpensesTracker.Models.ViewModels;
using ExpensesTracker.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using AccountOperation = ExpensesTracker.Models.AccountOperation;

namespace ExpensesTracker.Forms
{
    public partial class MainWindow : Form
    {
        private readonly PdfGenerator _pdfGenerator;
        private readonly StateManager _stateManager;
        private readonly OperationsTableManager _operationsTableManager;

        private int SelectedAccountId => ((AccountViewModel)accountBox.SelectedItem).Id;

        public MainWindow()
        {
            InitializeComponent();

            _pdfGenerator = new PdfGenerator();
            _stateManager = new StateManager();
            _operationsTableManager = new OperationsTableManager(operationsTable);
        }

        private async void MainWindow_Load(object sender, EventArgs e)
        {
            InitializeDateRange();
            InitializeCategoryFilterBox();

            await _stateManager.InitializeAsync();
            await _stateManager.EnsureAccountExistsAsync();

            RefreshListOfAccountsInAccountsBox();
            RefreshTableAndBalance();
            SetupSearchInput();
        }

        private void RefreshTable()
        {
            _operationsTableManager.RefreshTable(GetFilteredOperations());
        }

        private void CategoryFilter_SelectedIndexChanged(object sender, EventArgs e) => RefreshTable();

        private void SearchInput_TextChanged(object sender, EventArgs e) => RefreshTable();

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e) => RefreshTable();

        private void DateTimePicker2_ValueChanged(object sender, EventArgs e) => RefreshTable();

        private void SelectedAccountBox_SelectedIndexChanged(object sender, EventArgs e) => RefreshTableAndBalance();

        private List<AccountOperation> GetFilteredOperations()
        {
            return _stateManager.GetFilteredOperations(new OperationsQueryFilter
            {
                Category = Convert.ToString(categoryFilterBox.SelectedItem),
                EndDate = endDateDisplay.Value,
                StartDate = startDateDisplay.Value,
                Id = SelectedAccountId,
                SearchText = !searchInput.IsPlaceHolderActive ? searchInput.Text : null
            });
        }

        private void RefreshTableAndBalance()
        {
            RefreshTable();
            RefreshBalance();
        }

        private void SavePdfButton_Click(object sender, EventArgs e)
        {
            _pdfGenerator.GeneratePdf(GetFilteredOperations());
        }

        private void RefreshListOfAccountsInAccountsBox(int? selectedAccountId = null)
        {
            var accountViewModels = _stateManager.GetAccountViewModels();
            var accountVm = selectedAccountId.HasValue
                ? accountViewModels.Single(x => x.Id == selectedAccountId.Value)
                : accountViewModels.First();

            accountBox.SelectedIndexChanged -= SelectedAccountBox_SelectedIndexChanged;

            accountBox.DataSource = null;
            accountBox.DataSource = accountViewModels;

            accountBox.DisplayMember = "Name";

            accountBox.SelectedItem = accountVm;
            accountBox.SelectedIndexChanged += SelectedAccountBox_SelectedIndexChanged;
        }

        private void RefreshBalance()
        {
            var balance = _stateManager.GetAccountBalance(SelectedAccountId);
            accountBalanceLable.Text = "On your balance  " + Convert.ToString(balance, CultureInfo.InvariantCulture);
        }

        private void CreateAccountForm_Click(object sender, EventArgs e)
        {
            var createAccountForm = new CreateAccountForm
            {
                OnAccountAdded = async (account) =>
                {
                    var operationResult = await _stateManager.CreateAccountAsync(account);
                    if (!operationResult.Success)
                    {
                        MessageBox.Show(operationResult.ErrorMassage);
                        return;
                    }

                    RefreshListOfAccountsInAccountsBox(account.Id);
                    RefreshTableAndBalance();
                }
            };
            createAccountForm.Show();
        }

        private void EditAccountButton_Click(object sender, EventArgs e)
        {
            var editAccountForm = new EditAccountForm
            {
                TargetAccountForEdit = _stateManager.Accounts.Single(x => x.Id == SelectedAccountId),
                OnAccountEdit = async (editedAccountModel) =>
                {
                    var operationResult = await _stateManager.EditAccountAsync(editedAccountModel);
                    if (!operationResult.Success)
                    {
                        MessageBox.Show(operationResult.ErrorMassage);
                        return;
                    }

                    RefreshListOfAccountsInAccountsBox(editedAccountModel.Id);
                    RefreshBalance();
                },

                OnAccountDeleted = async () =>
                 {
                     await _stateManager.DeleteAccountAsync(SelectedAccountId);

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
                OnIncomeAdded = async (income) =>
                 {
                     await _stateManager.CreateOperationAsync(income, SelectedAccountId);
                     RefreshTableAndBalance();
                 }
            };
            createIncomeForm.Show();
        }

        private void CreateExpenseForm_Click(object sender, EventArgs e)
        {
            var createExpenseForm = new CreateExpenseForm
            {
                OnExpenseAdded = async (expense) =>
                 {
                     await _stateManager.CreateOperationAsync(expense, SelectedAccountId);
                     RefreshTableAndBalance();
                 }
            };
            createExpenseForm.Show();
        }

        private void OperationsTable_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            var selectedOperation = _operationsTableManager.GetSelectedAccountOperation();
            if (selectedOperation == null)
                return;

            EditOperation(selectedOperation);
        }

        private void EditOperationButton_Click(object sender, EventArgs e)
        {
            var selectedOperation = _operationsTableManager.GetSelectedAccountOperation();
            if (selectedOperation == null)
            {
                MessageBox.Show(@"You have not selected any operations");
                return;
            }

            EditOperation(selectedOperation);
        }

        private void EditOperation(AccountOperation operation)
        {
            if (operation.Type == OperationType.Expense)
            {
                var editExpenseForm = new EditExpenseForm
                {
                    TargetExpense = operation,
                    OnExpenseEdit = async editOperation =>
                    {
                        await _stateManager.EditOperationAsync(editOperation);
                        RefreshTableAndBalance();
                    },

                    OnExpenseDeleted = async () =>
                    {
                        await _stateManager.DeleteOperationAsync(operation.Id);
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
                    OnIncomeEdit = async (editOperation) =>
                    {
                        await _stateManager.EditOperationAsync(editOperation);
                        RefreshTableAndBalance();
                    },
                    OnIncomeDeleted = async () =>
                     {
                         await _stateManager.DeleteOperationAsync(operation.Id);
                         RefreshTableAndBalance();
                     }
                };
                editIncomeForm.Show();
            }
        }

        private void OperationsTable_SelectionChanged(object sender, EventArgs e)
        {
            _operationsTableManager.ColorSelectedRow();
        }

        private void SetupSearchInput()
        {
            searchInput.SetupPlaceHolder("Search", Color.DarkGray);
            searchInput.TextChanged += SearchInput_TextChanged;
        }

        private void InitializeDateRange()
        {
            startDateDisplay.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            endDateDisplay.Value = DateTime.Today;
            startDateDisplay.ValueChanged += DateTimePicker1_ValueChanged;
            endDateDisplay.ValueChanged += DateTimePicker2_ValueChanged;
        }

        private void InitializeCategoryFilterBox()
        {
            categoryFilterBox.SelectedItem = "All categories";
            categoryFilterBox.SelectedIndexChanged += CategoryFilter_SelectedIndexChanged;
        }
    }
}
