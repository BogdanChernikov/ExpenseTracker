﻿using ExpensesTracker.Models;
using System;
using System.Windows.Forms;

namespace ExpensesTracker.Forms
{
    public partial class CreateIncomeForm : Form
    {
        public Action<AccountOperation> OnIncomeAdded;

        public CreateIncomeForm()
        {
            InitializeComponent();
        }

        private void CloseAddIncomeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void AddIncomeButton_Click(object sender, EventArgs e)
        {
            var income = new AccountOperation();
            income.Amount = incomeAmountInput.Value;
            income.Comment = incomeCommentTextBox.Text;
            income.Date = incomeDateInput.Value;
            OnIncomeAdded(income);
            this.Close();
        }
    }
}