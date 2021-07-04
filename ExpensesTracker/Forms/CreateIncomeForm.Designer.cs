using System;

namespace ExpensesTracker.Forms
{
    partial class CreateIncomeForm
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
        private void InitializeComponent()
        {
            this.incomeAmountInput = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.incomeCommentTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.incomeDateInput = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.addIncomeButton = new System.Windows.Forms.Button();
            this.closedFormButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.incomeAmountInput)).BeginInit();
            this.SuspendLayout();
            // 
            // incomeAmountInput
            // 
            this.incomeAmountInput.Location = new System.Drawing.Point(32, 134);
            this.incomeAmountInput.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.incomeAmountInput.Name = "incomeAmountInput";
            this.incomeAmountInput.Size = new System.Drawing.Size(120, 20);
            this.incomeAmountInput.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Enter amount of income";
            // 
            // incomeCommentTextBox
            // 
            this.incomeCommentTextBox.Location = new System.Drawing.Point(32, 57);
            this.incomeCommentTextBox.Name = "incomeCommentTextBox";
            this.incomeCommentTextBox.Size = new System.Drawing.Size(128, 20);
            this.incomeCommentTextBox.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Enter comment";
            // 
            // incomeDateInput
            // 
            this.incomeDateInput.CustomFormat = "dd:MM:yyyy";
            this.incomeDateInput.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.incomeDateInput.Location = new System.Drawing.Point(31, 211);
            this.incomeDateInput.Name = "incomeDateInput";
            this.incomeDateInput.Size = new System.Drawing.Size(121, 20);
            this.incomeDateInput.TabIndex = 8;
            this.incomeDateInput.Value = new System.DateTime(2021, 6, 23, 0, 0, 0, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Enter income date";
            // 
            // addIncomeButton
            // 
            this.addIncomeButton.Location = new System.Drawing.Point(12, 264);
            this.addIncomeButton.Name = "addIncomeButton";
            this.addIncomeButton.Size = new System.Drawing.Size(75, 23);
            this.addIncomeButton.TabIndex = 10;
            this.addIncomeButton.Text = "Add";
            this.addIncomeButton.UseVisualStyleBackColor = true;
            this.addIncomeButton.Click += new System.EventHandler(this.AddIncomeButton_Click);
            // 
            // closedFormButton
            // 
            this.closedFormButton.Location = new System.Drawing.Point(115, 264);
            this.closedFormButton.Name = "closedFormButton";
            this.closedFormButton.Size = new System.Drawing.Size(75, 23);
            this.closedFormButton.TabIndex = 11;
            this.closedFormButton.Text = "Cancel";
            this.closedFormButton.UseVisualStyleBackColor = true;
            this.closedFormButton.Click += new System.EventHandler(this.CloseAddIncomeButton_Click);
            // 
            // CreateIncomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(210, 299);
            this.Controls.Add(this.closedFormButton);
            this.Controls.Add(this.addIncomeButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.incomeDateInput);
            this.Controls.Add(this.incomeAmountInput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.incomeCommentTextBox);
            this.Controls.Add(this.label1);
            this.Name = "CreateIncomeForm";
            this.Text = "Add new income";
            ((System.ComponentModel.ISupportInitialize)(this.incomeAmountInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown incomeAmountInput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox incomeCommentTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker incomeDateInput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button addIncomeButton;
        private System.Windows.Forms.Button closedFormButton;
    }
}