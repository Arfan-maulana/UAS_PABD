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
    }
}
