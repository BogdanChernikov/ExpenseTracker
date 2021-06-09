
namespace ExpensesTracker.Forms
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
            this.openAddFormButton = new System.Windows.Forms.Button();
            this.categoryFilterBox = new System.Windows.Forms.ComboBox();
            this.searchNameInput = new System.Windows.Forms.TextBox();
            this.expensesTable = new System.Windows.Forms.DataGridView();
            this.dateBox = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoryBox = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountBox = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commentBox = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startDateDisplay = new System.Windows.Forms.DateTimePicker();
            this.endDateDisplay = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.savePdfButton = new System.Windows.Forms.Button();
            this.editExpenseButton = new System.Windows.Forms.Button();
            this.accountBox = new System.Windows.Forms.ComboBox();
            this.accountBalanceLable = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openAddAccountFormButton = new System.Windows.Forms.Button();
            this.editAccountButton = new System.Windows.Forms.Button();
            this.openAddIncomeFormButton = new System.Windows.Forms.Button();
            this.accountBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.expensesTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // openAddFormButton
            // 
            this.openAddFormButton.Location = new System.Drawing.Point(502, 199);
            this.openAddFormButton.Name = "openAddFormButton";
            this.openAddFormButton.Size = new System.Drawing.Size(75, 22);
            this.openAddFormButton.TabIndex = 0;
            this.openAddFormButton.Text = "Add expenes";
            this.openAddFormButton.UseVisualStyleBackColor = true;
            this.openAddFormButton.Click += new System.EventHandler(this.CreateExpenseForm_Click);
            // 
            // categoryFilterBox
            // 
            this.categoryFilterBox.FormattingEnabled = true;
            this.categoryFilterBox.Items.AddRange(new object[] {
            "All amount",
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
            this.dateBox,
            this.categoryBox,
            this.amountBox,
            this.commentBox});
            this.expensesTable.Location = new System.Drawing.Point(24, 142);
            this.expensesTable.MultiSelect = false;
            this.expensesTable.Name = "expensesTable";
            this.expensesTable.RowHeadersVisible = false;
            this.expensesTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.expensesTable.Size = new System.Drawing.Size(434, 217);
            this.expensesTable.TabIndex = 4;
            this.expensesTable.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ExpensesTable_CellContentDoubleClick);
            // 
            // dateBox
            // 
            this.dateBox.DataPropertyName = "Date";
            this.dateBox.HeaderText = "Date";
            this.dateBox.Name = "dateBox";
            this.dateBox.ReadOnly = true;
            this.dateBox.Width = 90;
            // 
            // categoryBox
            // 
            this.categoryBox.DataPropertyName = "Category";
            this.categoryBox.HeaderText = "Category";
            this.categoryBox.Name = "categoryBox";
            this.categoryBox.ReadOnly = true;
            this.categoryBox.Width = 120;
            // 
            // amountBox
            // 
            this.amountBox.DataPropertyName = "Amount";
            this.amountBox.HeaderText = "Amount";
            this.amountBox.Name = "amountBox";
            this.amountBox.ReadOnly = true;
            this.amountBox.Width = 110;
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
            this.startDateDisplay.Value = new System.DateTime(2021, 6, 1, 0, 0, 0, 0);
            this.startDateDisplay.ValueChanged += new System.EventHandler(this.DateTimePicker1_ValueChanged);
            // 
            // endDateDisplay
            // 
            this.endDateDisplay.CustomFormat = "dd:MM:yyyy HH:mm:ss";
            this.endDateDisplay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.endDateDisplay.Location = new System.Drawing.Point(289, 88);
            this.endDateDisplay.Name = "endDateDisplay";
            this.endDateDisplay.Size = new System.Drawing.Size(95, 20);
            this.endDateDisplay.TabIndex = 6;
            this.endDateDisplay.Value = new System.DateTime(2021, 6, 9, 23, 59, 0, 0);
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
            // editExpenseButton
            // 
            this.editExpenseButton.Location = new System.Drawing.Point(502, 248);
            this.editExpenseButton.Name = "editExpenseButton";
            this.editExpenseButton.Size = new System.Drawing.Size(75, 23);
            this.editExpenseButton.TabIndex = 9;
            this.editExpenseButton.Text = "Edit";
            this.editExpenseButton.UseVisualStyleBackColor = true;
            this.editExpenseButton.Click += new System.EventHandler(this.EditExpenseButton_Click);
            // 
            // accountBox
            // 
            this.accountBox.FormattingEnabled = true;
            this.accountBox.Location = new System.Drawing.Point(24, 12);
            this.accountBox.Name = "accountBox";
            this.accountBox.Size = new System.Drawing.Size(157, 21);
            this.accountBox.TabIndex = 10;
            this.accountBox.SelectedIndexChanged += new System.EventHandler(this.SelectedAccountBox_SelectedIndexChanged);
            // 
            // accountBalanceLable
            // 
            this.accountBalanceLable.AutoSize = true;
            this.accountBalanceLable.Location = new System.Drawing.Point(21, 54);
            this.accountBalanceLable.Name = "accountBalanceLable";
            this.accountBalanceLable.Size = new System.Drawing.Size(35, 13);
            this.accountBalanceLable.TabIndex = 11;
            this.accountBalanceLable.Text = "label2";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // openAddAccountFormButton
            // 
            this.openAddAccountFormButton.Location = new System.Drawing.Point(215, 9);
            this.openAddAccountFormButton.Name = "openAddAccountFormButton";
            this.openAddAccountFormButton.Size = new System.Drawing.Size(75, 23);
            this.openAddAccountFormButton.TabIndex = 15;
            this.openAddAccountFormButton.Text = "Add account";
            this.openAddAccountFormButton.UseVisualStyleBackColor = true;
            this.openAddAccountFormButton.Click += new System.EventHandler(this.CreateAccountForm_Click);
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
            // openAddIncomeFormButton
            // 
            this.openAddIncomeFormButton.Location = new System.Drawing.Point(502, 151);
            this.openAddIncomeFormButton.Name = "openAddIncomeFormButton";
            this.openAddIncomeFormButton.Size = new System.Drawing.Size(75, 23);
            this.openAddIncomeFormButton.TabIndex = 17;
            this.openAddIncomeFormButton.Text = "Add Income";
            this.openAddIncomeFormButton.UseVisualStyleBackColor = true;
            this.openAddIncomeFormButton.Click += new System.EventHandler(this.CreateIncomeForm_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 450);
            this.Controls.Add(this.openAddIncomeFormButton);
            this.Controls.Add(this.editAccountButton);
            this.Controls.Add(this.openAddAccountFormButton);
            this.Controls.Add(this.accountBalanceLable);
            this.Controls.Add(this.accountBox);
            this.Controls.Add(this.editExpenseButton);
            this.Controls.Add(this.savePdfButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.endDateDisplay);
            this.Controls.Add(this.startDateDisplay);
            this.Controls.Add(this.expensesTable);
            this.Controls.Add(this.searchNameInput);
            this.Controls.Add(this.categoryFilterBox);
            this.Controls.Add(this.openAddFormButton);
            this.Name = "MainWindow";
            this.Text = "Expense Tracker";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.expensesTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button openAddFormButton;
        public System.Windows.Forms.ComboBox categoryFilterBox;
        public System.Windows.Forms.TextBox searchNameInput;
        public System.Windows.Forms.DataGridView expensesTable;
        private System.Windows.Forms.DateTimePicker startDateDisplay;
        private System.Windows.Forms.DateTimePicker endDateDisplay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button savePdfButton;
        private System.Windows.Forms.Button editExpenseButton;
        private System.Windows.Forms.ComboBox accountBox;
        private System.Windows.Forms.Label accountBalanceLable;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button openAddAccountFormButton;
        private System.Windows.Forms.Button editAccountButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn commentBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoryBox;
        private System.Windows.Forms.BindingSource accountBindingSource;
        private System.Windows.Forms.Button openAddIncomeFormButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountBox;
    }
}

