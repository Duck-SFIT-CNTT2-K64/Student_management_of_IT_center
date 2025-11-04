using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Student_manager.UI
{
    public partial class frmReport : Form
    {
        private DataTable _table;
        private bool _isEditing = false;
        private int _editingId = -1; // placeholder PK

        public frmReport()
        {
            InitializeComponent();
            Load += FrmReport_Load;
        }

        private void FrmReport_Load(object sender, EventArgs e)
        {
            // initialize in-memory table to mirror DB columns (replace with real DB code)
            _table = new DataTable();
            _table.Columns.Add("ReportId", typeof(int));
            _table.Columns.Add("Title", typeof(string));
            _table.Columns.Add("Description", typeof(string));
            _table.Columns.Add("CreatedAt", typeof(DateTime));

            // sample seed (remove in production)
            _table.Rows.Add(1, "Monthly Enrollment", "Enrollment numbers by class", DateTime.Now.AddDays(-7));
            _table.Rows.Add(2, "Tuition Receipts", "Recent tuition receipts", DateTime.Now.AddDays(-3));

            dgvReports.DataSource = _table;
            FormatGrid();
            SetEditingMode(false);
        }

        private void FormatGrid()
        {
            dgvReports.Columns["ReportId"].Visible = false;
            dgvReports.AutoResizeColumns();
        }

        private void SetEditingMode(bool editing)
        {
            _isEditing = editing;
            groupBoxDetails.Enabled = editing;
            btnSave.Enabled = editing;
            btnNew.Enabled = !editing;
            btnEdit.Enabled = !editing && dgvReports.SelectedRows.Count == 1;
            btnDelete.Enabled = !editing && dgvReports.SelectedRows.Count > 0;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            _editingId = -1;
            txtReportName.Text = "";
            txtDescription.Text = "";
            SetEditingMode(true);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvReports.SelectedRows.Count != 1) return;
            var row = (dgvReports.SelectedRows[0].DataBoundItem as DataRowView).Row;
            _editingId = Convert.ToInt32(row["ReportId"]);
            txtReportName.Text = row["Title"].ToString();
            txtDescription.Text = row["Description"].ToString();
            SetEditingMode(true);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvReports.SelectedRows.Count == 0) return;
            var confirm = MessageBox.Show("Delete selected report(s)?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            // TODO: Delete from database here. For now delete from in-memory table.
            foreach (DataGridViewRow sel in dgvReports.SelectedRows)
            {
                var rv = sel.DataBoundItem as DataRowView;
                if (rv != null) rv.Row.Delete();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var title = txtReportName.Text.Trim();
            var desc = txtDescription.Text.Trim();
            if (string.IsNullOrEmpty(title))
            {
                MessageBox.Show("Title is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (_editingId == -1)
            {
                // TODO: Insert into database, get new PK.
                var newId = (_table.Rows.Count > 0) ? _table.AsEnumerable().Max(r => r.Field<int>("ReportId")) + 1 : 1;
                _table.Rows.Add(newId, title, desc, DateTime.Now);
            }
            else
            {
                // TODO: Update database record
                var row = _table.AsEnumerable().FirstOrDefault(r => r.Field<int>("ReportId") == _editingId);
                if (row != null)
                {
                    row["Title"] = title;
                    row["Description"] = desc;
                }
            }

            dgvReports.Refresh();
            SetEditingMode(false);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // TODO: Reload from database
            dgvReports.DataSource = _table;
            dgvReports.Refresh();
        }

        private void dgvReports_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            btnEdit_Click(sender, EventArgs.Empty);
        }
    }
}
