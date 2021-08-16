using ExpensesTracker.Models;
using ExpensesTracker.Models.Enums;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ExpensesTracker.Services
{
    public class OperationsTableManager
    {
        private readonly DataGridView _operationsTable;

        public OperationsTableManager(DataGridView operationsTable)
        {
            _operationsTable = operationsTable;

            _operationsTable.AllowUserToResizeColumns = false;
            _operationsTable.AllowUserToResizeRows = false;
            _operationsTable.AutoGenerateColumns = false;
        }

        public void RefreshTable(List<AccountOperation> filteredOperations)
        {
            ActualizeTableRecords(filteredOperations);
            ColorTable(filteredOperations);
        }

        public void ColorSelectedRow()
        {
            if (_operationsTable.SelectedRows.Count == 0 ||
                !(_operationsTable.SelectedRows[0].DataBoundItem is AccountOperation operation))
                return;

            _operationsTable.DefaultCellStyle.SelectionBackColor = operation.Type == OperationType.Expense
                ? Color.Brown
                : Color.DarkOliveGreen;
        }

        public AccountOperation GetSelectedAccountOperation()
        {
            if (_operationsTable.SelectedRows.Count == 0)
                return null;

            var selectedAccountOperation = _operationsTable.SelectedRows[0].DataBoundItem;
            return (AccountOperation)selectedAccountOperation;
        }

        private void ActualizeTableRecords(List<AccountOperation> filterOperations)
        {
            _operationsTable.DataSource = null;
            _operationsTable.DataSource = filterOperations;
            _operationsTable.ClearSelection();
        }

        private void ColorTable(List<AccountOperation> filterOperations)
        {
            for (var i = 0; i < filterOperations.Count; i++)
            {
                if (filterOperations[i].Type == OperationType.Expense)
                {
                    _operationsTable.Rows[i].DefaultCellStyle.BackColor = Color.PaleVioletRed;
                }

                if (filterOperations[i].Type == OperationType.Income)
                {
                    _operationsTable.Rows[i].DefaultCellStyle.BackColor = Color.DarkSeaGreen;
                }
            }
        }
    }
}
