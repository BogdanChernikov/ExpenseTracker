
namespace WindowsFormsApp2
{
    partial class EditDataForm
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
            this.CancelEditButton = new System.Windows.Forms.Button();
            this.EditDataButton = new System.Windows.Forms.Button();
            this.commentInput = new System.Windows.Forms.TextBox();
            this.PriceInput = new System.Windows.Forms.NumericUpDown();
            this.newCostCategory = new System.Windows.Forms.ComboBox();
            this.deleteDataButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PriceInput)).BeginInit();
            this.SuspendLayout();
            // 
            // newCostDate
            // 
            this.newCostDate.CustomFormat = "dd:MM:yyyy";
            this.newCostDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.newCostDate.Location = new System.Drawing.Point(48, 232);
            this.newCostDate.Name = "newCostDate";
            this.newCostDate.Size = new System.Drawing.Size(121, 20);
            this.newCostDate.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Comment";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Enter price";
            // 
            // CancelEditButton
            // 
            this.CancelEditButton.Location = new System.Drawing.Point(195, 211);
            this.CancelEditButton.Name = "CancelEditButton";
            this.CancelEditButton.Size = new System.Drawing.Size(75, 23);
            this.CancelEditButton.TabIndex = 14;
            this.CancelEditButton.Text = "Cancel";
            this.CancelEditButton.UseVisualStyleBackColor = true;
            // 
            // EditDataButton
            // 
            this.EditDataButton.Location = new System.Drawing.Point(195, 75);
            this.EditDataButton.Name = "EditDataButton";
            this.EditDataButton.Size = new System.Drawing.Size(75, 23);
            this.EditDataButton.TabIndex = 13;
            this.EditDataButton.Text = "Save";
            this.EditDataButton.UseVisualStyleBackColor = true;
            // 
            // commentInput
            // 
            this.commentInput.Location = new System.Drawing.Point(48, 180);
            this.commentInput.Name = "commentInput";
            this.commentInput.Size = new System.Drawing.Size(120, 20);
            this.commentInput.TabIndex = 12;
            // 
            // PriceInput
            // 
            this.PriceInput.Location = new System.Drawing.Point(49, 116);
            this.PriceInput.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.PriceInput.Name = "PriceInput";
            this.PriceInput.Size = new System.Drawing.Size(120, 20);
            this.PriceInput.TabIndex = 11;
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
            this.newCostCategory.Location = new System.Drawing.Point(48, 42);
            this.newCostCategory.Name = "newCostCategory";
            this.newCostCategory.Size = new System.Drawing.Size(121, 21);
            this.newCostCategory.TabIndex = 10;
            this.newCostCategory.Text = "Select a category";
            // 
            // deleteDataButton
            // 
            this.deleteDataButton.Location = new System.Drawing.Point(195, 142);
            this.deleteDataButton.Name = "deleteDataButton";
            this.deleteDataButton.Size = new System.Drawing.Size(75, 23);
            this.deleteDataButton.TabIndex = 18;
            this.deleteDataButton.Text = "Delete";
            this.deleteDataButton.UseVisualStyleBackColor = true;
            // 
            // EditDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 450);
            this.Controls.Add(this.deleteDataButton);
            this.Controls.Add(this.newCostDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CancelEditButton);
            this.Controls.Add(this.EditDataButton);
            this.Controls.Add(this.commentInput);
            this.Controls.Add(this.PriceInput);
            this.Controls.Add(this.newCostCategory);
            this.Name = "EditDataForm";
            this.Text = "EditDataForm";
            ((System.ComponentModel.ISupportInitialize)(this.PriceInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker newCostDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button CancelEditButton;
        private System.Windows.Forms.Button EditDataButton;
        private System.Windows.Forms.TextBox commentInput;
        private System.Windows.Forms.NumericUpDown PriceInput;
        private System.Windows.Forms.ComboBox newCostCategory;
        private System.Windows.Forms.Button deleteDataButton;
    }
}