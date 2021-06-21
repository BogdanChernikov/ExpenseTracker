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
            this.categoryFilterBox = new System.Windows.Forms.ComboBox();
            this.searchNameInput = new System.Windows.Forms.TextBox();
            this.operationsTable = new System.Windows.Forms.DataGridView();
            this.dateBox = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoryBox = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountBox = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commentBox = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startDateDisplay = new System.Windows.Forms.DateTimePicker();
            this.endDateDisplay = new System.Windows.Forms.DateTimePicker();
            this.accountBox = new System.Windows.Forms.ComboBox();
            this.accountBalanceLable = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.openAddIncomeFormButton = new System.Windows.Forms.Button();
            this.editAccountButton = new System.Windows.Forms.Button();
            this.openAddAccountFormButton = new System.Windows.Forms.Button();
            this.editOperationButton = new System.Windows.Forms.Button();
            this.savePdfButton = new System.Windows.Forms.Button();
            this.openAddFormButton = new System.Windows.Forms.Button();
            this.openCategorysButton = new System.Windows.Forms.Button();
            this.utilitiesFilterButton = new System.Windows.Forms.Button();
            this.medicinesAndHygieneProductsFilterButton = new System.Windows.Forms.Button();
            this.trafficFilterButton = new System.Windows.Forms.Button();
            this.allCategorysFilterButton = new System.Windows.Forms.Button();
            this.servicesCommunicationFilterButton = new System.Windows.Forms.Button();
            this.foodFilterButton = new System.Windows.Forms.Button();
            this.accountBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.operationsTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountBindingSource)).BeginInit();
            this.SuspendLayout();
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
            this.categoryFilterBox.Location = new System.Drawing.Point(12, 49);
            this.categoryFilterBox.Name = "categoryFilterBox";
            this.categoryFilterBox.Size = new System.Drawing.Size(70, 21);
            this.categoryFilterBox.TabIndex = 2;
            this.categoryFilterBox.Visible = false;
            // 
            // searchNameInput
            // 
            this.searchNameInput.Location = new System.Drawing.Point(242, 49);
            this.searchNameInput.Name = "searchNameInput";
            this.searchNameInput.Size = new System.Drawing.Size(105, 20);
            this.searchNameInput.TabIndex = 3;
            this.searchNameInput.Visible = false;
            this.searchNameInput.TextChanged += new System.EventHandler(this.CommentSearch_TextChanged);
            // 
            // operationsTable
            // 
            this.operationsTable.AllowUserToAddRows = false;
            this.operationsTable.BackgroundColor = System.Drawing.SystemColors.Control;
            this.operationsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.operationsTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dateBox,
            this.categoryBox,
            this.amountBox,
            this.commentBox});
            this.operationsTable.Location = new System.Drawing.Point(7, 113);
            this.operationsTable.MultiSelect = false;
            this.operationsTable.Name = "operationsTable";
            this.operationsTable.RowHeadersVisible = false;
            this.operationsTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.operationsTable.Size = new System.Drawing.Size(337, 200);
            this.operationsTable.TabIndex = 4;
            this.operationsTable.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OperationsTable_CellContentDoubleClick);
            // 
            // dateBox
            // 
            this.dateBox.DataPropertyName = "Date";
            this.dateBox.HeaderText = "Date";
            this.dateBox.Name = "dateBox";
            this.dateBox.ReadOnly = true;
            this.dateBox.Width = 60;
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
            this.amountBox.Width = 80;
            // 
            // commentBox
            // 
            this.commentBox.DataPropertyName = "Comment";
            this.commentBox.HeaderText = "Comment";
            this.commentBox.Name = "commentBox";
            this.commentBox.ReadOnly = true;
            this.commentBox.Width = 80;
            // 
            // startDateDisplay
            // 
            this.startDateDisplay.CustomFormat = "dd:MM:yyyy";
            this.startDateDisplay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.startDateDisplay.Location = new System.Drawing.Point(44, 49);
            this.startDateDisplay.Name = "startDateDisplay";
            this.startDateDisplay.Size = new System.Drawing.Size(91, 20);
            this.startDateDisplay.TabIndex = 5;
            this.startDateDisplay.Value = new System.DateTime(2021, 6, 1, 0, 0, 0, 0);
            this.startDateDisplay.Visible = false;
            this.startDateDisplay.ValueChanged += new System.EventHandler(this.DateTimePicker1_ValueChanged);
            // 
            // endDateDisplay
            // 
            this.endDateDisplay.CustomFormat = "dd:MM:yyyy HH:mm:ss";
            this.endDateDisplay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.endDateDisplay.Location = new System.Drawing.Point(141, 49);
            this.endDateDisplay.Name = "endDateDisplay";
            this.endDateDisplay.Size = new System.Drawing.Size(95, 20);
            this.endDateDisplay.TabIndex = 6;
            this.endDateDisplay.Value = new System.DateTime(2021, 6, 21, 23, 59, 33, 55);
            this.endDateDisplay.Visible = false;
            this.endDateDisplay.ValueChanged += new System.EventHandler(this.DateTimePicker2_ValueChanged);
            // 
            // accountBox
            // 
            this.accountBox.FormattingEnabled = true;
            this.accountBox.Location = new System.Drawing.Point(24, 12);
            this.accountBox.Name = "accountBox";
            this.accountBox.Size = new System.Drawing.Size(157, 21);
            this.accountBox.TabIndex = 10;
            // 
            // accountBalanceLable
            // 
            this.accountBalanceLable.AutoSize = true;
            this.accountBalanceLable.Font = new System.Drawing.Font("MV Boli", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.accountBalanceLable.ForeColor = System.Drawing.Color.Orange;
            this.accountBalanceLable.Location = new System.Drawing.Point(148, 211);
            this.accountBalanceLable.Name = "accountBalanceLable";
            this.accountBalanceLable.Size = new System.Drawing.Size(65, 24);
            this.accountBalanceLable.TabIndex = 11;
            this.accountBalanceLable.Text = "label2";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::ExpensesTracker.Properties.Resources.return__v1;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(12, 76);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(38, 38);
            this.button1.TabIndex = 19;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // openAddIncomeFormButton
            // 
            this.openAddIncomeFormButton.BackgroundImage = global::ExpensesTracker.Properties.Resources.stack_of_money__1_;
            this.openAddIncomeFormButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.openAddIncomeFormButton.FlatAppearance.BorderSize = 0;
            this.openAddIncomeFormButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openAddIncomeFormButton.Location = new System.Drawing.Point(44, 354);
            this.openAddIncomeFormButton.Name = "openAddIncomeFormButton";
            this.openAddIncomeFormButton.Size = new System.Drawing.Size(38, 38);
            this.openAddIncomeFormButton.TabIndex = 17;
            this.openAddIncomeFormButton.UseVisualStyleBackColor = true;
            this.openAddIncomeFormButton.Click += new System.EventHandler(this.CreateIncomeForm_Click);
            // 
            // editAccountButton
            // 
            this.editAccountButton.BackgroundImage = global::ExpensesTracker.Properties.Resources.pen__v1;
            this.editAccountButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.editAccountButton.FlatAppearance.BorderSize = 0;
            this.editAccountButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editAccountButton.Location = new System.Drawing.Point(289, 2);
            this.editAccountButton.Name = "editAccountButton";
            this.editAccountButton.Size = new System.Drawing.Size(38, 38);
            this.editAccountButton.TabIndex = 16;
            this.editAccountButton.UseVisualStyleBackColor = false;
            this.editAccountButton.Click += new System.EventHandler(this.EditAccountButton_Click);
            // 
            // openAddAccountFormButton
            // 
            this.openAddAccountFormButton.BackgroundImage = global::ExpensesTracker.Properties.Resources.plus__v1;
            this.openAddAccountFormButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.openAddAccountFormButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.openAddAccountFormButton.FlatAppearance.BorderSize = 0;
            this.openAddAccountFormButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openAddAccountFormButton.Location = new System.Drawing.Point(223, 2);
            this.openAddAccountFormButton.Name = "openAddAccountFormButton";
            this.openAddAccountFormButton.Size = new System.Drawing.Size(38, 38);
            this.openAddAccountFormButton.TabIndex = 15;
            this.openAddAccountFormButton.UseVisualStyleBackColor = false;
            this.openAddAccountFormButton.Click += new System.EventHandler(this.CreateAccountForm_Click);
            // 
            // editOperationButton
            // 
            this.editOperationButton.BackgroundImage = global::ExpensesTracker.Properties.Resources.pen__v1;
            this.editOperationButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.editOperationButton.FlatAppearance.BorderSize = 0;
            this.editOperationButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editOperationButton.Location = new System.Drawing.Point(236, 354);
            this.editOperationButton.Name = "editOperationButton";
            this.editOperationButton.Size = new System.Drawing.Size(38, 38);
            this.editOperationButton.TabIndex = 9;
            this.editOperationButton.UseVisualStyleBackColor = true;
            this.editOperationButton.Click += new System.EventHandler(this.EditOperationButton_Click);
            // 
            // savePdfButton
            // 
            this.savePdfButton.BackgroundImage = global::ExpensesTracker.Properties.Resources.pdf__v3;
            this.savePdfButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.savePdfButton.FlatAppearance.BorderSize = 0;
            this.savePdfButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.savePdfButton.Location = new System.Drawing.Point(152, 410);
            this.savePdfButton.Name = "savePdfButton";
            this.savePdfButton.Size = new System.Drawing.Size(38, 38);
            this.savePdfButton.TabIndex = 8;
            this.savePdfButton.UseVisualStyleBackColor = true;
            this.savePdfButton.Click += new System.EventHandler(this.SavePdfButton_Click);
            // 
            // openAddFormButton
            // 
            this.openAddFormButton.BackgroundImage = global::ExpensesTracker.Properties.Resources.tax__1_;
            this.openAddFormButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.openAddFormButton.FlatAppearance.BorderSize = 0;
            this.openAddFormButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openAddFormButton.Location = new System.Drawing.Point(152, 354);
            this.openAddFormButton.Name = "openAddFormButton";
            this.openAddFormButton.Size = new System.Drawing.Size(38, 38);
            this.openAddFormButton.TabIndex = 0;
            this.openAddFormButton.UseVisualStyleBackColor = true;
            this.openAddFormButton.Click += new System.EventHandler(this.CreateExpenseForm_Click);
            // 
            // openCategorysButton
            // 
            this.openCategorysButton.BackgroundImage = global::ExpensesTracker.Properties.Resources.unchecked_circle;
            this.openCategorysButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.openCategorysButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openCategorysButton.Location = new System.Drawing.Point(80, 134);
            this.openCategorysButton.Name = "openCategorysButton";
            this.openCategorysButton.Size = new System.Drawing.Size(194, 165);
            this.openCategorysButton.TabIndex = 18;
            this.openCategorysButton.UseVisualStyleBackColor = true;
            this.openCategorysButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // utilitiesFilterButton
            // 
            this.utilitiesFilterButton.BackgroundImage = global::ExpensesTracker.Properties.Resources._ouse_keys;
            this.utilitiesFilterButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.utilitiesFilterButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.utilitiesFilterButton.Location = new System.Drawing.Point(271, 250);
            this.utilitiesFilterButton.Name = "utilitiesFilterButton";
            this.utilitiesFilterButton.Size = new System.Drawing.Size(38, 38);
            this.utilitiesFilterButton.TabIndex = 24;
            this.utilitiesFilterButton.UseVisualStyleBackColor = true;
            this.utilitiesFilterButton.Click += new System.EventHandler(this.utilitiesFilterButton_Click);
            // 
            // medicinesAndHygieneProductsFilterButton
            // 
            this.medicinesAndHygieneProductsFilterButton.BackgroundImage = global::ExpensesTracker.Properties.Resources.doctors_bag;
            this.medicinesAndHygieneProductsFilterButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.medicinesAndHygieneProductsFilterButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.medicinesAndHygieneProductsFilterButton.Location = new System.Drawing.Point(271, 166);
            this.medicinesAndHygieneProductsFilterButton.Name = "medicinesAndHygieneProductsFilterButton";
            this.medicinesAndHygieneProductsFilterButton.Size = new System.Drawing.Size(38, 38);
            this.medicinesAndHygieneProductsFilterButton.TabIndex = 23;
            this.medicinesAndHygieneProductsFilterButton.UseVisualStyleBackColor = true;
            this.medicinesAndHygieneProductsFilterButton.Click += new System.EventHandler(this.medicinesAndHygieneProductsFilterButton_Click);
            // 
            // trafficFilterButton
            // 
            this.trafficFilterButton.BackgroundImage = global::ExpensesTracker.Properties.Resources.taxi__v1;
            this.trafficFilterButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.trafficFilterButton.FlatAppearance.BorderSize = 0;
            this.trafficFilterButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.trafficFilterButton.Location = new System.Drawing.Point(157, 101);
            this.trafficFilterButton.Name = "trafficFilterButton";
            this.trafficFilterButton.Size = new System.Drawing.Size(38, 38);
            this.trafficFilterButton.TabIndex = 20;
            this.trafficFilterButton.UseVisualStyleBackColor = false;
            this.trafficFilterButton.Click += new System.EventHandler(this.trafficFilterButton_Click);
            // 
            // allCategorysFilterButton
            // 
            this.allCategorysFilterButton.BackgroundImage = global::ExpensesTracker.Properties.Resources.select_all;
            this.allCategorysFilterButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.allCategorysFilterButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.allCategorysFilterButton.Location = new System.Drawing.Point(157, 305);
            this.allCategorysFilterButton.Name = "allCategorysFilterButton";
            this.allCategorysFilterButton.Size = new System.Drawing.Size(38, 38);
            this.allCategorysFilterButton.TabIndex = 19;
            this.allCategorysFilterButton.UseVisualStyleBackColor = false;
            this.allCategorysFilterButton.Click += new System.EventHandler(this.allCategorysFilterButton_Click);
            // 
            // servicesCommunicationFilterButton
            // 
            this.servicesCommunicationFilterButton.BackgroundImage = global::ExpensesTracker.Properties.Resources.cell_phone;
            this.servicesCommunicationFilterButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.servicesCommunicationFilterButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.servicesCommunicationFilterButton.Location = new System.Drawing.Point(44, 250);
            this.servicesCommunicationFilterButton.Name = "servicesCommunicationFilterButton";
            this.servicesCommunicationFilterButton.Size = new System.Drawing.Size(38, 38);
            this.servicesCommunicationFilterButton.TabIndex = 22;
            this.servicesCommunicationFilterButton.UseVisualStyleBackColor = true;
            this.servicesCommunicationFilterButton.Click += new System.EventHandler(this.servicesCommunicationFilterButton_Click);
            // 
            // foodFilterButton
            // 
            this.foodFilterButton.BackgroundImage = global::ExpensesTracker.Properties.Resources.hamburger;
            this.foodFilterButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.foodFilterButton.FlatAppearance.BorderSize = 0;
            this.foodFilterButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.foodFilterButton.Location = new System.Drawing.Point(44, 166);
            this.foodFilterButton.Name = "foodFilterButton";
            this.foodFilterButton.Size = new System.Drawing.Size(38, 38);
            this.foodFilterButton.TabIndex = 21;
            this.foodFilterButton.UseVisualStyleBackColor = true;
            this.foodFilterButton.Click += new System.EventHandler(this.foodFilterButton_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(356, 450);
            this.Controls.Add(this.accountBalanceLable);
            this.Controls.Add(this.openAddIncomeFormButton);
            this.Controls.Add(this.editAccountButton);
            this.Controls.Add(this.openAddAccountFormButton);
            this.Controls.Add(this.accountBox);
            this.Controls.Add(this.editOperationButton);
            this.Controls.Add(this.savePdfButton);
            this.Controls.Add(this.endDateDisplay);
            this.Controls.Add(this.startDateDisplay);
            this.Controls.Add(this.searchNameInput);
            this.Controls.Add(this.categoryFilterBox);
            this.Controls.Add(this.openAddFormButton);
            this.Controls.Add(this.openCategorysButton);
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
        public System.Windows.Forms.TextBox searchNameInput;
        public System.Windows.Forms.DataGridView operationsTable;
        private System.Windows.Forms.DateTimePicker startDateDisplay;
        private System.Windows.Forms.DateTimePicker endDateDisplay;
        private System.Windows.Forms.Button savePdfButton;
        private System.Windows.Forms.Button editOperationButton;
        private System.Windows.Forms.ComboBox accountBox;
        private System.Windows.Forms.Label accountBalanceLable;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button openAddAccountFormButton;
        private System.Windows.Forms.Button editAccountButton;
        private System.Windows.Forms.BindingSource accountBindingSource;
        private System.Windows.Forms.Button openAddIncomeFormButton;
        private System.Windows.Forms.Button openCategorysButton;
        private System.Windows.Forms.Button allCategorysFilterButton;
        private System.Windows.Forms.Button trafficFilterButton;
        private System.Windows.Forms.Button foodFilterButton;
        private System.Windows.Forms.Button servicesCommunicationFilterButton;
        private System.Windows.Forms.Button medicinesAndHygieneProductsFilterButton;
        private System.Windows.Forms.Button utilitiesFilterButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoryBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn commentBox;
        private System.Windows.Forms.Button button1;
    }
}

