using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Student_manager.BLL;
using Student_manager.Models;

namespace Student_manager.UI
{
    public partial class frmReport : Form
    {
        private BindingList<Report> _reports;
        private readonly ReportService _service = new ReportService();
        private int _editingId = -1;

        public frmReport()
        {
            InitializeComponent();
            Load += FrmReport_Load;
        }

        private void FrmReport_Load(object sender, EventArgs e)
        {
            LoadReports();
            FormatGrid();
            SetEditingMode(false);
        }

        private void LoadReports()
        {
            var list = _service.GetAllReports().ToList();
            _reports = new BindingList<Report>(list);
            dgvReports.DataSource = new BindingSource { DataSource = _reports };
        }

        private void FormatGrid()
        {
            if (dgvReports.Columns.Contains("ReportId")) dgvReports.Columns["ReportId"].Visible = false;
            dgvReports.AutoResizeColumns();
        }

        private void SetEditingMode(bool editing)
        {
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
            var r = dgvReports.SelectedRows[0].DataBoundItem as Report;
            if (r == null) return;
            _editingId = r.ReportId;
            txtReportName.Text = r.Title;
            txtDescription.Text = r.Description;
            SetEditingMode(true);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvReports.SelectedRows.Count == 0) return;
            if (MessageBox.Show("Delete selected report(s)?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;

            foreach (DataGridViewRow sel in dgvReports.SelectedRows)
            {
                var r = sel.DataBoundItem as Report;
                if (r != null)
                {
                    if (r.ReportId > 0) _service.DeleteReport(r.ReportId);
                    _reports.Remove(r);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var title = txtReportName.Text.Trim();
            var desc = txtDescription.Text.Trim();
            if (string.IsNullOrWhiteSpace(title))
            {
                MessageBox.Show("Title is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtReportName.Focus();
                return;
            }

            if (_editingId == -1)
            {
                var r = new Report { Title = title, Description = desc, CreatedAt = DateTime.Now };
                try
                {
                    var newId = _service.CreateReport(r);
                    if (newId > 0)
                    {
                        r.ReportId = newId;
                        _reports.Add(r);
                    }
                    else
                    {
                        MessageBox.Show("Insert failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Insert error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                var existing = _reports.FirstOrDefault(x => x.ReportId == _editingId);
                if (existing != null)
                {
                    existing.Title = title;
                    existing.Description = desc;
                    try
                    {
                        if (!_service.UpdateReport(existing))
                        {
                            MessageBox.Show("Update failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        dgvReports.Refresh();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Update error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            SetEditingMode(false);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadReports();
        }

        private void dgvReports_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            btnEdit_Click(sender, EventArgs.Empty);
        }
    }
}
