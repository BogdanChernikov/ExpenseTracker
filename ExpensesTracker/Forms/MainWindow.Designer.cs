using System;

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
            this.operationsTable = new System.Windows.Forms.DataGridView();
            this.dateBox = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoryBox = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountBox = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commentBox = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startDateDisplay = new System.Windows.Forms.DateTimePicker();
            this.endDateDisplay = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.savePdfButton = new System.Windows.Forms.Button();
            this.editOperationButton = new System.Windows.Forms.Button();
            this.accountBox = new System.Windows.Forms.ComboBox();
            this.accountBalanceLable = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openAddAccountFormButton = new System.Windows.Forms.Button();
            this.editAccountButton = new System.Windows.Forms.Button();
            this.openAddIncomeFormButton = new System.Windows.Forms.Button();
            this.accountBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.accountLabel = new System.Windows.Forms.Label();
            this.searchInput = new ExpensesTracker.PlaceHolderTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.operationsTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // openAddFormButton
            // 
            this.openAddFormButton.Location = new System.Drawing.Point(753, 306);
            this.openAddFormButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.openAddFormButton.Name = "openAddFormButton";
            this.openAddFormButton.Size = new System.Drawing.Size(129, 34);
            this.openAddFormButton.TabIndex = 0;
            this.openAddFormButton.Text = "Add expenes";
            this.openAddFormButton.UseVisualStyleBackColor = true;
            this.openAddFormButton.Click += new System.EventHandler(this.CreateExpenseForm_Click);
            // 
            // categoryFilterBox
            // 
            this.categoryFilterBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.categoryFilterBox.FormattingEnabled = true;
            this.categoryFilterBox.Items.AddRange(new object[] {
            "All categories",
            "Traffic",
            "Utilities",
            "ServicesCommunication",
            "MedicinesAndHygieneProducts",
            "Food",
            "Incomes"});
            this.categoryFilterBox.Location = new System.Drawing.Point(36, 134);
            this.categoryFilterBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.categoryFilterBox.Name = "categoryFilterBox";
            this.categoryFilterBox.Size = new System.Drawing.Size(181, 28);
            this.categoryFilterBox.TabIndex = 2;
            // 
            // operationsTable
            // 
            this.operationsTable.AllowUserToAddRows = false;
            this.operationsTable.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.operationsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.operationsTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dateBox,
            this.categoryBox,
            this.amountBox,
            this.commentBox});
            this.operationsTable.Location = new System.Drawing.Point(36, 218);
            this.operationsTable.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.operationsTable.MultiSelect = false;
            this.operationsTable.Name = "operationsTable";
            this.operationsTable.RowHeadersVisible = false;
            this.operationsTable.RowHeadersWidth = 62;
            this.operationsTable.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.operationsTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.operationsTable.Size = new System.Drawing.Size(651, 334);
            this.operationsTable.TabIndex = 4;
            this.operationsTable.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OperationsTable_CellDoubleClick);
            this.operationsTable.SelectionChanged += new System.EventHandler(this.OperationsTable_SelectionChanged);
            // 
            // dateBox
            // 
            this.dateBox.DataPropertyName = "Date";
            this.dateBox.HeaderText = "Date";
            this.dateBox.MinimumWidth = 8;
            this.dateBox.Name = "dateBox";
            this.dateBox.ReadOnly = true;
            this.dateBox.Width = 90;
            // 
            // categoryBox
            // 
            this.categoryBox.DataPropertyName = "Category";
            this.categoryBox.HeaderText = "Category";
            this.categoryBox.MinimumWidth = 8;
            this.categoryBox.Name = "categoryBox";
            this.categoryBox.ReadOnly = true;
            this.categoryBox.Width = 120;
            // 
            // amountBox
            // 
            this.amountBox.DataPropertyName = "Amount";
            this.amountBox.HeaderText = "Amount";
            this.amountBox.MinimumWidth = 8;
            this.amountBox.Name = "amountBox";
            this.amountBox.ReadOnly = true;
            this.amountBox.Width = 110;
            // 
            // commentBox
            // 
            this.commentBox.DataPropertyName = "Comment";
            this.commentBox.HeaderText = "Comment";
            this.commentBox.MinimumWidth = 8;
            this.commentBox.Name = "commentBox";
            this.commentBox.ReadOnly = true;
            this.commentBox.Width = 110;
            // 
            // startDateDisplay
            // 
            this.startDateDisplay.CustomFormat = "dd:MM:yyyy";
            this.startDateDisplay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.startDateDisplay.Location = new System.Drawing.Point(255, 135);
            this.startDateDisplay.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.startDateDisplay.Name = "startDateDisplay";
            this.startDateDisplay.Size = new System.Drawing.Size(134, 26);
            this.startDateDisplay.TabIndex = 5;
            this.startDateDisplay.Value = new System.DateTime(2021, 6, 22, 0, 0, 0, 0);
            // 
            // endDateDisplay
            // 
            this.endDateDisplay.CustomFormat = "dd:MM:yyyy";
            this.endDateDisplay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.endDateDisplay.Location = new System.Drawing.Point(434, 135);
            this.endDateDisplay.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.endDateDisplay.Name = "endDateDisplay";
            this.endDateDisplay.Size = new System.Drawing.Size(140, 26);
            this.endDateDisplay.TabIndex = 6;
            this.endDateDisplay.Value = new System.DateTime(2021, 6, 22, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(400, 132);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 33);
            this.label1.TabIndex = 7;
            this.label1.Text = "-";
            // 
            // savePdfButton
            // 
            this.savePdfButton.Location = new System.Drawing.Point(753, 458);
            this.savePdfButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.savePdfButton.Name = "savePdfButton";
            this.savePdfButton.Size = new System.Drawing.Size(129, 35);
            this.savePdfButton.TabIndex = 8;
            this.savePdfButton.Text = "Save PDF";
            this.savePdfButton.UseVisualStyleBackColor = true;
            this.savePdfButton.Click += new System.EventHandler(this.SavePdfButton_Click);
            // 
            // editOperationButton
            // 
            this.editOperationButton.Location = new System.Drawing.Point(753, 382);
            this.editOperationButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.editOperationButton.Name = "editOperationButton";
            this.editOperationButton.Size = new System.Drawing.Size(129, 35);
            this.editOperationButton.TabIndex = 9;
            this.editOperationButton.Text = "Edit";
            this.editOperationButton.UseVisualStyleBackColor = true;
            this.editOperationButton.Click += new System.EventHandler(this.EditOperationButton_Click);
            // 
            // accountBox
            // 
            this.accountBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.accountBox.FormattingEnabled = true;
            this.accountBox.Location = new System.Drawing.Point(189, 15);
            this.accountBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.accountBox.Name = "accountBox";
            this.accountBox.Size = new System.Drawing.Size(234, 28);
            this.accountBox.TabIndex = 10;
            // 
            // accountBalanceLable
            // 
            this.accountBalanceLable.AutoSize = true;
            this.accountBalanceLable.Location = new System.Drawing.Point(32, 83);
            this.accountBalanceLable.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.accountBalanceLable.Name = "accountBalanceLable";
            this.accountBalanceLable.Size = new System.Drawing.Size(105, 20);
            this.accountBalanceLable.TabIndex = 11;
            this.accountBalanceLable.Text = "accountLabel";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // openAddAccountFormButton
            // 
            this.openAddAccountFormButton.Location = new System.Drawing.Point(477, 12);
            this.openAddAccountFormButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.openAddAccountFormButton.Name = "openAddAccountFormButton";
            this.openAddAccountFormButton.Size = new System.Drawing.Size(112, 35);
            this.openAddAccountFormButton.TabIndex = 15;
            this.openAddAccountFormButton.Text = "Add account";
            this.openAddAccountFormButton.UseVisualStyleBackColor = true;
            this.openAddAccountFormButton.Click += new System.EventHandler(this.CreateAccountForm_Click);
            // 
            // editAccountButton
            // 
            this.editAccountButton.Location = new System.Drawing.Point(615, 12);
            this.editAccountButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.editAccountButton.Name = "editAccountButton";
            this.editAccountButton.Size = new System.Drawing.Size(112, 35);
            this.editAccountButton.TabIndex = 16;
            this.editAccountButton.Text = "Edit";
            this.editAccountButton.UseVisualStyleBackColor = true;
            this.editAccountButton.Click += new System.EventHandler(this.EditAccountButton_Click);
            // 
            // openAddIncomeFormButton
            // 
            this.openAddIncomeFormButton.Location = new System.Drawing.Point(753, 232);
            this.openAddIncomeFormButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.openAddIncomeFormButton.Name = "openAddIncomeFormButton";
            this.openAddIncomeFormButton.Size = new System.Drawing.Size(129, 35);
            this.openAddIncomeFormButton.TabIndex = 17;
            this.openAddIncomeFormButton.Text = "Add Income";
            this.openAddIncomeFormButton.UseVisualStyleBackColor = true;
            this.openAddIncomeFormButton.Click += new System.EventHandler(this.CreateIncomeForm_Click);
            // 
            // accountLabel
            // 
            this.accountLabel.AutoSize = true;
            this.accountLabel.Location = new System.Drawing.Point(32, 25);
            this.accountLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.accountLabel.Name = "accountLabel";
            this.accountLabel.Size = new System.Drawing.Size(133, 20);
            this.accountLabel.TabIndex = 18;
            this.accountLabel.Text = "Selected account";
            // 
            // searchInput
            // 
            this.searchInput.ForeColor = System.Drawing.Color.Black;
            this.searchInput.Location = new System.Drawing.Point(615, 135);
            this.searchInput.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.searchInput.Name = "searchInput";
            this.searchInput.Size = new System.Drawing.Size(148, 26);
            this.searchInput.TabIndex = 19;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 692);
            this.Controls.Add(this.searchInput);
            this.Controls.Add(this.accountLabel);
            this.Controls.Add(this.openAddIncomeFormButton);
            this.Controls.Add(this.editAccountButton);
            this.Controls.Add(this.openAddAccountFormButton);
            this.Controls.Add(this.accountBalanceLable);
            this.Controls.Add(this.accountBox);
            this.Controls.Add(this.editOperationButton);
            this.Controls.Add(this.savePdfButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.endDateDisplay);
            this.Controls.Add(this.startDateDisplay);
            this.Controls.Add(this.operationsTable);
            this.Controls.Add(this.categoryFilterBox);
            this.Controls.Add(this.openAddFormButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Text = "Expense Tracker";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.operationsTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button openAddFormButton;
        public System.Windows.Forms.ComboBox categoryFilterBox;
        public System.Windows.Forms.DataGridView operationsTable;
        private System.Windows.Forms.DateTimePicker startDateDisplay;
        private System.Windows.Forms.DateTimePicker endDateDisplay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button savePdfButton;
        private System.Windows.Forms.Button editOperationButton;
        private System.Windows.Forms.ComboBox accountBox;
        private System.Windows.Forms.Label accountBalanceLable;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button openAddAccountFormButton;
        private System.Windows.Forms.Button editAccountButton;
        private System.Windows.Forms.BindingSource accountBindingSource;
        private System.Windows.Forms.Button openAddIncomeFormButton;
        private System.Windows.Forms.Label accountLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoryBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn commentBox;
        private PlaceHolderTextBox searchInput;
    }
}

