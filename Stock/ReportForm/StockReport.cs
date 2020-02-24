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
using CrystalDecisions.Shared;

namespace Stock.ReportForm
{
    public partial class StockReport : Form
    {
        ReportDocument cryrpt = new ReportDocument();
        public StockReport()
        {
            InitializeComponent();
        }

        private void StockReport_Load(object sender, EventArgs e)
        {

        }
        DataSet dst = new DataSet();
        private void button1_Click(object sender, EventArgs e)
        {
            cryrpt.Load(@"C:\Users\pc-ssss\Desktop\Stock\Stock\Reports\Stock.rpt");
            SqlConnection con = Connection.GetConnection();
            con.Open(); 
            SqlDataAdapter sda = new SqlDataAdapter("Select * From [Stock] where Cast( TransDate as Date) between '" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "' and '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "'",con);
            sda.Fill(dst, "Stock");
            cryrpt.SetDataSource(dst);
            cryrpt.SetParameterValue("@FromDate", dateTimePicker1.Value.ToString("dd/MM/yyyy"));
            cryrpt.SetParameterValue("@ToDate", dateTimePicker2.Value.ToString("dd/MM/yyyy"));
            crystalReportViewer1.ReportSource = cryrpt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ExportOptions exportOption;
            DiskFileDestinationOptions diskFileDestinationOptions = new DiskFileDestinationOptions();
            SaveFileDialog sfd = new SaveFileDialog();
            //sfd.Filter = "Pdf Files|*.pdf";
            sfd.Filter = "Excel|*.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                diskFileDestinationOptions.DiskFileName = sfd.FileName;
            }
            exportOption = cryrpt.ExportOptions;
            {
                exportOption.ExportDestinationType = ExportDestinationType.DiskFile;
                //exportOption.ExportFormatType = ExportFormatType.PortableDocFormat;
                exportOption.ExportFormatType = ExportFormatType.Excel;
                exportOption.ExportDestinationOptions = diskFileDestinationOptions;
                //exportOption.ExportFormatOptions = new PdfRtfWordFormatOptions();
                exportOption.ExportFormatOptions = new ExcelFormatOptions();
            }
            cryrpt.Export();
        }
    }
}
