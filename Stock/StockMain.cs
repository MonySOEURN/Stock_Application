using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stock
{
    public partial class StockMain : Form
    {

        public StockMain()
        {
            InitializeComponent();
        }

        private void productToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Products pro = new Products();
            pro.MdiParent = this;
            pro.StartPosition = FormStartPosition.CenterScreen;
            pro.Show();
        }

        private void StockMain_Load(object sender, EventArgs e)
        {

        }
        bool close = true;
        private void StockMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(close)
            {
                DialogResult dialogResult = MessageBox.Show("Are You Sure Want to Exit", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    close = false;
                    Application.Exit();
                }
                else
                {
                    e.Cancel = true;
                }
            }
            
        }

        private void productListToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ReportForm.ProductsReport prod = new ReportForm.ProductsReport();
            prod.MdiParent = this;
            prod.StartPosition = FormStartPosition.CenterScreen;
            prod.Show();
            
        }
    }
}
