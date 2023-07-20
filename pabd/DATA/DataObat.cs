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

namespace pabd.DATA
{
    public partial class DataObat : Form

    {
        SqlConnection conn = new SqlConnection(@"data source = LAPTOP-M7MD7ENC\ARFAN_MAULANA;initial catalog = ApotikNEW;Integrated Security=True");
        public DataObat()
        {
            InitializeComponent();
        }

        private void refreshform()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox1.Focus();
        }
        private void Lihatdata()
        {
            conn.Open();
            string str = "select * from dbo.input";
            SqlDataAdapter da = new SqlDataAdapter(str, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            conn.Close();
        }
        private void Add_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand check = new SqlCommand("select ID_Obat from dbo.Obat Where ID_Obat = '" + (textBox1.Text) + "'", conn);
            SqlDataAdapter da = new SqlDataAdapter(check);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Data sudah ada", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("Data tidak lengkap", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into dbo.Obat (ID_Obat,Nama_Obat,Harga_obat,stok_obat,jenis_obat)values(@ID,@Nama,@harga,@stok,@jenis)", conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@ID", textBox1.Text.ToString()));
                cmd.Parameters.Add(new SqlParameter("@Nama", textBox2.Text.ToString()));
                cmd.Parameters.Add(new SqlParameter("@harga", textBox3.Text.ToString()));
                cmd.Parameters.Add(new SqlParameter("@stok", textBox4.Text.ToString()));
                cmd.Parameters.Add(new SqlParameter("@jenis", textBox5.Text.ToString()));
                cmd.ExecuteNonQuery();

                conn.Close();
                MessageBox.Show("Data Berhasil ditambahkan");

            }
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            Lihatdata();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand check = new SqlCommand("select ID_Obat from dbo.Obat Where ID_Obat = '" + (textBox1.Text) + "'", conn);
            SqlDataAdapter da = new SqlDataAdapter(check);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Data tidak ada", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBox1.Text != "")
            {
                if (MessageBox.Show("Apakah anda yakin ingin menghapus data ini?", "Delete Record", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("delete dbo.Obat where ID_Obat= '" + (textBox1.Text) + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Data Berhasil dihapus");
                    refreshform();
                    Lihatdata();
                }
            }
            else
            {
                MessageBox.Show("ISI ID_kondisi yang akan dihapus");
            }
        }

        private void Update_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("Data tidak lengkap", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("Apakah anda yakin ingin mengupdate data ini?", "Update Record", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("update dbo.Obat set Nama_Obat = '" + textBox2.Text + "',Harga_obat = '" + textBox3.Text + "',stok_obat='" + textBox4.Text + "',jenis_obat= '" + textBox5.Text + "'where ID_Obat = '" + (textBox1.Text) + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Data Berhasil diupdate");
                    refreshform();
                    Lihatdata();
                }
            }
        }

        private void Search_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand check = new SqlCommand("select ID_Obat from dbo.Obat Where ID_Obat = '" + (textBox1.Text) + "'", conn);
            SqlDataAdapter sda = new SqlDataAdapter(check);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            conn.Close();
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Data tidak ada", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBox1.Text != "")
            {
                conn.Open();
                string str = "select * from dbo.Obat Where ID_obat = '" + (textBox1.Text) + "'";
                SqlDataAdapter da = new SqlDataAdapter(str, conn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                conn.Close();
                refreshform();
            }
            else
            {
                MessageBox.Show("ISI ID_kondisi yang akan dicari");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells["ID_Obat"].Value.ToString();
                textBox2.Text = row.Cells["Nama_Obat"].Value.ToString();
                textBox3.Text = row.Cells["harga_Obat"].Value.ToString();
                textBox4.Text = row.Cells["stok_Obat"].Value.ToString();
                textBox5.Text = row.Cells["Jenis_obat"].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            MainMenu MM = new MainMenu();
            MM.Show();
            this.Hide();

        }
    }
}