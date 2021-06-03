﻿using System;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class AddNewIncomeForm : Form
    {
        public Action<AccountOperation> OnIncomeAdded;

        public AddNewIncomeForm()
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
            income.Type = OperationType.Income;
            OnIncomeAdded(income);
            this.Close();
        }
    }
}