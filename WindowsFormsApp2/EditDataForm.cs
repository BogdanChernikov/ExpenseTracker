using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class EditDataForm : Form
    {
        Expenses expenses = new Expenses();
        public List<Expenses> expenes;
        public DataGridView dataGridView1;
        public MainWindow.CostRow tab;

        public EditDataForm()
        {
            InitializeComponent();
        }

    }
}
