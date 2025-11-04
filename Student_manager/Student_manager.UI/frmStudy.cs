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
    public partial class frmStudy : Form
    {
        public frmStudy()
        {
            InitializeComponent();
        }

        private void frmStudy_Load(object sender, EventArgs e)
        {
            // Wire Close button click to existing handler (designer may not have wired it)
            try
            {
                btnClose.Click -= btnThoat_Click;
            }
            catch { }
            btnClose.Click += btnThoat_Click;

            // Optional: initialize grid columns if empty to avoid blank UI
            if (dgvBangDiem.Columns.Count == 0)
            {
                dgvBangDiem.Columns.Add("Course", "Course");
                dgvBangDiem.Columns.Add("Score", "Score");
                dgvBangDiem.Columns.Add("Credit", "Credit");
            }
        }

        private void dgvBangDiem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // reserved for future logic
        }

        // Close handler used by designer/button
        private void btnThoat_Click(object sender, EventArgs e)
        {
            var dr = MessageBox.Show("Are you sure you want to close?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes) this.Close();
        }
    }
}
