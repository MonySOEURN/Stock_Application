using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Stock
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Clear();
            textBox1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // To-Do check username & password
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-8TDSR33\CSMOSQL;Initial Catalog=Stock;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter(@"SELECT *
                FROM[dbo].[Login] WHERE UserName = 'admin' AND Password = 'admin@123'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            this.Hide();
            StockMain main = new StockMain();
            main.Show();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
