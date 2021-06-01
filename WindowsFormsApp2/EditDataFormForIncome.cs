using System;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class EditDataFormForIncome : Form
    {
        public Action OnIncomeEdit;
        public Action OnIncomeDeleted;
        public AccountOperation TargetIncome;

        public EditDataFormForIncome()
        {
            InitializeComponent();
        }
        private void EditDataFormForIncome_Load(object sender, EventArgs e)
        {
            editeIncomeCommentTextBox.Text = TargetIncome.Comment;
            incomeAmountInput.Value = TargetIncome.Cost;
            incomeDateInput.Value = TargetIncome.Date;
        }

        private void CancelEditButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DeleteTargetIncomeBtn_Click(object sender, EventArgs e)
        {
            OnIncomeDeleted();
            this.Close();
        }

        private void SaveEditedIncomeButton_Click(object sender, EventArgs e)
        {
            TargetIncome.Comment = editeIncomeCommentTextBox.Text;
            TargetIncome.Cost = incomeAmountInput.Value;
            TargetIncome.Date = incomeDateInput.Value;
            OnIncomeEdit();
            this.Close();
        }
    }
}
