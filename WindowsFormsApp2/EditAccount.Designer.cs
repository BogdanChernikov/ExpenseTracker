
namespace WindowsFormsApp2
{
    partial class EditAccount
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
            this.canceledEditAccount = new System.Windows.Forms.Button();
            this.saveEditedAccountButton = new System.Windows.Forms.Button();
            this.editInitialBalanceInput = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.editAccountNameInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.deleteAccountButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.editInitialBalanceInput)).BeginInit();
            this.SuspendLayout();
            // 
            // canceledEditAccount
            // 
            this.canceledEditAccount.Location = new System.Drawing.Point(190, 145);
            this.canceledEditAccount.Name = "canceledEditAccount";
            this.canceledEditAccount.Size = new System.Drawing.Size(75, 23);
            this.canceledEditAccount.TabIndex = 11;
            this.canceledEditAccount.Text = "Cancel";
            this.canceledEditAccount.UseVisualStyleBackColor = true;
            this.canceledEditAccount.Click += new System.EventHandler(this.CanceledEditAccount_Click);
            // 
            // saveEditedAccountButton
            // 
            this.saveEditedAccountButton.Location = new System.Drawing.Point(190, 48);
            this.saveEditedAccountButton.Name = "saveEditedAccountButton";
            this.saveEditedAccountButton.Size = new System.Drawing.Size(75, 23);
            this.saveEditedAccountButton.TabIndex = 10;
            this.saveEditedAccountButton.Text = "Save";
            this.saveEditedAccountButton.UseVisualStyleBackColor = true;
            this.saveEditedAccountButton.Click += new System.EventHandler(this.SaveEditedAccountButton_Click);
            // 
            // editInitialBalanceInput
            // 
            this.editInitialBalanceInput.Location = new System.Drawing.Point(45, 145);
            this.editInitialBalanceInput.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.editInitialBalanceInput.Name = "editInitialBalanceInput";
            this.editInitialBalanceInput.Size = new System.Drawing.Size(120, 20);
            this.editInitialBalanceInput.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Enter inital balance";
            // 
            // editAccountNameInput
            // 
            this.editAccountNameInput.Location = new System.Drawing.Point(45, 68);
            this.editAccountNameInput.Name = "editAccountNameInput";
            this.editAccountNameInput.Size = new System.Drawing.Size(128, 20);
            this.editAccountNameInput.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Enter account name";
            // 
            // deleteAccountButton
            // 
            this.deleteAccountButton.Location = new System.Drawing.Point(190, 99);
            this.deleteAccountButton.Name = "deleteAccountButton";
            this.deleteAccountButton.Size = new System.Drawing.Size(75, 23);
            this.deleteAccountButton.TabIndex = 12;
            this.deleteAccountButton.Text = "Delete";
            this.deleteAccountButton.UseVisualStyleBackColor = true;
            this.deleteAccountButton.Click += new System.EventHandler(this.DeleteAccountButton_Click);
            // 
            // EditAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 256);
            this.Controls.Add(this.deleteAccountButton);
            this.Controls.Add(this.canceledEditAccount);
            this.Controls.Add(this.saveEditedAccountButton);
            this.Controls.Add(this.editInitialBalanceInput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.editAccountNameInput);
            this.Controls.Add(this.label1);
            this.Name = "EditAccount";
            this.Text = "EditAccount";
            this.Load += new System.EventHandler(this.EditAccount_Load);
            ((System.ComponentModel.ISupportInitialize)(this.editInitialBalanceInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button canceledEditAccount;
        private System.Windows.Forms.Button saveEditedAccountButton;
        private System.Windows.Forms.NumericUpDown editInitialBalanceInput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox editAccountNameInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button deleteAccountButton;
    }
}