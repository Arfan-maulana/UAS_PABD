using pabd.DATA;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pabd
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void inputObatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataObat DO = new DataObat();
            DO.Show();
            this.Hide();
        }

        private void dataPelangganToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataPelanggan DP = new DataPelanggan ();
            DP.Show();
            this.Hide();
        }

        private void dataApotekerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataApoteker DA= new DataApoteker();
            DA.Show();
            this.Hide();

        }

        private void dataKaryawanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataKaryawan DK = new DataKaryawan();
            DK.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 Fm = new Form1();
            Fm.Show();
            this.Hide();
        }
    }
}
