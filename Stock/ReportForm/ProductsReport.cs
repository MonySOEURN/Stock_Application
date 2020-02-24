using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;

namespace Stock.ReportForm
{
    public partial class ProductsReport : Form
    {
        ReportDocument cryrpt = new ReportDocument();
        public ProductsReport()
        {
            InitializeComponent();
        }


        private void ProductsReport_Load(object sender, EventArgs e)
        {
            cryrpt.Load(@"C:\Users\pc-ssss\Desktop\Stock\Stock\Reports\Product.rpt");
            SqlConnection con = Connection.GetConnection();
            con.Open(); 
            DataSet dst = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter("Select * From [Products]", con);
            sda.Fill(dst, "Products");
            con.Close();
            DataTable dt = new DataTable();
            dt.Columns.Add("WaterMarkPath", typeof(string));
            dt.Rows.Add(@"C:\Users\pc-ssss\Desktop\duplicate.jpg");
            cryrpt.Database.Tables["Products"].SetDataSource(dst.Tables[0]);
            cryrpt.Database.Tables["ReportDetail"].SetDataSource(dt);
            sda.Fill(dt);
            crystalReportViewer1.ReportSource = cryrpt;
        }
    }
}
