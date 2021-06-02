
namespace WindowsFormsApp2
{
    partial class AddExpenseForm
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
            this.newCostCategory = new System.Windows.Forms.ComboBox();
            this.PriceInput = new System.Windows.Forms.NumericUpDown();
            this.commentInput = new System.Windows.Forms.TextBox();
            this.AddCostButton = new System.Windows.Forms.Button();
            this.CancelAddButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.newCostDate = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.PriceInput)).BeginInit();
            this.SuspendLayout();
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
            this.newCostCategory.Location = new System.Drawing.Point(49, 57);
            this.newCostCategory.Name = "newCostCategory";
            this.newCostCategory.Size = new System.Drawing.Size(121, 21);
            this.newCostCategory.TabIndex = 0;
            this.newCostCategory.Text = "Select a category";
            // 
            // PriceInput
            // 
            this.PriceInput.Location = new System.Drawing.Point(50, 131);
            this.PriceInput.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.PriceInput.Name = "PriceInput";
            this.PriceInput.Size = new System.Drawing.Size(120, 20);
            this.PriceInput.TabIndex = 2;
            // 
            // commentInput
            // 
            this.commentInput.Location = new System.Drawing.Point(49, 195);
            this.commentInput.Name = "commentInput";
            this.commentInput.Size = new System.Drawing.Size(120, 20);
            this.commentInput.TabIndex = 3;
            // 
            // AddCostButton
            // 
            this.AddCostButton.Location = new System.Drawing.Point(49, 304);
            this.AddCostButton.Name = "AddCostButton";
            this.AddCostButton.Size = new System.Drawing.Size(75, 23);
            this.AddCostButton.TabIndex = 4;
            this.AddCostButton.Text = "Add";
            this.AddCostButton.UseVisualStyleBackColor = true;
            this.AddCostButton.Click += new System.EventHandler(this.AddCostButton_Click);
            // 
            // CancelAddButton
            // 
            this.CancelAddButton.Location = new System.Drawing.Point(166, 304);
            this.CancelAddButton.Name = "CancelAddButton";
            this.CancelAddButton.Size = new System.Drawing.Size(75, 23);
            this.CancelAddButton.TabIndex = 5;
            this.CancelAddButton.Text = "Cancel";
            this.CancelAddButton.UseVisualStyleBackColor = true;
            this.CancelAddButton.Click += new System.EventHandler(this.CancelAddButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Enter price";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Comment";
            // 
            // newCostDate
            // 
            this.newCostDate.CustomFormat = "dd:MM:yyyy";
            this.newCostDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.newCostDate.Location = new System.Drawing.Point(49, 247);
            this.newCostDate.Name = "newCostDate";
            this.newCostDate.Size = new System.Drawing.Size(121, 20);
            this.newCostDate.TabIndex = 9;
            // 
            // AddExpenseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 380);
            this.Controls.Add(this.newCostDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CancelAddButton);
            this.Controls.Add(this.AddCostButton);
            this.Controls.Add(this.commentInput);
            this.Controls.Add(this.PriceInput);
            this.Controls.Add(this.newCostCategory);
            this.Name = "AddExpenseForm";
            this.Text = "AddCostForm";
            ((System.ComponentModel.ISupportInitialize)(this.PriceInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox newCostCategory;
        private System.Windows.Forms.NumericUpDown PriceInput;
        private System.Windows.Forms.TextBox commentInput;
        private System.Windows.Forms.Button AddCostButton;
        private System.Windows.Forms.Button CancelAddButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker newCostDate;
    }
}