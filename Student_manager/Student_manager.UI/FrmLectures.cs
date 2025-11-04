using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Student_manager.UI
{
    public partial class frmLectures : Form
    {
        private DataTable _table;
        private int _editingId = -1;

        public frmLectures()
        {
            InitializeComponent();
            Load += FrmLectures_Load;
        }

        private void FrmLectures_Load(object sender, EventArgs e)
        {
            _table = new DataTable();
            _table.Columns.Add("TeacherId", typeof(int));
            _table.Columns.Add("TeacherCode", typeof(string));
            _table.Columns.Add("FirstName", typeof(string));
            _table.Columns.Add("LastName", typeof(string));
            _table.Columns.Add("Email", typeof(string));

            _table.Rows.Add(1, "T001", "Nguyen", "A", "nguyena@example.com");
            _table.Rows.Add(2, "T002", "Tran", "B", "tranb@example.com");

            dgvLecturers.DataSource = _table;
            SetEditMode(false);
        }

        private void SetEditMode(bool editing)
        {
            groupDetails.Enabled = editing;
            btnSave.Enabled = editing;
            btnNew.Enabled = !editing;
            btnEdit.Enabled = !editing && dgvLecturers.SelectedRows.Count == 1;
            btnDelete.Enabled = !editing && dgvLecturers.SelectedRows.Count > 0;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            _editingId = -1;
            txtTeacherCode.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
            SetEditMode(true);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvLecturers.SelectedRows.Count != 1) return;
            var row = (dgvLecturers.SelectedRows[0].DataBoundItem as DataRowView).Row;
            _editingId = Convert.ToInt32(row["TeacherId"]);
            txtTeacherCode.Text = row["TeacherCode"].ToString();
            txtFirstName.Text = row["FirstName"].ToString();
            txtLastName.Text = row["LastName"].ToString();
            txtEmail.Text = row["Email"].ToString();
            SetEditMode(true);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvLecturers.SelectedRows.Count == 0) return;
            var confirm = MessageBox.Show("Delete selected lecturer(s)?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;
            foreach (DataGridViewRow sel in dgvLecturers.SelectedRows)
            {
                var rv = sel.DataBoundItem as DataRowView;
                if (rv != null) rv.Row.Delete();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var code = txtTeacherCode.Text.Trim();
            var first = txtFirstName.Text.Trim();
            var last = txtLastName.Text.Trim();
            var email = txtEmail.Text.Trim();

            if (string.IsNullOrEmpty(code))
            {
                MessageBox.Show("Code required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (_editingId == -1)
            {
                var newId = (_table.Rows.Count > 0) ? _table.AsEnumerable().Max(r => r.Field<int>("TeacherId")) + 1 : 1;
                _table.Rows.Add(newId, code, first, last, email);
            }
            else
            {
                var row = _table.AsEnumerable().FirstOrDefault(r => r.Field<int>("TeacherId") == _editingId);
                if (row != null)
                {
                    row["TeacherCode"] = code;
                    row["FirstName"] = first;
                    row["LastName"] = last;
                    row["Email"] = email;
                }
            }

            dgvLecturers.Refresh();
            SetEditMode(false);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // TODO: reload from DB
            dgvLecturers.DataSource = _table;
            dgvLecturers.Refresh();
        }

        private void dgvLecturers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            btnEdit_Click(sender, EventArgs.Empty);
        }
    }
}
