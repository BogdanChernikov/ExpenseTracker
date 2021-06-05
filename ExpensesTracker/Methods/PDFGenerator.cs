using ExpensesTracker.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace ExpensesTracker.Methods
{
    public class PDFGenerator
    {
        public void GeneratePdf(List<AccountOperation> _filteredOperations)
        {
            iTextSharp.text.Document doc = new iTextSharp.text.Document();
            PdfWriter.GetInstance(doc, new FileStream("pdfTables.pdf", FileMode.Create));
            doc.Open();
            PdfPTable table = new PdfPTable(4);

            table.AddCell("Date");
            table.AddCell("Category");
            table.AddCell("Amount");
            table.AddCell("Comment");

            for (int j = 0; j < _filteredOperations.Count; j++)
            {
                table.AddCell(new Phrase(_filteredOperations[j].Date.ToString()));
                if (_filteredOperations[j].Category == null)
                {
                    table.AddCell(new Phrase(""));
                }
                else
                {
                    table.AddCell(new Phrase(_filteredOperations[j].Category.ToString()));
                }
                table.AddCell(new Phrase(_filteredOperations[j].Amount.ToString()));
                table.AddCell(new Phrase(_filteredOperations[j].Comment.ToString()));
            }

            doc.Add(table);
            doc.Close();
            MessageBox.Show("Pdf seved");
        }
    }
}
