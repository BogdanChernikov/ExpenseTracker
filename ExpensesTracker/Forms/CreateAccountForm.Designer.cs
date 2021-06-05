
namespace ExpensesTracker.Forms
{
    partial class AddNewAccount
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
            this.label1 = new System.Windows.Forms.Label();
            this.newAccountNameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.initialBalanceInput = new System.Windows.Forms.NumericUpDown();
            this.addNewAccountButton = new System.Windows.Forms.Button();
            this.CanceledAddAccount = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.initialBalanceInput)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter account name";
            // 
            // newAccountName
            // 
            this.newAccountNameTextBox.Location = new System.Drawing.Point(45, 58);
            this.newAccountNameTextBox.Name = "newAccountName";
            this.newAccountNameTextBox.Size = new System.Drawing.Size(128, 20);
            this.newAccountNameTextBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Enter inital balance";
            // 
            // initialBalance
            // 
            this.initialBalanceInput.Location = new System.Drawing.Point(45, 135);
            this.initialBalanceInput.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.initialBalanceInput.Name = "initialBalance";
            this.initialBalanceInput.Size = new System.Drawing.Size(120, 20);
            this.initialBalanceInput.TabIndex = 3;
            // 
            // addNewAccountButton
            // 
            this.addNewAccountButton.Location = new System.Drawing.Point(45, 186);
            this.addNewAccountButton.Name = "addNewAccountButton";
            this.addNewAccountButton.Size = new System.Drawing.Size(75, 23);
            this.addNewAccountButton.TabIndex = 4;
            this.addNewAccountButton.Text = "Add";
            this.addNewAccountButton.UseVisualStyleBackColor = true;
            this.addNewAccountButton.Click += new System.EventHandler(this.AddNewAccountButton_Click);
            // 
            // CanceledAddAccount
            // 
            this.CanceledAddAccount.Location = new System.Drawing.Point(136, 186);
            this.CanceledAddAccount.Name = "CanceledAddAccount";
            this.CanceledAddAccount.Size = new System.Drawing.Size(75, 23);
            this.CanceledAddAccount.TabIndex = 5;
            this.CanceledAddAccount.Text = "Cancel";
            this.CanceledAddAccount.UseVisualStyleBackColor = true;
            this.CanceledAddAccount.Click += new System.EventHandler(this.CanceledAddAccount_Click);
            // 
            // AddNewAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 262);
            this.Controls.Add(this.CanceledAddAccount);
            this.Controls.Add(this.addNewAccountButton);
            this.Controls.Add(this.initialBalanceInput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.newAccountNameTextBox);
            this.Controls.Add(this.label1);
            this.Name = "AddNewAccount";
            this.Text = "AddNewAccount";
            ((System.ComponentModel.ISupportInitialize)(this.initialBalanceInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox newAccountNameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown initialBalanceInput;
        private System.Windows.Forms.Button addNewAccountButton;
        private System.Windows.Forms.Button CanceledAddAccount;
    }
}