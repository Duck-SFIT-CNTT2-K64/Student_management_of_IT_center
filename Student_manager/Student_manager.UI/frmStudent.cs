using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_manager.UI
{
    public partial class frmStudent : Form
    {

        public frmStudent()
        {
            InitializeComponent();
        }

        private void frmStudent_Load(object sender, EventArgs e)
        {
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dgvQLSV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Are you sure you want to quit?", "Yes/No", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        private void frmStudent_Load_1(object sender, EventArgs e)
        {

        }
    }
}
