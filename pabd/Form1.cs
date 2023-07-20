using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pabd
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void panelTitleBar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Username_TextChanged(object sender, EventArgs e)
        {

        }

        private void Login_Click(object sender, EventArgs e)
        {
            string username, password;
            username = Username.Text;
            password = Password.Text;
            SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-M7MD7ENC\ARFAN_MAULANA");
            try
            {
                string strkoneksi = "data source = LAPTOP-M7MD7ENC\\ARFAN_MAULANA;initial catalog = ApotikNEW;user ID = {0}; password = {1}";
                conn = new SqlConnection(string.Format(strkoneksi, username, password));
                conn.Open();

                MainMenu MM = new MainMenu();
                MM.Show();
                this.Hide();
            }
            catch
            {
                MessageBox.Show("Invalid Login");
                Username.Clear();
                Password.Clear();
                Username.Focus();
            }
            finally
            {
                conn.Close();
            }
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            Username.Clear();
            Password.Clear();
            Username.Focus();
        }
    }
}
