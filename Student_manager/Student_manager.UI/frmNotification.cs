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
    public partial class frmNotification : Form
    {
        public frmNotification()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSubject.Clear();
            txtMessage.Clear();
            radStudents.Checked = false;
            radTeachers.Checked = false;
            radUsers.Checked = false;
        }
    }
}
