using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Student_manager.UI
{
    public partial class frmAccount : Form
    {
        private DataTable _table;
        private int _editingId = -1;
        private bool _editing = false;

        public frmAccount()
        {
            InitializeComponent();
            Load += FrmAccount_Load;
        }

        private void FrmAccount_Load(object sender, EventArgs e)
        {
            // create simple DataTable; replace with DB integration
            _table = new DataTable();
            _table.Columns.Add("UserId", typeof(int));
            _table.Columns.Add("Username", typeof(string));
            _table.Columns.Add("FullName", typeof(string));
            _table.Columns.Add("Role", typeof(string));
            _table.Rows.Add(1, "admin", "Administrator", "Admin");

            dgvAccounts.DataSource = _table;
            cboRole.Items.AddRange(new object[] { "Admin", "Staff", "Viewer" });
            if (cboRole.Items.Count > 0) cboRole.SelectedIndex = 0;
            SetEditMode(false);
        }

        private void SetEditMode(bool editing)
        {
            _editing = editing;
            groupDetails.Enabled = editing;
            btnAccSave.Enabled = editing;
            btnAccNew.Enabled = !editing;
            btnAccEdit.Enabled = !editing && dgvAccounts.SelectedRows.Count == 1;
            btnAccDelete.Enabled = !editing && dgvAccounts.SelectedRows.Count > 0;
        }

        private void btnAccNew_Click(object sender, EventArgs e)
        {
            _editingId = -1;
            txtUsername.Text = "";
            txtFullName.Text = "";
            cboRole.SelectedIndex = 0;
            SetEditMode(true);
        }

        private void btnAccEdit_Click(object sender, EventArgs e)
        {
            if (dgvAccounts.SelectedRows.Count != 1) return;
            var row = (dgvAccounts.SelectedRows[0].DataBoundItem as DataRowView).Row;
            _editingId = Convert.ToInt32(row["UserId"]);
            txtUsername.Text = row["Username"].ToString();
            txtFullName.Text = row["FullName"].ToString();
            cboRole.SelectedItem = row["Role"].ToString();
            SetEditMode(true);
        }

        private void btnAccDelete_Click(object sender, EventArgs e)
        {
            if (dgvAccounts.SelectedRows.Count == 0) return;
            var confirm = MessageBox.Show("Delete selected account(s)?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;
            foreach (DataGridViewRow sel in dgvAccounts.SelectedRows)
            {
                var rv = sel.DataBoundItem as DataRowView;
                if (rv != null) rv.Row.Delete();
            }
        }

        private void btnAccSave_Click(object sender, EventArgs e)
        {
            var username = txtUsername.Text.Trim();
            var fullname = txtFullName.Text.Trim();
            var role = cboRole.SelectedItem?.ToString() ?? "";

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Username required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (_editingId == -1)
            {
                var newId = (_table.Rows.Count > 0) ? _table.AsEnumerable().Max(r => r.Field<int>("UserId")) + 1 : 1;
                _table.Rows.Add(newId, username, fullname, role);
            }
            else
            {
                var row = _table.AsEnumerable().FirstOrDefault(r => r.Field<int>("UserId") == _editingId);
                if (row != null)
                {
                    row["Username"] = username;
                    row["FullName"] = fullname;
                    row["Role"] = role;
                }
            }

            dgvAccounts.Refresh();
            SetEditMode(false);
        }

        private void btnAccRefresh_Click(object sender, EventArgs e)
        {
            // TODO: reload from DB
            dgvAccounts.DataSource = _table;
            dgvAccounts.Refresh();
        }

        private void dgvAccounts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            btnAccEdit_Click(sender, EventArgs.Empty);
        }
    }
}
