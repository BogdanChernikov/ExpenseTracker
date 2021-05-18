
namespace WindowsFormsApp2
{
    partial class EditExpense
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
            this.newCostDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CancelAddButton = new System.Windows.Forms.Button();
            this.EditExpenseButton = new System.Windows.Forms.Button();
            this.commentInput = new System.Windows.Forms.TextBox();
            this.PriceInput = new System.Windows.Forms.NumericUpDown();
            this.newCostCategory = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.PriceInput)).BeginInit();
            this.SuspendLayout();
            // 
            // newCostDate
            // 
            this.newCostDate.CustomFormat = "dd:MM:yyyy";
            this.newCostDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.newCostDate.Location = new System.Drawing.Point(56, 269);
            this.newCostDate.Name = "newCostDate";
            this.newCostDate.Size = new System.Drawing.Size(121, 20);
            this.newCostDate.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(56, 213);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Comment";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Enter price";
            // 
            // CancelAddButton
            // 
            this.CancelAddButton.Location = new System.Drawing.Point(173, 317);
            this.CancelAddButton.Name = "CancelAddButton";
            this.CancelAddButton.Size = new System.Drawing.Size(75, 23);
            this.CancelAddButton.TabIndex = 15;
            this.CancelAddButton.Text = "Cancel";
            this.CancelAddButton.UseVisualStyleBackColor = true;
            // 
            // EditExpenseButton
            // 
            this.EditExpenseButton.Location = new System.Drawing.Point(56, 317);
            this.EditExpenseButton.Name = "EditExpenseButton";
            this.EditExpenseButton.Size = new System.Drawing.Size(75, 23);
            this.EditExpenseButton.TabIndex = 14;
            this.EditExpenseButton.Text = "Edit";
            this.EditExpenseButton.UseVisualStyleBackColor = true;
            // 
            // commentInput
            // 
            this.commentInput.Location = new System.Drawing.Point(56, 232);
            this.commentInput.Name = "commentInput";
            this.commentInput.Size = new System.Drawing.Size(120, 20);
            this.commentInput.TabIndex = 13;
            // 
            // PriceInput
            // 
            this.PriceInput.Location = new System.Drawing.Point(56, 179);
            this.PriceInput.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.PriceInput.Name = "PriceInput";
            this.PriceInput.Size = new System.Drawing.Size(120, 20);
            this.PriceInput.TabIndex = 12;
            // 
            // newCostCategory
            // 
            this.newCostCategory.FormattingEnabled = true;
            this.newCostCategory.Items.AddRange(new object[] {
            "Traffic",
            "Utilities",
            "Services Communication",
            "Medicines And Hygiene Products",
            "Food"});
            this.newCostCategory.Location = new System.Drawing.Point(56, 70);
            this.newCostCategory.Name = "newCostCategory";
            this.newCostCategory.Size = new System.Drawing.Size(121, 21);
            this.newCostCategory.TabIndex = 10;
            this.newCostCategory.Text = "Select a category";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(56, 118);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 20;
            // 
            // EditExpense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 411);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.newCostDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CancelAddButton);
            this.Controls.Add(this.EditExpenseButton);
            this.Controls.Add(this.commentInput);
            this.Controls.Add(this.PriceInput);
            this.Controls.Add(this.newCostCategory);
            this.Name = "EditExpense";
            this.Text = "EditExpense";
            ((System.ComponentModel.ISupportInitialize)(this.PriceInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker newCostDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button CancelAddButton;
        private System.Windows.Forms.Button EditExpenseButton;
        private System.Windows.Forms.TextBox commentInput;
        private System.Windows.Forms.NumericUpDown PriceInput;
        private System.Windows.Forms.ComboBox newCostCategory;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}