using System;
using System.Linq;
using System.Windows.Forms;
using System.ComponentModel;
using System.Data;
using System.Text.RegularExpressions;
using Student_manager.BLL;
using Student_manager.Models;

namespace Student_manager.UI
{
    public partial class frmAccount : Form
    {
        private BindingList<User> _users;
        private readonly UserService _service = new UserService();
        private int _editingId = -1;
        private bool _editing = false;
        private DataTable _rolesDt;

        // TODO: replace with actual current user id when you wire authentication
        private readonly int _currentUserId = 1;

        public frmAccount()
        {
            InitializeComponent();
            Load += FrmAccount_Load;
            dgvAccounts.DataBindingComplete += DgvAccounts_DataBindingComplete;
        }

        private void FrmAccount_Load(object sender, EventArgs e)
        {
            // local role mapping - update ids/names if different in your environment
            _rolesDt = new DataTable();
            _rolesDt.Columns.Add("Id", typeof(int));
            _rolesDt.Columns.Add("Name", typeof(string));
            //_rolesDt.Columns.Add("Email",  typeof(string));
            _rolesDt.Rows.Add(1, "Admin");
            _rolesDt.Rows.Add(2, "Staff");
            _rolesDt.Rows.Add(3, "Viewer");

            cboRole.DataSource = _rolesDt;
            cboRole.DisplayMember = "Name";
            cboRole.ValueMember = "Id";
            if (cboRole.Items.Count > 0) cboRole.SelectedIndex = 0;

            LoadUsers();
            FormatGrid();
            SetEditMode(false);
        }

        private void LoadUsers()
        {
            var list = _service.GetAllUsers().ToList();
            _users = new BindingList<User>(list);
            dgvAccounts.DataSource = new BindingSource { DataSource = _users };
        }

        private void FormatGrid()
        {
            // hide internal columns that shouldn't show by default
            if (dgvAccounts.Columns.Contains("PasswordHash")) dgvAccounts.Columns["PasswordHash"].Visible = false;
            //if (dgvAccounts.Columns.Contains("Email")) dgvAccounts.Columns["Email"].Visible = false;
            if (dgvAccounts.Columns.Contains("PhoneNumber")) dgvAccounts.Columns["PhoneNumber"].Visible = false;
            if (dgvAccounts.Columns.Contains("Status")) dgvAccounts.Columns["Status"].Visible = false;
            if (dgvAccounts.Columns.Contains("DateCreated")) dgvAccounts.Columns["DateCreated"].Visible = false;

            // keep RoleId hidden and show friendly Role column instead (populated in DataBindingComplete)
            if (dgvAccounts.Columns.Contains("RoleId")) dgvAccounts.Columns["RoleId"].Visible = false;

            dgvAccounts.AutoResizeColumns();
        }

        private void DgvAccounts_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // ensure an unbound "Role" column exists and fill it from RoleId
            if (!dgvAccounts.Columns.Contains("Role"))
            {
                var col = new DataGridViewTextBoxColumn { Name = "Role", HeaderText = "Role", ReadOnly = true };
                dgvAccounts.Columns.Add(col);
            }

            foreach (DataGridViewRow row in dgvAccounts.Rows)
            {
                if (row.IsNewRow) continue;
                var roleIdObj = row.Cells["RoleId"]?.Value;
                row.Cells["Role"].Value = GetRoleName(roleIdObj);
            }
        }

        private string GetRoleName(object roleIdObj)
        {
            if (roleIdObj == null || roleIdObj == DBNull.Value) return string.Empty;
            int id;
            try { id = Convert.ToInt32(roleIdObj); }
            catch { return roleIdObj.ToString(); }
            var found = _rolesDt.AsEnumerable().FirstOrDefault(r => r.Field<int>("Id") == id);
            return found == null ? id.ToString() : found.Field<string>("Name");
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
            txtEmail.Text = "";
            if (cboRole.Items.Count > 0) cboRole.SelectedIndex = 0;
            SetEditMode(true);
        }

        private void btnAccEdit_Click(object sender, EventArgs e)
        {
            if (dgvAccounts.SelectedRows.Count != 1) return;
            var u = dgvAccounts.SelectedRows[0].DataBoundItem as User;
            if (u == null) return;

            _editingId = u.UserId;
            txtUsername.Text = u.Username;
            txtFullName.Text = u.FullName;
            txtEmail.Text = u.Email ?? "";
            if (u.RoleId.HasValue)
            {
                try { cboRole.SelectedValue = u.RoleId.Value; }
                catch { if (cboRole.Items.Count > 0) cboRole.SelectedIndex = 0; }
            }
            else if (cboRole.Items.Count > 0)
            {
                cboRole.SelectedIndex = 0;
            }

            SetEditMode(true);
        }

        private void btnAccDelete_Click(object sender, EventArgs e)
        {
            if (dgvAccounts.SelectedRows.Count == 0) return;

            var confirm = MessageBox.Show("Delete selected account(s)?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            foreach (DataGridViewRow sel in dgvAccounts.SelectedRows)
            {
                var u = sel.DataBoundItem as User;
                if (u != null)
                {
                    if (_service.DeleteUser(u.UserId, _currentUserId))
                    {
                        _users.Remove(u);
                    }
                    else
                    {
                        MessageBox.Show($"Failed to delete user {u.Username}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private bool IsValidEmailFormat(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;
            // simple, readable regex that covers most real-world emails
            var pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase);
        }

        private void btnAccSave_Click(object sender, EventArgs e)
        {
            var username = txtUsername.Text.Trim();
            var fullname = txtFullName.Text.Trim();
            var email = txtEmail.Text.Trim();
            var roleIdObj = cboRole.SelectedValue;
            int? roleId = null;
            if (roleIdObj != null && roleIdObj != DBNull.Value)
            {
                try { roleId = Convert.ToInt32(roleIdObj); } catch { roleId = null; }
            }

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Username required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Email required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmail.Focus();
                return;
            }

            if (!IsValidEmailFormat(email))
            {
                MessageBox.Show("Invalid email format.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmail.Focus();
                return;
            }

            // uniqueness check
            int? excludeId = (_editingId == -1) ? (int?)null : _editingId;
            if (_service.EmailExists(email, excludeId))
            {
                MessageBox.Show("Email already in use by another account.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmail.Focus();
                return;
            }

            if (_editingId == -1)
            {
                var u = new User
                {
                    Username = username,
                    FullName = fullname,
                    RoleId = roleId,
                    Email = email,
                    DateCreated = DateTime.Now,
                    Status = "Active"
                };

                try
                {
                    var newId = _service.CreateUser(u, _currentUserId);
                    if (newId > 0)
                    {
                        u.UserId = newId;
                        _users.Add(u);
                    }
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Insert failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                var existing = _users.FirstOrDefault(x => x.UserId == _editingId);
                if (existing != null)
                {
                    existing.Username = username;
                    existing.FullName = fullname;
                    existing.Email = email;
                    existing.RoleId = roleId;

                    try
                    {
                        if (_service.UpdateUser(existing, _currentUserId))
                        {
                            dgvAccounts.Refresh();
                        }
                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show(ex.Message, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Update failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            SetEditMode(false);
        }

        private void btnAccRefresh_Click(object sender, EventArgs e)
        {
            LoadUsers();
            dgvAccounts.Refresh();
        }

        private void dgvAccounts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            btnAccEdit_Click(sender, EventArgs.Empty);
        }

        private void dgvAccounts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
