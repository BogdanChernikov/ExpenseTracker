﻿using ExpensesTracker.Services;
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
            _accounts = _storage.GetAccounts();

            if (!_accounts.Any())
                CreateDefaultAccount();

            accountBox.DataSource = null;
            accountBox.DataSource = _accounts;
            accountBox.DisplayMember = "Name";

            operationsTable.AutoGenerateColumns = false;

            accountBox.SelectedIndex = 0;
            accountBox.SelectedIndexChanged += SelectedAccountBox_SelectedIndexChanged;

            categoryFilterBox.SelectedItem = "All amount";
            categoryFilterBox.SelectedIndexChanged += CategoryFilter_SelectedIndexChanged;

            ShowBalance();

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

            //ShowTable();
            ShowBalance();
        }

        private void ActualizeTableRecords()
        {
            operationsTable.DataSource = null;
            operationsTable.DataSource = _filteredOperations;
        }

        private void ColorTable()
        {
            for (var i = 0; i < _filteredOperations.Count; i++)
            {
                if (operationsTable.Rows.Count == 0)
                    break;
                if (_filteredOperations[i].Type == OperationType.Expense)
                {
                    operationsTable.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                }

                if (_filteredOperations[i].Type == OperationType.Income)
                {
                    operationsTable.Rows[i].DefaultCellStyle.BackColor = Color.Green;
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

            accountBalanceLable.Text = Convert.ToString
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

        private void OperationsTable_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
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
            if (!(operationsTable.SelectedRows[0].DataBoundItem is AccountOperation operation))
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

        private void button1_Click(object sender, EventArgs e)
        {
            Controls.Add(allCategorysFilterButton);
            Controls.Add(trafficFilterButton);
            Controls.Add(utilitiesFilterButton);
            Controls.Add(medicinesAndHygieneProductsFilterButton);
            Controls.Add(servicesCommunicationFilterButton);
            Controls.Add(foodFilterButton);
        }

        private void trafficFilterButton_Click(object sender, EventArgs e)
        {
            Controls.Add(operationsTable);
            Controls.Add(button1);
            categoryFilterBox.SelectedItem = "Traffic";
            ShowTable();
            Controls.Remove(allCategorysFilterButton);
            Controls.Remove(trafficFilterButton);
            Controls.Remove(utilitiesFilterButton);
            Controls.Remove(medicinesAndHygieneProductsFilterButton);
            Controls.Remove(servicesCommunicationFilterButton);
            Controls.Remove(foodFilterButton);
            Controls.Remove(accountBalanceLable);
            Controls.Remove(openCategorysButton);
            endDateDisplay.Visible = true;
            startDateDisplay.Visible = true;
            searchNameInput.Visible = true;
        }

        private void medicinesAndHygieneProductsFilterButton_Click(object sender, EventArgs e)
        {
            Controls.Add(operationsTable);
            Controls.Add(button1);
            categoryFilterBox.SelectedItem = "MedicinesAndHygieneProducts";
            ShowTable();
            Controls.Remove(allCategorysFilterButton);
            Controls.Remove(trafficFilterButton);
            Controls.Remove(utilitiesFilterButton);
            Controls.Remove(medicinesAndHygieneProductsFilterButton);
            Controls.Remove(servicesCommunicationFilterButton);
            Controls.Remove(foodFilterButton);
            Controls.Remove(accountBalanceLable);
            Controls.Remove(openCategorysButton);
            endDateDisplay.Visible = true;
            startDateDisplay.Visible = true;
            searchNameInput.Visible = true;
        }

        private void utilitiesFilterButton_Click(object sender, EventArgs e)
        {
            Controls.Add(operationsTable);
            Controls.Add(button1);
            categoryFilterBox.SelectedItem = "Utilities";
            ShowTable();
            Controls.Remove(allCategorysFilterButton);
            Controls.Remove(trafficFilterButton);
            Controls.Remove(utilitiesFilterButton);
            Controls.Remove(medicinesAndHygieneProductsFilterButton);
            Controls.Remove(servicesCommunicationFilterButton);
            Controls.Remove(foodFilterButton);
            Controls.Remove(accountBalanceLable);
            Controls.Remove(openCategorysButton);
            endDateDisplay.Visible = true;
            startDateDisplay.Visible = true;
            searchNameInput.Visible = true;
        }

        private void allCategorysFilterButton_Click(object sender, EventArgs e)
        {
            Controls.Add(operationsTable);
            Controls.Add(button1);
            categoryFilterBox.SelectedItem = "All amount";
            ShowTable();
            Controls.Remove(allCategorysFilterButton);
            Controls.Remove(trafficFilterButton);
            Controls.Remove(utilitiesFilterButton);
            Controls.Remove(medicinesAndHygieneProductsFilterButton);
            Controls.Remove(servicesCommunicationFilterButton);
            Controls.Remove(foodFilterButton);
            Controls.Remove(accountBalanceLable);
            Controls.Remove(openCategorysButton);
            endDateDisplay.Visible = true;
            startDateDisplay.Visible = true;
            searchNameInput.Visible = true;
        }

        private void servicesCommunicationFilterButton_Click(object sender, EventArgs e)
        {
            Controls.Add(operationsTable);
            Controls.Add(button1);
            categoryFilterBox.SelectedItem = "ServicesCommunication";
            ShowTable();
            Controls.Remove(allCategorysFilterButton);
            Controls.Remove(trafficFilterButton);
            Controls.Remove(utilitiesFilterButton);
            Controls.Remove(medicinesAndHygieneProductsFilterButton);
            Controls.Remove(servicesCommunicationFilterButton);
            Controls.Remove(foodFilterButton);
            Controls.Remove(accountBalanceLable);
            Controls.Remove(openCategorysButton);
            endDateDisplay.Visible = true;
            startDateDisplay.Visible = true;
            searchNameInput.Visible = true;
        }

        private void foodFilterButton_Click(object sender, EventArgs e)
        {
            Controls.Add(operationsTable);
            Controls.Add(button1);
            categoryFilterBox.SelectedItem = "Food";
            ShowTable();
            Controls.Remove(allCategorysFilterButton);
            Controls.Remove(trafficFilterButton);
            Controls.Remove(utilitiesFilterButton);
            Controls.Remove(medicinesAndHygieneProductsFilterButton);
            Controls.Remove(servicesCommunicationFilterButton);
            Controls.Remove(foodFilterButton);
            Controls.Remove(accountBalanceLable);
            Controls.Remove(openCategorysButton);
            endDateDisplay.Visible = true;
            startDateDisplay.Visible = true;
            searchNameInput.Visible = true;
        }

        private void ButtonFiltered()
        {
            Controls.Add(operationsTable);

            var chosenCategory = Convert.ToString(categoryFilterBox.SelectedItem);

            if (chosenCategory != "All amount")
            {
                _filteredOperations = _filteredOperations.Where(x => Convert.ToString(x.Category) == chosenCategory).ToList();
            }
            ShowTable();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Controls.Remove(operationsTable);
            Controls.Add(accountBalanceLable);
            Controls.Add(openCategorysButton);
            endDateDisplay.Visible = false;
            startDateDisplay.Visible = false;
            searchNameInput.Visible = false;
        }
    }
}
