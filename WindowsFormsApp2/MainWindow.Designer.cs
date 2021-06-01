
namespace WindowsFormsApp2
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        public void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.OpenAddForm = new System.Windows.Forms.Button();
            this.categoryFilterBox = new System.Windows.Forms.ComboBox();
            this.searchNameInput = new System.Windows.Forms.TextBox();
            this.expensesTable = new System.Windows.Forms.DataGridView();
            this.DateBox = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoryBox = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costBox = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commentBox = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startDateDisplay = new System.Windows.Forms.DateTimePicker();
            this.endDateDisplay = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.savePdfButton = new System.Windows.Forms.Button();
            this.editExpensButton = new System.Windows.Forms.Button();
            this.selectedAccountBox = new System.Windows.Forms.ComboBox();
            this.accountBalance = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addAccountForm = new System.Windows.Forms.Button();
            this.editAccountButton = new System.Windows.Forms.Button();
            this.addIncomeForm = new System.Windows.Forms.Button();
            this.accountBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.expensesTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // OpenAddForm
            // 
            this.OpenAddForm.Location = new System.Drawing.Point(502, 199);
            this.OpenAddForm.Name = "OpenAddForm";
            this.OpenAddForm.Size = new System.Drawing.Size(75, 22);
            this.OpenAddForm.TabIndex = 0;
            this.OpenAddForm.Text = "Add expenes";
            this.OpenAddForm.UseVisualStyleBackColor = true;
            this.OpenAddForm.Click += new System.EventHandler(this.AddExpenseForm_Click);
            // 
            // categoryFilterBox
            // 
            this.categoryFilterBox.FormattingEnabled = true;
            this.categoryFilterBox.Items.AddRange(new object[] {
            "All costs",
            "Traffic",
            "Utilities",
            "ServicesCommunication",
            "MedicinesAndHygieneProducts",
            "Food"});
            this.categoryFilterBox.Location = new System.Drawing.Point(24, 87);
            this.categoryFilterBox.Name = "categoryFilterBox";
            this.categoryFilterBox.Size = new System.Drawing.Size(122, 21);
            this.categoryFilterBox.TabIndex = 2;
            this.categoryFilterBox.SelectedIndexChanged += new System.EventHandler(this.CategoryFilter_SelectedIndexChanged);
            // 
            // searchNameInput
            // 
            this.searchNameInput.Location = new System.Drawing.Point(410, 88);
            this.searchNameInput.Name = "searchNameInput";
            this.searchNameInput.Size = new System.Drawing.Size(105, 20);
            this.searchNameInput.TabIndex = 3;
            this.searchNameInput.TextChanged += new System.EventHandler(this.CommentSearch_TextChanged);
            // 
            // expensesTable
            // 
            this.expensesTable.AllowUserToAddRows = false;
            this.expensesTable.BackgroundColor = System.Drawing.SystemColors.Control;
            this.expensesTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.expensesTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DateBox,
            this.CategoryBox,
            this.costBox,
            this.commentBox});
            this.expensesTable.Location = new System.Drawing.Point(24, 142);
            this.expensesTable.Name = "expensesTable";
            this.expensesTable.RowHeadersVisible = false;
            this.expensesTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.expensesTable.Size = new System.Drawing.Size(434, 217);
            this.expensesTable.TabIndex = 4;
            this.expensesTable.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ExpensesTable_CellContentDoubleClick);
            // 
            // DateBox
            // 
            this.DateBox.DataPropertyName = "Date";
            this.DateBox.HeaderText = "Date";
            this.DateBox.Name = "DateBox";
            this.DateBox.ReadOnly = true;
            this.DateBox.Width = 90;
            // 
            // CategoryBox
            // 
            this.CategoryBox.DataPropertyName = "Category";
            this.CategoryBox.HeaderText = "Category";
            this.CategoryBox.Name = "CategoryBox";
            this.CategoryBox.ReadOnly = true;
            this.CategoryBox.Width = 120;
            // 
            // costBox
            // 
            this.costBox.DataPropertyName = "Cost";
            this.costBox.HeaderText = "Cost";
            this.costBox.Name = "costBox";
            this.costBox.ReadOnly = true;
            this.costBox.Width = 110;
            // 
            // commentBox
            // 
            this.commentBox.DataPropertyName = "Comment";
            this.commentBox.HeaderText = "Comment";
            this.commentBox.Name = "commentBox";
            this.commentBox.ReadOnly = true;
            this.commentBox.Width = 110;
            // 
            // startDateDisplay
            // 
            this.startDateDisplay.CustomFormat = "dd:MM:yyyy";
            this.startDateDisplay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.startDateDisplay.Location = new System.Drawing.Point(170, 88);
            this.startDateDisplay.Name = "startDateDisplay";
            this.startDateDisplay.Size = new System.Drawing.Size(91, 20);
            this.startDateDisplay.TabIndex = 5;
            this.startDateDisplay.ValueChanged += new System.EventHandler(this.DateTimePicker1_ValueChanged);
            // 
            // endDateDisplay
            // 
            this.endDateDisplay.CustomFormat = "dd:MM:yyyy";
            this.endDateDisplay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.endDateDisplay.Location = new System.Drawing.Point(289, 88);
            this.endDateDisplay.Name = "endDateDisplay";
            this.endDateDisplay.Size = new System.Drawing.Size(95, 20);
            this.endDateDisplay.TabIndex = 6;
            this.endDateDisplay.ValueChanged += new System.EventHandler(this.DateTimePicker2_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(267, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 24);
            this.label1.TabIndex = 7;
            this.label1.Text = "-";
            // 
            // savePdfButton
            // 
            this.savePdfButton.Location = new System.Drawing.Point(502, 298);
            this.savePdfButton.Name = "savePdfButton";
            this.savePdfButton.Size = new System.Drawing.Size(75, 23);
            this.savePdfButton.TabIndex = 8;
            this.savePdfButton.Text = "Save PDF";
            this.savePdfButton.UseVisualStyleBackColor = true;
            this.savePdfButton.Click += new System.EventHandler(this.SavePdfButton_Click);
            // 
            // editExpensButton
            // 
            this.editExpensButton.Location = new System.Drawing.Point(502, 248);
            this.editExpensButton.Name = "editExpensButton";
            this.editExpensButton.Size = new System.Drawing.Size(75, 23);
            this.editExpensButton.TabIndex = 9;
            this.editExpensButton.Text = "Edit";
            this.editExpensButton.UseVisualStyleBackColor = true;
            this.editExpensButton.Click += new System.EventHandler(this.EditExpensButton_Click);
            // 
            // selectedAccountBox
            // 
            this.selectedAccountBox.FormattingEnabled = true;
            this.selectedAccountBox.Location = new System.Drawing.Point(24, 12);
            this.selectedAccountBox.Name = "selectedAccountBox";
            this.selectedAccountBox.Size = new System.Drawing.Size(157, 21);
            this.selectedAccountBox.TabIndex = 10;
            this.selectedAccountBox.SelectedIndexChanged += new System.EventHandler(this.SelectedAccountBox_SelectedIndexChanged);
            // 
            // accountBalance
            // 
            this.accountBalance.AutoSize = true;
            this.accountBalance.Location = new System.Drawing.Point(21, 54);
            this.accountBalance.Name = "accountBalance";
            this.accountBalance.Size = new System.Drawing.Size(35, 13);
            this.accountBalance.TabIndex = 11;
            this.accountBalance.Text = "label2";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // addAccountForm
            // 
            this.addAccountForm.Location = new System.Drawing.Point(215, 9);
            this.addAccountForm.Name = "addAccountForm";
            this.addAccountForm.Size = new System.Drawing.Size(75, 23);
            this.addAccountForm.TabIndex = 15;
            this.addAccountForm.Text = "Add account";
            this.addAccountForm.UseVisualStyleBackColor = true;
            this.addAccountForm.Click += new System.EventHandler(this.AddAccountForm_Click);
            // 
            // editAccountButton
            // 
            this.editAccountButton.Location = new System.Drawing.Point(309, 9);
            this.editAccountButton.Name = "editAccountButton";
            this.editAccountButton.Size = new System.Drawing.Size(75, 23);
            this.editAccountButton.TabIndex = 16;
            this.editAccountButton.Text = "Edit";
            this.editAccountButton.UseVisualStyleBackColor = true;
            this.editAccountButton.Click += new System.EventHandler(this.EditAccountButton_Click);
            // 
            // addIncomeForm
            // 
            this.addIncomeForm.Location = new System.Drawing.Point(502, 151);
            this.addIncomeForm.Name = "addIncomeForm";
            this.addIncomeForm.Size = new System.Drawing.Size(75, 23);
            this.addIncomeForm.TabIndex = 17;
            this.addIncomeForm.Text = "Add Income";
            this.addIncomeForm.UseVisualStyleBackColor = true;
            this.addIncomeForm.Click += new System.EventHandler(this.AddIncomeForm_Click);
            // 
            // accountBindingSource
            // 
            this.accountBindingSource.DataSource = typeof(WindowsFormsApp2.Account);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 450);
            this.Controls.Add(this.addIncomeForm);
            this.Controls.Add(this.editAccountButton);
            this.Controls.Add(this.addAccountForm);
            this.Controls.Add(this.accountBalance);
            this.Controls.Add(this.selectedAccountBox);
            this.Controls.Add(this.editExpensButton);
            this.Controls.Add(this.savePdfButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.endDateDisplay);
            this.Controls.Add(this.startDateDisplay);
            this.Controls.Add(this.expensesTable);
            this.Controls.Add(this.searchNameInput);
            this.Controls.Add(this.categoryFilterBox);
            this.Controls.Add(this.OpenAddForm);
            this.Name = "MainWindow";
            this.Text = "Costs";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.expensesTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button OpenAddForm;
        public System.Windows.Forms.ComboBox categoryFilterBox;
        public System.Windows.Forms.TextBox searchNameInput;
        public System.Windows.Forms.DataGridView expensesTable;
        private System.Windows.Forms.DateTimePicker startDateDisplay;
        private System.Windows.Forms.DateTimePicker endDateDisplay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button savePdfButton;
        private System.Windows.Forms.Button editExpensButton;
        private System.Windows.Forms.ComboBox selectedAccountBox;
        private System.Windows.Forms.Label accountBalance;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button addAccountForm;
        private System.Windows.Forms.Button editAccountButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn CostBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn commentBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryBox;
        private System.Windows.Forms.BindingSource accountBindingSource;
        private System.Windows.Forms.Button addIncomeForm;
        private System.Windows.Forms.DataGridViewTextBoxColumn costBox;
    }
}

