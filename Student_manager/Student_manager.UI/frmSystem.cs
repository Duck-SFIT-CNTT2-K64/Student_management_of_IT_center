using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Student_manager.BLL;


namespace Student_manager.UI
{
    public partial class frmSystem : Form
    {
        private readonly UserRoleService _userService;
        private readonly RoleService _roleService;
        private readonly ActionLogsService _actionLogService;

        private string _currentMode = "Users";
        public frmSystem()
        {
            InitializeComponent();

            _userService = new UserRoleService();
            _roleService = new RoleService();
            _actionLogService = new ActionLogsService();
        }

        private void frmSystem_Load(object sender, EventArgs e)
        {
            LoadRoleComboBox();
            cboRole.SelectedIndex = -1;
            SwitchMode("Users");

        }
        private void SwitchMode(string mode)
        {
            _currentMode = mode;
            SetInputsEnabled(false); 

            if (mode == "Users")
            {
                SetInputsEnabled(true); 
                LoadUserList(); 
            }
            else if (mode == "Roles")
            {
                
                dgvAdmin.DataSource = _roleService.GetRoles();
            }
            else if (mode == "Permissions")
            {
                
                dgvAdmin.DataSource = _roleService.GetPermissions();
            }
            else if (mode == "Action Logs")
            {
                
                dgvAdmin.DataSource = _actionLogService.GetActionLogs();
            }
        }
        private void SetInputsEnabled(bool enabled)
        {
            txtUsername.Enabled = enabled;
            txtPassword.Enabled = enabled;
            txtEmail.Enabled = enabled;
            cboRole.Enabled = enabled;
            txtFullName.Enabled = enabled; 

            btnAdd.Enabled = enabled;
            btnUpdate.Enabled = enabled;
            btnDelete.Enabled = enabled;
            btnSearch.Enabled = enabled;
        }
        private void LoadRoleComboBox()
        {
            
            cboRole.DataSource = _roleService.GetRoles();
            cboRole.DisplayMember = "RoleName";
            cboRole.ValueMember = "RoleId";
        }
        private void LoadUserList()
        {
            dgvAdmin.DataSource = _userService.GetUserList();
        }
        private void btnUsers_Click(object sender, EventArgs e) { SwitchMode("Users"); }
        private void btnRoles_Click(object sender, EventArgs e) { SwitchMode("Roles"); }
        private void btnPermissions_Click(object sender, EventArgs e) { SwitchMode("Permissions"); }
        private void btnActionLogs_Click(object sender, EventArgs e) { SwitchMode("Action Logs"); }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
          
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            
        }

        private void dgvAdmin_SelectionChanged(object sender, EventArgs e)
        {
            if (_currentMode != "Users" || dgvAdmin.SelectedRows.Count == 0) return;

            DataRowView row = dgvAdmin.SelectedRows[0].DataBoundItem as DataRowView;
            txtUsername.Text = row["Username"].ToString();
            txtEmail.Text = row["Email"].ToString();
            
            cboRole.Text = row["RoleName"].ToString(); 
            txtFullName.Text = row["FullName"].ToString();
            txtPhoneNumber.Text = row["PhoneNumber"].ToString();

            txtUsername.Enabled = false;
            txtPassword.Text = "**********";
            txtPassword.Enabled = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtFullName.Clear();
            txtEmail.Clear();
            txtPhoneNumber.Clear();
            cboRole.SelectedIndex = -1; 

            
            txtUsername.Enabled = true;
            txtPassword.Enabled = true;
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text; 
            string fullName = txtFullName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string phone = txtPhoneNumber.Text.Trim();

            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("You must enter an Username.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus(); 
                return; 
            }

            if (string.IsNullOrWhiteSpace(fullName))
            {
                MessageBox.Show("You must enter a FullName", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFullName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("You must enter a Password", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("You must enter an Email", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(phone))
            {
                MessageBox.Show("You must enter a Phone Number", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhoneNumber.Focus();
                return;
            }
            if (cboRole.SelectedIndex == -1) 
            {
                MessageBox.Show("You must enter a Role", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboRole.Focus();
                return;
            }

            bool success = _userService.CreateUser(
                username,
                password,
                fullName,
                email,
                phone,
                (int)cboRole.SelectedValue, 
                out string errorMessage
            );
            if (success)
            {
                MessageBox.Show("User added!");
                LoadUserList();
                btnClear_Click(null, null); 
            }
            else
            {
                
                MessageBox.Show(errorMessage, "Error");
            }
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            if (dgvAdmin.SelectedRows.Count == 0) return;
            int userId = (int)(dgvAdmin.SelectedRows[0].DataBoundItem as DataRowView)["UserId"];

            bool success = _userService.UpdateUser(
                userId,
                txtFullName.Text.Trim(), 
                txtEmail.Text.Trim(),
                txtPhoneNumber.Text.Trim(),
                (int)cboRole.SelectedValue,
                out string errorMessage
            );

            if (success) { MessageBox.Show("User updated!"); LoadUserList(); }
            else { MessageBox.Show(errorMessage, "Error"); }
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (dgvAdmin.SelectedRows.Count == 0) return;
            int userId = (int)(dgvAdmin.SelectedRows[0].DataBoundItem as DataRowView)["UserId"];

            if (MessageBox.Show("Are you sure?", "Delete User", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                bool success = _userService.DeleteUser(userId, out string errorMessage);
                if (success) { MessageBox.Show("User deleted!"); LoadUserList(); }
                else { MessageBox.Show(errorMessage, "Error"); }
            }
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string fullName = txtFullName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string phoneNumber = txtPhoneNumber.Text.Trim();
            bool roleSelected = cboRole.SelectedIndex != -1;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(fullName) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(phoneNumber) || !roleSelected)
            {
                MessageBox.Show("You must fill fully information","Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 

            }
            dgvAdmin.DataSource = _userService.SearchUsers(
                username,
                email,
                phoneNumber,
                (int)cboRole.SelectedValue
            ); 
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            SwitchMode("Users");
        }

        private void btnRole_Click(object sender, EventArgs e)
        {
            SwitchMode("Roles");
        }

        private void btnPermission_Click(object sender, EventArgs e)
        {
            SwitchMode("Permissions");
        }

        private void btnAcLog_Click(object sender, EventArgs e)
        {
            SwitchMode("Action Logs");
        }
    }
}
