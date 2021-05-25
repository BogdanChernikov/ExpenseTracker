
namespace WindowsFormsApp2
{
    partial class IncomeForm
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
            this.incomesesTable = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.addIncomeButton = new System.Windows.Forms.Button();
            this.deleteIncomeButton = new System.Windows.Forms.Button();
            this.editIncomeButton = new System.Windows.Forms.Button();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.incomesesTable)).BeginInit();
            this.SuspendLayout();
            // 
            // incomesesTable
            // 
            this.incomesesTable.AllowUserToAddRows = false;
            this.incomesesTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.incomesesTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Date,
            this.Amount,
            this.Comment});
            this.incomesesTable.Location = new System.Drawing.Point(12, 54);
            this.incomesesTable.Name = "incomesesTable";
            this.incomesesTable.RowHeadersVisible = false;
            this.incomesesTable.Size = new System.Drawing.Size(306, 183);
            this.incomesesTable.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // addIncomeButton
            // 
            this.addIncomeButton.Location = new System.Drawing.Point(336, 67);
            this.addIncomeButton.Name = "addIncomeButton";
            this.addIncomeButton.Size = new System.Drawing.Size(75, 23);
            this.addIncomeButton.TabIndex = 2;
            this.addIncomeButton.Text = "Add";
            this.addIncomeButton.UseVisualStyleBackColor = true;
            // 
            // deleteIncomeButton
            // 
            this.deleteIncomeButton.Location = new System.Drawing.Point(336, 149);
            this.deleteIncomeButton.Name = "deleteIncomeButton";
            this.deleteIncomeButton.Size = new System.Drawing.Size(75, 23);
            this.deleteIncomeButton.TabIndex = 3;
            this.deleteIncomeButton.Text = "Delete";
            this.deleteIncomeButton.UseVisualStyleBackColor = true;
            // 
            // editIncomeButton
            // 
            this.editIncomeButton.Location = new System.Drawing.Point(336, 109);
            this.editIncomeButton.Name = "editIncomeButton";
            this.editIncomeButton.Size = new System.Drawing.Size(75, 23);
            this.editIncomeButton.TabIndex = 4;
            this.editIncomeButton.Text = "Edit";
            this.editIncomeButton.UseVisualStyleBackColor = true;
            // 
            // Date
            // 
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            // 
            // Amount
            // 
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            // 
            // Comment
            // 
            this.Comment.HeaderText = "Comment";
            this.Comment.Name = "Comment";
            // 
            // Incomes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 289);
            this.Controls.Add(this.editIncomeButton);
            this.Controls.Add(this.deleteIncomeButton);
            this.Controls.Add(this.addIncomeButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.incomesesTable);
            this.Name = "Incomes";
            this.Text = "Incomes";
            ((System.ComponentModel.ISupportInitialize)(this.incomesesTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView incomesesTable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addIncomeButton;
        private System.Windows.Forms.Button deleteIncomeButton;
        private System.Windows.Forms.Button editIncomeButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comment;
    }
}